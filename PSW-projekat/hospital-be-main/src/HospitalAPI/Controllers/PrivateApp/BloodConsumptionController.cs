using HospitalAPI.Adapters;
using HospitalAPI.DTO;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Model.Enums;
using HospitalLibrary.Core.Service;
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
        private readonly IDoctorService _doctorService;


        public BloodConsumptionController(IBloodConsumptionService bloodConsumptionService, IDoctorService doctorService)
        {
            this._bloodConsumptionService = bloodConsumptionService;
            this._doctorService = doctorService;
        }

        public ActionResult Create(BloodConsumptionDTO bloodConsumptionDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            DoctorBloodConsumption bloodConsumption = BloodConsumptionAdapter.FromDTO(bloodConsumptionDTO);
            try
            {
              //  bloodConsumption.DoctorId = new Doctor();//_doctorService.GetById(bloodConsumptionDTO.DoctorId);
                _bloodConsumptionService.Create(bloodConsumption);
                return Ok(bloodConsumption);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
