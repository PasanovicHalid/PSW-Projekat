using System.Collections.Generic;
using HospitalLibrary.Core.DTOs;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Model.Enums;
using HospitalLibrary.Core.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controllers.PublicApp
{
    [Authorize]
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }


        [HttpGet("GetAll")]
        public ActionResult GetAll()
        {
            List<DoctorDto> doctorDto = new List<DoctorDto>();
            foreach (var doctor in _doctorService.GetAll())
            {
                doctorDto.Add(new DoctorDto(doctor.Id, doctor.Person.Name, doctor.Person.Surname, doctor.Person.Email.ToString(), doctor.Person.Role));
            }
            return Ok(doctorDto);
        }

        [HttpGet("GetAllBySpecialization/{specialization}")]
        public ActionResult GetAllBySpecialization(Specialization specialization)
        {
            List<Doctor> doctors = (List<Doctor>)_doctorService.GetAllBySpecialization(specialization);
            List<SimpleDoctorDto> doctorsDto = new List<SimpleDoctorDto>();
            foreach (Doctor doctor in doctors)
            {
                doctorsDto.Add(new SimpleDoctorDto() { 
                    FullName = doctor.Person.Name + " " + doctor.Person.Surname,
                    Id = doctor.Id
                });
            }
            return Ok(doctorsDto);
        }

        [HttpGet("doctorDto/{personId}")]
        public ActionResult GetDoctorByPersonId(int personId)
        {
            var doctor = _doctorService.GetDoctorByPersonId(personId);

            DoctorDto doctorDto = new DoctorDto(doctor.Id, doctor.Person.Name, doctor.Person.Surname, doctor.Person.Email.Adress,
                doctor.Person.Role);

            if (doctor == null)
            {
                return NotFound();
            }
            return Ok(doctorDto);
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var doctor = _doctorService.GetById(id);
            if (doctor == null)
            {
                return NotFound();
            }
            return Ok(doctor);
        }

        [HttpGet("doctor/{doctorId}")]
        public ActionResult GetAllCouncilByDoctor(int doctorId)
        {
            return Ok(_doctorService.GetAllCouncilByDoctor(doctorId));
        }

    }
}