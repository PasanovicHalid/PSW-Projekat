using HospitalLibrary.Core.DTOs;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Service;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
namespace HospitalAPI.Controllers.PublicApp
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class BedController : ControllerBase
    {
        private readonly IBedService _bedService;
        private readonly IPatientService _patientService;


        public BedController(IBedService bedService, IPatientService patientService)
        {
            _bedService = bedService;
            _patientService = patientService;
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var room = _bedService.GetById(id);
            if (room == null)
            {
                return NotFound();
            }

            return Ok(room);
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, BedDto bedDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bedDto.Id)
            {
                return BadRequest();
            }

            Bed bed = _bedService.GetById(bedDto.Id);
            bed.Name = bedDto.Name;
            bed.BedState = HospitalLibrary.Core.Model.Enums.BedState.taken;
            bed.Quantity = bedDto.Quantity;
            bed.Patient = _patientService.GetById(bedDto.PatientDto.Id);

            try
            {
                _bedService.Update(bed);
            }
            catch
            {
                return BadRequest();

            }

            return Ok(bed);
        }


    }
}
