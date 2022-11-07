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
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        //[Authorize(Roles = "Manager")]
        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_userService.GetAll());
        }


        [HttpGet("patient/")]
        public ActionResult GetAllPatients()
        {
            return Ok(_userService.GetAllPatients());

        }

        [HttpGet("doctor/")]
        public ActionResult GetAllDoctors()
        {
            return Ok(_userService.GetAllDoctors());

        }
    }
}
