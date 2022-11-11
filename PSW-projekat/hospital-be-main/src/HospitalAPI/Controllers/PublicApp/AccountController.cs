using HospitalLibrary.Core.DTOs;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Model.Enums;
using HospitalLibrary.Core.Service;
using HospitalLibrary.Identity;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HospitalAPI.Controllers.PublicApp
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly PersonService _personService;
        private readonly UserManager<SecUser> _userManager;
        private readonly SignInManager<SecUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly DoctorService _doctorService;
        private readonly PatientService _patientService;
        private readonly IConfiguration _configuration;

        public AccountController( 
                UserManager<SecUser> userManager, 
                SignInManager<SecUser> signInManager,
                RoleManager<IdentityRole> roleManager,
                PersonService personService,
                DoctorService doctorService,
                PatientService patientService,
                IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _personService = personService;
            _doctorService = doctorService;
            _patientService = patientService;
            _configuration = configuration;
        }

        [HttpGet("Login")]
        public async Task<ActionResult> LoginAsync(string username, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(username, password, true, false);
            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(username);
                if (user != null && await _userManager.CheckPasswordAsync(user, password))
                {
                    var userRoles = await _userManager.GetRolesAsync(user);

                    var authClaims = new List<Claim>
                    {
                        new Claim("Name", user.UserName),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    };

                    foreach (var userRole in userRoles)
                    {
                        authClaims.Add(new Claim("Role", userRole));
                    }

                    var token = GetToken(authClaims);

                    return Ok(new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(token),
                        expiration = token.ValidTo
                    });
                }
            }
            return Unauthorized();
        }

        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddDays(30),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }

        [HttpGet("Logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok();
        }


        [HttpGet("/getAllergiesAndDoctors")]
        public ActionResult GetAllergiesAndDoctors()
        {
            return Ok(_doctorService.GetAllergiesAndDoctors());
        }


        [HttpPost("CreateManager")]
        public async Task<IActionResult> CreateManager(CreateManagerDto createManagerDto)
        {
            bool patientRoleExists = await _roleManager.RoleExistsAsync("Manager");
            if (!patientRoleExists)
            {
                IdentityRole identityRole = new IdentityRole("Manager");
                var roleResult = await _roleManager.CreateAsync(identityRole);
            }

            Person user = new Person()
            {
                Id = 0,
                Name = createManagerDto.Name,
                Surname = createManagerDto.Surname,
                Role = Role.manager,
                Email = createManagerDto.Email,
                Gender = createManagerDto.Gender,
                BirthDate = Convert.ToDateTime(createManagerDto.BirthDate),
                Address = new Address()
                {
                    Street = createManagerDto.Street,
                    City = createManagerDto.City,
                    Number = createManagerDto.Number,
                    PostCode = createManagerDto.PostCode,
                    Township = createManagerDto.Township,
                }
            };
            user = _personService.RegisterPerson(user);
            SecUser secUser = new SecUser()
            {
                Id = user.Id,
                Email = createManagerDto.Email,
                UserName = createManagerDto.Username,
            };
            var registerUser = await _userManager.CreateAsync(secUser, createManagerDto.Password);
            if (registerUser != null)
            {
                await _userManager.AddToRoleAsync(secUser, "Manager");
                await _userManager.AddClaimAsync(secUser, new Claim("UserId", user.Id.ToString()));
            }

            return Ok(user);
        }

        [HttpPost("RegisterPatient")]
        public async Task<IActionResult> RegisterPatient(RegisterPatientDto regUser)
        {
            bool patientRoleExists = await _roleManager.RoleExistsAsync("Patient");
            if (!patientRoleExists)
            {
                IdentityRole identityRole = new IdentityRole("Patient");
                var roleResult = await _roleManager.CreateAsync(identityRole);
            }

            Person user = new Person()
            {
                Id = 0,
                Name = regUser.Name,
                Surname = regUser.Surname,
                Role = Role.patient,
                Email = regUser.Email,
                Gender = regUser.Gender,
                BirthDate = Convert.ToDateTime(regUser.BirthDate),
                Address = new Address()
                {
                    Street = regUser.Street,
                    City = regUser.City,
                    Number = regUser.Number,
                    PostCode = regUser.PostCode,
                    Township = regUser.Township,
                }
            };
            user = _personService.RegisterPerson(user);
            Doctor doctor = _doctorService.GetById(regUser.DoctorName.Id);

            Patient patient = new Patient()
            {
                BloodType = regUser.BloodType,
                Person = user,
                Doctor = doctor
            };

            patient = _patientService.RegisterPatient(patient);

            SecUser secUser = new SecUser()
            {
                Id = user.Id,
                Email = regUser.Email,
                UserName = regUser.Username,
            };
            var registerUser = await _userManager.CreateAsync(secUser, regUser.Password);
            if (registerUser != null)
            {
                await _userManager.AddToRoleAsync(secUser, "Patient");
                await _userManager.AddClaimAsync(secUser, new Claim("UserId", user.Id.ToString()));
            }

            //var code = await _userManager.GenerateEmailConfirmationTokenAsync(secUser);
            //await _userManager.ConfirmEmailAsync(secUser, code);

            return Ok();
        }

        [HttpPost("CreateDoctor")]
        public async Task<IActionResult> CreateDoctor(CreateDoctorDto createDoctorDto)
        {
            bool patientRoleExists = await _roleManager.RoleExistsAsync("Doctor");
            if (!patientRoleExists)
            {
                IdentityRole identityRole = new IdentityRole("Doctor");
                var roleResult = await _roleManager.CreateAsync(identityRole);
            }

            Person user = new Person()
            {
                Id = 0,
                Name = createDoctorDto.Name,
                Surname = createDoctorDto.Surname,
                Role = Role.doctor,
                Email = createDoctorDto.Email,
                Gender = createDoctorDto.Gender,
                BirthDate = Convert.ToDateTime(createDoctorDto.BirthDate),
                Address = new Address()
                {
                    Street = createDoctorDto.Street,
                    City = createDoctorDto.City,
                    Number = createDoctorDto.Number,
                    PostCode = createDoctorDto.PostCode,
                    Township = createDoctorDto.Township,
                }
            };
            user = _personService.RegisterPerson(user);

            Doctor doctor = new Doctor()
            {
                Specialization = createDoctorDto.Specialization,
                Person = user,
            };

            doctor = _doctorService.RegisterDoctor(doctor);

            SecUser secUser = new SecUser()
            {
                Id = user.Id,
                Email = createDoctorDto.Email,
                UserName = createDoctorDto.Username,
            };
            var registerUser = await _userManager.CreateAsync(secUser, createDoctorDto.Password);
            if (registerUser != null)
            {
                await _userManager.AddToRoleAsync(secUser, "Doctor");
                await _userManager.AddClaimAsync(secUser, new Claim("UserId", user.Id.ToString()));
            }

            return Ok(user);
        }
    }
}
