using HospitalLibrary.Core.DTOs;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Model.Enums;
using HospitalLibrary.Core.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controllers.PrivateApp
{
    [Authorize]
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

        [Authorize(Roles = "Manager")]
        [HttpGet]
        public ActionResult GetAllFeedbackDtos()
        {
            return Ok(_feedbackService.GetAllFeedbackDtos());
        }

        [Authorize(Roles = "Manager")]
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

        [Authorize(Roles = "Manager")]
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
