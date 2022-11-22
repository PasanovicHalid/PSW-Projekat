using System;
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
    public class TreatmentController : ControllerBase
    {
        private readonly ITreatmentService _treatmentService;

        public TreatmentController(ITreatmentService treatmentService)
        {
            _treatmentService = treatmentService;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_treatmentService.GetAll());
        }

        [HttpPost]
        public ActionResult Create(Treatment treatment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _treatmentService.Create(treatment);
            return CreatedAtAction("GetById", new { id = treatment.Id }, treatment);

        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var treatment = _treatmentService.GetById(id);
            if (treatment == null)
            {
                return NotFound();
            }

            _treatmentService.Delete(treatment);
            return NoContent();
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var treatment = _treatmentService.GetById(id);
            if (treatment == null)
            {
                return NotFound();
            }

            return Ok(treatment);
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, Treatment treatment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != treatment.Id)
            {
                return BadRequest();
            }
            try
            {
                _treatmentService.Update(treatment);
            }
            catch (Exception ex)
            {
                //return BadRequest();
                return BadRequest(ex.Message);

            }

            return Ok(treatment);
        }
    }
}
