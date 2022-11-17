using HospitalAPI.DTO;
using HospitalLibrary.Core.Service.BloodConsumption;
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
    public class BloodConsumptionController : ControllerBase
    {
        private readonly IBloodConsumptionService _bloodConsumptionService;


        public BloodConsumptionController(IBloodConsumptionService bloodConsumptionService)
        {
            this._bloodConsumptionService = bloodConsumptionService;
        }

        public ActionResult Create(BloodConsumptionDTO bloodConsumptionDTO)
        {
            throw new NotImplementedException();
        }
    }
}
