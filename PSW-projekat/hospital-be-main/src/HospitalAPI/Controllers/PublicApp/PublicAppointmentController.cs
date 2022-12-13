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
    [Authorize]
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]

    public class PublicAppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IDoctorService _doctorService;
        private readonly IPatientService _patientService;


        public PublicAppointmentController(IAppointmentService appointmentService, IDoctorService doctorService, IPatientService patientService)
        {
            _appointmentService = appointmentService;
            _doctorService = doctorService;
            _patientService = patientService;
        }

        [HttpPost("ScheduleAppointment")]
        public ActionResult ScheduleAppointment(ScheduleAppointmentDto appointmentDto)
        {
            Doctor doctor = _doctorService.GetById(appointmentDto.DoctorDto.Id);
            Patient patient = _patientService.getPatientByPersonId(appointmentDto.PersonId);
            //get appointment by date and time for doctor for extra validation

            if (doctor == null || patient == null)
            {
                return BadRequest();
            }

            Appointment appointment = new Appointment() { 
                Doctor = doctor,
                Patient = patient,
                DateTime = appointmentDto.ScheduledDate,
                CancelationDate = null
            };

            _appointmentService.ScheduleAppointment(appointment);
            return Ok();
        }
        
        [HttpGet("GetFreeAppointmentsForDoctorByDate/{doctorId}/{scheduledDate}")]
        public ActionResult GetFreeAppointmentsForDoctor(int doctorId, DateTime scheduledDate)
        {
            List<string> appointmentTimes = _appointmentService.GetFreeAppointmentsForDoctor(doctorId, scheduledDate);
            return Ok(appointmentTimes);
        }

        [HttpGet("GetPatientAppointments/{personId}")]
        public ActionResult GetPatientAppointments(int personId)
        {
            Patient patient = _patientService.getPatientByPersonId(personId);

            var patientAppointments = _appointmentService.GetAllAppointmentsForPatient(patient.Id);
            List<PatientAppointmentsDto> patientAppointmentsList = new List<PatientAppointmentsDto>();
            PatientAppointmentsDto patientAppointmentsDto = new PatientAppointmentsDto();

            foreach (var app in patientAppointments)
            {
                if (app.CancelationDate == null)
                {
                    if (app.DateTime.CompareTo(DateTime.Now) < 0)
                    {
                        patientAppointmentsDto = new PatientAppointmentsDto()
                        {
                            AppointmentId = app.Id,
                            DoctorFullName = app.Doctor.Person.Name + " " + app.Doctor.Person.Surname,
                            AppointmentTime = app.DateTime.Date,
                            AppointmentStatus = "Finished"
                        };
                    }
                    else
                    {
                        patientAppointmentsDto = new PatientAppointmentsDto()
                        {
                            AppointmentId = app.Id,
                            DoctorFullName = app.Doctor.Person.Name + " " + app.Doctor.Person.Surname,
                            AppointmentTime = app.DateTime,
                            AppointmentStatus = "Upcoming"
                        };
                    }

                }
                else if (app.CancelationDate != null)
                {
                    patientAppointmentsDto = new PatientAppointmentsDto()
                    {
                        AppointmentId = app.Id,
                        DoctorFullName = app.Doctor.Person.Name + " " + app.Doctor.Person.Surname,
                        AppointmentTime = app.DateTime,
                        AppointmentStatus = "Cancelled"
                    };
                }
                patientAppointmentsList.Add(patientAppointmentsDto);
            }
            return Ok(patientAppointmentsList);
        }

        [HttpPut("CancelAppointment/{appointmentId}")]
        public ActionResult CancelAppointment(int appointmentId)
        {
            var appointment = _appointmentService.GetById(appointmentId);
            if (appointment == null || appointment.CancelationDate != null || appointment.DateTime < DateTime.Now.AddDays(1))
            {
                return BadRequest();
            }
            appointment.CancelationDate = DateTime.Now;
            _appointmentService.Update(appointment);
            return Ok();
        }
    }
}
