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
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        //[Authorize(Roles = "Manager")]
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
    }
}
