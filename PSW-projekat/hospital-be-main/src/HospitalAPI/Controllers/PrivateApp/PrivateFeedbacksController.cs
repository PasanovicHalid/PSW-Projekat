using HospitalLibrary.Core.DTOs;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Model.Enums;
using HospitalLibrary.Core.Service;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controllers.PrivateApp
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class PrivateFeedbacksController : ControllerBase
    {
        private readonly FeedbackService _feedbackService;

        public PrivateFeedbacksController(FeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }

        [HttpGet]
        public ActionResult GetAllFeedbackDtos()
        {
            return Ok(_feedbackService.GetAllFeedbackDtos());
        }

        [HttpPut("approve")]
        public ActionResult Approve(FeedbackDto feedbackDto)
        {
            Feedback feedback = _feedbackService.GetById(feedbackDto.FeedbackId);
            if(feedback == null || feedback.Status == FeedbackStatus.Approved)
                return BadRequest();
            feedback.Status = FeedbackStatus.Approved;
            _feedbackService.Update(feedback);
            return Ok(feedbackDto);
        }

        [HttpPut("reject")]
        public ActionResult Reject(FeedbackDto feedbackDto)
        {
            Feedback feedback = _feedbackService.GetById(feedbackDto.FeedbackId);
            if (feedback == null || feedback.Status == FeedbackStatus.Rejected)
                return BadRequest();
            feedback.Status = FeedbackStatus.Rejected;
            _feedbackService.Update(feedback);
            return Ok(feedbackDto);
        }
    }
}
