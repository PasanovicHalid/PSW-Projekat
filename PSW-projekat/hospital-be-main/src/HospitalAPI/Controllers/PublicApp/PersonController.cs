using HospitalLibrary.Core.Model.Enums;
using HospitalLibrary.Core.Service;
using HospitalLibrary.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace HospitalAPI.Controllers.PublicApp
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {

        private readonly UserManager<SecUser> _userManager;
        private readonly PersonService _personService;

        public PersonController(PersonService personService, UserManager<SecUser> userManager)
        {
            _personService = personService;
            _userManager = userManager;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_personService.GetAll());
        }


        [HttpGet("patient/")]
        public ActionResult GetAllPatients()
        {
            return Ok(_personService.GetAllPatients());

        }

        [HttpGet("doctor/")]
        public ActionResult GetAllDoctors()
        {
            return Ok(_personService.GetAllDoctors());
        }

        [Authorize(Roles="Admin")]
        [HttpGet("userInfo/")]
        public ActionResult GetUserInfo()
        {
            var id = User.Claims.GetUserId();

            return Ok(_personService.GetById(id));
        }
    }
}
