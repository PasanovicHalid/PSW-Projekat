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
    public class StatisticsController : ControllerBase
    {
        private readonly IUserService _userService;

        public StatisticsController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public ActionResult GetAllFeedbackDtos()
        {
            //TODO vraca DTO sa statistikom
            return Ok();
        }

    }
}
