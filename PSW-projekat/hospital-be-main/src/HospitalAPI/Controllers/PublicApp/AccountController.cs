using HospitalLibrary.Core.DTOs;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Model.Enums;
using HospitalLibrary.Core.Repository;
using HospitalLibrary.Identity;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HospitalAPI.Controllers.PublicApp
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly UserManager<SecUser> _userManager;
        private readonly SignInManager<SecUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(IUserRepository userRepository, UserManager<SecUser> userManager, SignInManager<SecUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userRepository = userRepository;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        [HttpGet("Login")]
        public async Task<ActionResult> LoginAsync(string username, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(username, password, true, false);
            if (result.Succeeded)
            {
                //User.IsInRole("Manager");
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet("Logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok();
        }

        [HttpPost("CreateManager")]
        public async Task<IActionResult> CreateManager(RegisterUserDto regUser)
        {
            bool patientRoleExists = await _roleManager.RoleExistsAsync("Manager");
            if (!patientRoleExists)
            {
                IdentityRole identityRole = new IdentityRole("Manager");
                var roleResult = await _roleManager.CreateAsync(identityRole);
            }

            User user = new User()
            {
                Id = 0,
                Name = regUser.Name,
                Surname = regUser.Surname,
                Role = Role.manager,
                Email = regUser.Email
            };
            user = _userRepository.RegisterUser(user);
            SecUser secUser = new SecUser()
            {
                Id = user.Id,
                Email = regUser.Email,
                UserName = regUser.Username,
            };
            var registerUser = await _userManager.CreateAsync(secUser, regUser.Password);
            if (registerUser != null)
            {
                await _userManager.AddToRoleAsync(secUser, "Manager");
                await _userManager.AddClaimAsync(secUser, new Claim("UserId", user.Id.ToString()));
            }

            return Ok(user);
        }

            [HttpPost("RegisterPatient")]
        public async Task<IActionResult> RegisterPatient(RegisterUserDto regUser)
        {
            bool patientRoleExists = await _roleManager.RoleExistsAsync("Patient");
            if (!patientRoleExists)
            {
                IdentityRole identityRole = new IdentityRole("Patient");
                var roleResult = await _roleManager.CreateAsync(identityRole);
            }

            User user = new User()
            {
                Id = 0,
                Name = regUser.Name,
                Surname = regUser.Surname,
                Role = Role.patient,
                Email = regUser.Email
            };
            user = _userRepository.RegisterUser(user);
            SecUser secUser = new SecUser()
            {
                Id = user.Id,
                Email = regUser.Email,
                UserName = regUser.Username,
            };
            var registerUser = await _userManager.CreateAsync(secUser, regUser.Password);
            if(registerUser != null)
            {
                await _userManager.AddToRoleAsync(secUser, "Patient");
                await _userManager.AddClaimAsync(secUser, new Claim("UserId", user.Id.ToString()));
            }

            //var code = await _userManager.GenerateEmailConfirmationTokenAsync(secUser);
            //await _userManager.ConfirmEmailAsync(secUser, code);

            return Ok(user);
        }

        [HttpPost("CreateDoctor")]
        public async Task<IActionResult> CreateDoctor(RegisterUserDto regUser)
        {
            bool patientRoleExists = await _roleManager.RoleExistsAsync("Doctor");
            if (!patientRoleExists)
            {
                IdentityRole identityRole = new IdentityRole("Doctor");
                var roleResult = await _roleManager.CreateAsync(identityRole);
            }

            User user = new User()
            {
                Id = 0,
                Name = regUser.Name,
                Surname = regUser.Surname,
                Role = Role.doctor,
                Email = regUser.Email
            };
            user = _userRepository.RegisterUser(user);
            SecUser secUser = new SecUser()
            {
                Id = user.Id,
                Email = regUser.Email,
                UserName = regUser.Username,
            };
            var registerUser = await _userManager.CreateAsync(secUser, regUser.Password);
            if (registerUser != null)
            {
                await _userManager.AddToRoleAsync(secUser, "Doctor");
                await _userManager.AddClaimAsync(secUser, new Claim("UserId", user.Id.ToString()));
            }

            return Ok(user);
        }
    }
}
