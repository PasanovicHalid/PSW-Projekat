using HospitalLibrary.Core.DTOs.CreatingAppointmentsDTOs;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Repository;
using HospitalLibrary.Core.Service;
using iTextSharp.text;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;

namespace HospitalAPI.Controllers.PublicApp
{
    //[Authorize]
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class PublicAppointmentController : ControllerBase
    {
        private readonly IDoctorService _doctorService;
        private readonly IAppointmentService _appointmentService;
        private readonly IPatientService _patientService;

        public PublicAppointmentController(
            IDoctorService doctorService,
            IAppointmentService appointmentService,
            IPatientService patientService,
            IWorkingDayRepository workingDayRepository
        )
        {
            _doctorService = doctorService;
            _appointmentService = appointmentService;
            _patientService = patientService;
        }

        [HttpGet("GetAllDoctorsForCreatingAppointment")]
        public ActionResult GetAllDoctorsForCreatingAppointment()
        {
            return Ok(_doctorService.GetAllDoctorsForCreatingAppointment());
        }

        [HttpPost("GetAllAvailableAppointmentsForCreatingAppointment")]
        public ActionResult GetAllAvailableAppointmentsForCreatingAppointment(
            CheckAvailableAppontmentDto checkAvailableAppontment
        )
        {
            if (_appointmentService.GetAllAvailableAppointmentsForCreatingAppointment(checkAvailableAppontment) == null)
                return BadRequest();
            return Ok(_appointmentService.GetAllAvailableAppointmentsForCreatingAppointment(checkAvailableAppontment));
        }
    }
}
