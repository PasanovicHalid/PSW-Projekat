using IntegrationLibrary.Core.Service.EmergencyBloodRequests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace IntegrationAPI.Controllers
{
    [Authorize(Roles = "Manager")]
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class EmergencyBloodRequestController : ControllerBase
    {
        private readonly IEmergencyBloodRequestService _emergencyBloodRequestService;

        public EmergencyBloodRequestController(IEmergencyBloodRequestService emergencyBloodRequestService)
        {
            _emergencyBloodRequestService = emergencyBloodRequestService;
        }

        [HttpPost]
        public ActionResult RequestEmergencyBlood(string value)
        {
            throw new NotImplementedException();
        }

    }
}
