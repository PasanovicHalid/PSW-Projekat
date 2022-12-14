using HospitalLibrary.Core.DTOs;
using HospitalLibrary.Core.DTOs.CreatingAppointmentsDTOs;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Bcpg.Sig;
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

        [HttpPost]
        public ActionResult Create(Appointment appointment)
        {
            appointment.Doctor = _doctorService.GetById(appointment.Doctor.Id);
            appointment.Patient = _patientService.GetById(appointment.Patient.Id);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _appointmentService.Create(appointment);
            return Ok();
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
                            AppointmentTime = app.DateTime.Date,
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
                        AppointmentTime = app.DateTime.Date,
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

        [Authorize(Roles = "Patient")]
        [HttpGet("GetAllDoctorsForCreatingAppointment")]
        public ActionResult GetAllDoctorsForCreatingAppointment()
        {
            return Ok(_doctorService.GetAllDoctorsForCreatingAppointment());
        }

        [Authorize(Roles = "Patient")]
        [HttpPost("GetAllAvailableAppointmentsForCreatingAppointment")]
        public ActionResult GetAllAvailableAppointmentsForCreatingAppointment(
            CheckAvailableAppontmentDto checkAvailableAppontment
        )
        {
            List<AppointmentsAvailableForCreatingAppointment> appointments = _appointmentService.GetAllAvailableAppointmentsForCreatingAppointment(checkAvailableAppontment);
            if (appointments == null)
                return BadRequest();
            return Ok(appointments);
        }

        [Authorize(Roles = "Patient")]
        [HttpPost("CreateCustomAppointment")]
        public ActionResult CreateCustomAppointment(
            CustomAppointmentForCreatingDto checkAppointment
        )
        {
            return Ok(_appointmentService.CreateCustomAppointment(checkAppointment));
        }
    }
}
