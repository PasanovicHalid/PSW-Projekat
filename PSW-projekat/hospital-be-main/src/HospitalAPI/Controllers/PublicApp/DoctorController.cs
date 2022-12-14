﻿using System.Collections.Generic;
using HospitalLibrary.Core.DTOs;
using HospitalLibrary.Core.Model;
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


        [HttpGet]
        public ActionResult GetAll()
        {
            List<DoctorDto> doctorDtp = new List<DoctorDto>();
            foreach (var doctor in _doctorService.GetAll())
            {
                doctorDtp.Add(new DoctorDto(doctor.Id, doctor.Person.Name, doctor.Person.Surname, doctor.Person.Email, doctor.Person.Role));

            }
            return Ok(doctorDtp);
        }

        [HttpGet("doctor/{doctorId}")]
        public ActionResult GetAllCouncilByDoctor(int doctorId)
        {
            return Ok(_doctorService.GetAllCouncilByDoctor(doctorId));
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
    }
}