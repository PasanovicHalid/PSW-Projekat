using HospitalLibrary.Core.DTOs;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace HospitalAPI.Controllers.PrivateApp
{
    
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]

    public class PrivatePatientController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IDoctorService _doctorService;
        private readonly IPatientService _patientService;


        public PrivatePatientController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpGet]
        public ActionResult GetAllMaliciousPatients()
        {
            var maliciousPatients = _appointmentService.GetAllMaliciousPatients();
            List<PatientDto> maliciousPatientsDto = new List<PatientDto>();
            foreach(Patient mp in maliciousPatients)
            {
                PatientDto patientDto = new PatientDto(mp.Person.Id, mp.Person.Name, mp.Person.Surname, mp.Person.Email, mp.Person.Role);
                maliciousPatientsDto.Add(patientDto);
            }

            return Ok(maliciousPatientsDto);
        }

    }
}
