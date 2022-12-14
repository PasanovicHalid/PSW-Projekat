using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Service.Notification;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controllers.PrivateApp
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;

        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            try
            {
                return Ok(_notificationService.GetAll());
            } catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            try
            {
                return Ok(_notificationService.GetById(id));

            } catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public ActionResult Create(Notification notification)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _notificationService.Create(notification);
                return Ok();
            } catch
            {
                return BadRequest();
            }
        }
    }
}
