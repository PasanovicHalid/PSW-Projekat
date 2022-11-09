using HospitalLibrary.Core.Service;
using HospitalLibrary.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<SecUser> _userManager;

        public UserController(IUserService userService, UserManager<SecUser> userManager)
        {
            _userService = userService;
            _userManager = userManager;
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

        [HttpGet("userInfo/")]
        public ActionResult GetUserInfo()
        {
            var id = User.Claims.GetUserId();

            return Ok(_userService.GetById(id));
        }
    }
}
