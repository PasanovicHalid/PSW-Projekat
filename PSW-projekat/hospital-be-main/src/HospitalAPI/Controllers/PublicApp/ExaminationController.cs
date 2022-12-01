using HospitalLibrary.Core.DTOs;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
namespace HospitalAPI.Controllers.PublicApp
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class ExaminationController : ControllerBase
    {

        private readonly IExaminationService _examinationService;

        public ExaminationController(IExaminationService examinationService)
        {
            _examinationService = examinationService;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            List<ExaminationDto> examinationDto = new List<ExaminationDto>();
            foreach (var examination in _examinationService.GetAll())
            {
                PatientDto patientDto = new PatientDto(examination.Appointment.Patient.Id, examination.Appointment.Patient.Person.Name,
                  examination.Appointment.Patient.Person.Surname, examination.Appointment.Patient.Person.Email, 
                  examination.Appointment.Patient.Person.Role);

                DoctorDto doctorDto = new DoctorDto(examination.Appointment.Doctor.Id, examination.Appointment.Doctor.Person.Name,
                   examination.Appointment.Doctor.Person.Surname, examination.Appointment.Doctor.Person.Email, examination.Appointment.Doctor.Person.Role);

                AppointmentDto appointmentDto = new AppointmentDto(examination.Appointment.Id, examination.Appointment.DateTime, 
                    patientDto, doctorDto);

                examinationDto.Add(new ExaminationDto(examination.Id, appointmentDto, examination.Prescriptions,
                    examination.Symptoms, examination.Report));

            }
            return Ok(examinationDto);
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var examination = _examinationService.GetById(id);

            PatientDto patientDto = new PatientDto(examination.Appointment.Patient.Id, examination.Appointment.Patient.Person.Name,
                  examination.Appointment.Patient.Person.Surname, examination.Appointment.Patient.Person.Email,
                  examination.Appointment.Patient.Person.Role);

            DoctorDto doctorDto = new DoctorDto(examination.Appointment.Doctor.Id, examination.Appointment.Doctor.Person.Name,
               examination.Appointment.Doctor.Person.Surname, examination.Appointment.Doctor.Person.Email, examination.Appointment.Doctor.Person.Role);

            AppointmentDto appointmentDto = new AppointmentDto(examination.Appointment.Id, examination.Appointment.DateTime,
                patientDto, doctorDto);

            ExaminationDto examinationDto = new ExaminationDto(examination.Id, appointmentDto, examination.Prescriptions,
                    examination.Symptoms, examination.Report);

            if (examination == null)
            {
                return NotFound();
            }

            return Ok(examinationDto);
        }

        [HttpPost]
        public ActionResult Create(Examination examination)
        {
            //appointment.Doctor = _doctorService.GetById(appointment.Doctor.Id);
            //appointment.Patient = _patientService.GetById(appointment.Patient.Id);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _examinationService.Create(examination);
            return Ok();
        }
    }
}
