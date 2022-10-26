using IntegrationAPI.Adapters;
using IntegrationAPI.Controllers.Interfaces;
using IntegrationAPI.DTO;
using IntegrationLibrary.Core.Service.CRUD;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace IntegrationAPI.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class BloodBanksController : ControllerBase , ICRUDController<BloodBankDTO>
    {
        private readonly IBloodBankService _bloodBankService;

        public BloodBanksController(IBloodBankService bloodBankService)
        {
            _bloodBankService = bloodBankService;
        }

        [HttpPost]
        public ActionResult Create(BloodBankDTO entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var bank = BloodBankAdapter.FromDTO(entity);
            try
            {
                _bloodBankService.Create(bank);
                return CreatedAtAction("GetById", new { id = bank.Id }, bank);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var bloodBank = _bloodBankService.GetById(id);
            if (bloodBank == null)
            {
                return NotFound();
            }
            _bloodBankService.Delete(bloodBank);
            return NoContent();
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_bloodBankService.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var bloodBank = _bloodBankService.GetById(id);
            if(bloodBank == null)
            {
                return NotFound();
            }

            return Ok(bloodBank);
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id ,BloodBankDTO entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if(id != entity.Id)
            {
                return BadRequest();
            }
            try
            {
                _bloodBankService.Update(BloodBankAdapter.FromDTO(entity));
            }
            catch
            {
                return BadRequest();
            }
            return Ok(entity);
        }
    }
}
