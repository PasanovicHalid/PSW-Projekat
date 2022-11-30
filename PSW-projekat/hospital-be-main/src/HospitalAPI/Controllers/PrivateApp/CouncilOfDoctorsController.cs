using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Service.CouncilOfDoctors;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Controllers.PrivateApp
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class CouncilOfDoctorsController : ControllerBase
    {
        private readonly ICouncilOfDoctorsService _councilOfDoctorsService;

        public CouncilOfDoctorsController(ICouncilOfDoctorsService councilOfDoctorsService)
        {
            this._councilOfDoctorsService = councilOfDoctorsService;
        }

        [HttpPost]
        public ActionResult Create(DoctorsCouncil testCase)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _councilOfDoctorsService.Create(testCase);
                return Ok(testCase);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}

