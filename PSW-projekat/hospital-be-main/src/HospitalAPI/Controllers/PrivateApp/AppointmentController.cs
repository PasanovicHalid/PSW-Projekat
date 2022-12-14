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
    [Authorize]
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]

    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IDoctorService _doctorService;
        private readonly IPatientService _patientService;


        public AppointmentController(IAppointmentService appointmentService, IDoctorService doctorService, IPatientService patientService)
        {
            _appointmentService = appointmentService;
            _doctorService = doctorService;
            _patientService = patientService;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            List<AppointmentDto> appointmentDto = new List<AppointmentDto>();
            foreach (var appointment in _appointmentService.GetAll())
            {
                PatientDto patientDto = new PatientDto(appointment.Patient.Id, appointment.Patient.Person.Name,
                    appointment.Patient.Person.Surname, appointment.Patient.Person.Email.Adress.ToString(), appointment.Patient.Person.Role);

                DoctorDto doctorDto = new DoctorDto(appointment.Doctor.Id, appointment.Doctor.Person.Name,
                   appointment.Doctor.Person.Surname, appointment.Doctor.Person.Email.Adress.ToString(), appointment.Doctor.Person.Role);

                appointmentDto.Add(new AppointmentDto(appointment.Id, appointment.DateTime, (DateTime)appointment.CancelationDate, patientDto, doctorDto));

            }

            return Ok(appointmentDto);
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var appointment = _appointmentService.GetById(id);

            PatientDto patientDto = new PatientDto(appointment.Patient.Id, appointment.Patient.Person.Name,
                    appointment.Patient.Person.Surname, appointment.Patient.Person.Email.ToString(), appointment.Patient.Person.Role);

            DoctorDto doctorDto = new DoctorDto(appointment.Doctor.Id, appointment.Doctor.Person.Name,
               appointment.Doctor.Person.Surname, appointment.Doctor.Person.Email.ToString(), appointment.Doctor.Person.Role);

            AppointmentDto appointmentDto = new AppointmentDto(appointment.Id, appointment.DateTime, (DateTime)appointment.CancelationDate, patientDto, doctorDto);
            if (appointment == null)
            {
                return NotFound();
            }

            return Ok(appointmentDto);
        }

        [HttpPost]
        public ActionResult Create(Appointment appointment)
        {
            appointment.Doctor = _doctorService.GetById(appointment.Doctor.Id);
            appointment.Patient = _patientService.GetById(appointment.Patient.Id);
            appointment.CancelationDate = new DateTime();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _appointmentService.Create(appointment);
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, AppointmentDto appointmentDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != appointmentDto.Id)
            {
                return BadRequest();
            }
            Appointment appointment = _appointmentService.GetById(appointmentDto.Id);
            appointment.DateTime = appointmentDto.DateTime;

            try
            {
                _appointmentService.Update(appointment);
            }
            catch(Exception)
            {
                return BadRequest();

            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var appointment = _appointmentService.GetById(id);
            if (appointment == null)
            {
                return NotFound();
            }

            _appointmentService.Delete(appointment);
            return NoContent();
        }

        [HttpGet("doctor/{personId}")]
        public ActionResult GetAllByDoctor(int personId)
        {
            return Ok(_appointmentService.GetAllByDoctor(personId));
        }  
    }
}
