﻿using HospitalLibrary.Core.DTOs;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Service;
using iTextSharp.text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace HospitalAPI.Controllers.PublicApp
{
    //[Authorize]
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class PublicAppointmentController : Controller
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IPatientService _patientService;


        public PublicAppointmentController(IAppointmentService appointmentService, IPatientService patientService)
        {
            _appointmentService = appointmentService;
            _patientService = patientService;
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
                if(app.CancelationDate == null)
                {
                    if(app.DateTime.CompareTo(DateTime.Now) < 0)
                    {
                        patientAppointmentsDto = new PatientAppointmentsDto()
                        {
                            AppointmentId = app.Id,
                            DoctorFullName = app.Doctor.Person.Name + " " + app.Doctor.Person.Surname,
                            AppointmentTime = app.DateTime,
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
                    
                }else if (app.CancelationDate != null)
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
            if(appointment == null || appointment.CancelationDate != null || appointment.DateTime<DateTime.Now.AddDays(1))
            {
                return BadRequest();
            }
            appointment.CancelationDate = DateTime.Now;
            _appointmentService.Update(appointment);
            return Ok();
        }
    }
}
