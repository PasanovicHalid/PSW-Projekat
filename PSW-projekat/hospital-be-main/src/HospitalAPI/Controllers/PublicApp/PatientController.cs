using System.Collections.Generic;
using HospitalLibrary.Core.DTOs;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Service;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controllers.PublicApp
{

    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;
        

        public PatientController(IPatientService patientService)
        {
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


    }
}
