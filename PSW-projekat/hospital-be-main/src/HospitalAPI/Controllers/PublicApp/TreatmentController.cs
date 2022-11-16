using System;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Service;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controllers.PublicApp
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class TreatmentController : ControllerBase
    {
        private readonly ITreatmentService _treatmentService;
        private readonly IPatientService _patientService;
        private readonly IRoomService _roomService;
        private ITreatmentService treatmentService;

        public TreatmentController(ITreatmentService treatmentService, IPatientService patientService, IRoomService roomService)
        {
            _treatmentService = treatmentService;
            _patientService = patientService;
            _roomService = roomService;

        }

        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_treatmentService.GetAll());
        }

        [HttpPost]
        public ActionResult Create(Treatment treatment)
        {
            treatment.Patient = _patientService.GetById(treatment.Patient.Id);
            treatment.Room = _roomService.GetById(treatment.Room.Id);


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _treatmentService.Create(treatment);
            return Ok();

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
