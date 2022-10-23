using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Service;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbacksController : Controller
    {
        private readonly IService<Feedback> _feedbackService;

        public FeedbacksController(IService<Feedback> feedbackService)
        {
            _feedbackService = feedbackService;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_feedbackService.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var feedback = _feedbackService.GetById(id);
            if (feedback == null)
            {
                return NotFound();
            }

            return Ok(feedback);
        }

        [HttpPost]
        public ActionResult Create(Feedback feedback)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _feedbackService.Create(feedback);
            return CreatedAtAction("GetById", new { id = feedback.FeedbackId }, feedback);
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, Feedback feedback)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != feedback.FeedbackId)
            {
                return BadRequest();
            }

            try
            {
                _feedbackService.Update(feedback);
            }
            catch
            {
                return BadRequest();
            }

            return Ok(feedback);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var room = _feedbackService.GetById(id);
            if (room == null)
            {
                return NotFound();
            }

            _feedbackService.Delete(room);
            return NoContent();
        }
    }
}
