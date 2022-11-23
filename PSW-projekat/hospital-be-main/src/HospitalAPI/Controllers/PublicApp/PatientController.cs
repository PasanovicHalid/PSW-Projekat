using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalLibrary.Core.DTOs;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Service;
using HospitalLibrary.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controllers.PublicApp
{

    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {

        private readonly UserManager<SecUser> _userManager;
        private readonly IPatientService _patientService;
        

        public PatientController(UserManager<SecUser> userManager, IPatientService patientService)
        {
            _userManager = userManager;
            _patientService = patientService;
        }

        [HttpGet]
        public ActionResult GetAll() 
        { 
            List<PatientDto> patientDto = new List<PatientDto>();
            foreach (var patient in _patientService.GetAll()) 
            {
                patientDto.Add(new PatientDto(patient.Id, patient.Person.Name, patient.Person.Surname, patient.Person.Email, patient.Person.Role));

            }

            return Ok(patientDto);
        }

        /*
        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var patient = _patientService.GetById(id);
            if (patient == null)
            {
                return NotFound();
            }

            return Ok(patient);
        }
        */

        [HttpGet("patientsNoTreatment")]
        public ActionResult GetPatientsNoTreatment()
        {
            List<PatientDto> patientDto = new List<PatientDto>();
            foreach (var patient in _patientService.GetPatientsNoTreatment())
            {
                patientDto.Add(new PatientDto(patient.Id, patient.Person.Name, patient.Person.Surname, patient.Person.Email, patient.Person.Role));

            }
            return Ok(patientDto);
        }

        [Authorize(Roles = "Patient")]
        [HttpGet ("GetByPersonId/{id}")]
        public async Task<ActionResult> GetByPersonId(int id)
        {
            Patient patient = _patientService.getPatientByPersonId(id);
            var secUser = await _userManager.FindByEmailAsync(patient.Person.Email);
            List<Allergy> allergies = _patientService.GetAllAllergiesForPatient(patient.Id).ToList();
            RegisterPatientDto patientDto = new RegisterPatientDto()
            {
                BirthDate = patient.Person.BirthDate.ToString(),
                Email = patient.Person.Email,
                Surname = patient.Person.Surname,
                Name = patient.Person.Name,
                Gender = patient.Person.Gender,

                Allergies = allergies,
                BloodType = patient.BloodType,
                DoctorName = new DoctorForPatientRegistrationDto() { 
                    FullName = patient.Doctor.Person.Name + " " + patient.Doctor.Person.Surname, 
                    Id=patient.Doctor.Id
                },

                Number = patient.Person.Address.Number,              
                City = patient.Person.Address.City,
                PostCode = patient.Person.Address.PostCode,
                Street = patient.Person.Address.Street,
                Township = patient.Person.Address.Township,

                Username = secUser.UserName,
                Password = "Can't show classifide information."
            };
     
            return Ok(patientDto);
        }

    }
}
