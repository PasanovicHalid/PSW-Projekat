using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Core.Service.BloodBanks;
using IntegrationLibrary.Core.Service.ScheduledOrders;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;

namespace IntegrationAPI.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduledOrderController : ControllerBase
    {
        private readonly IScheduledOrderService _scheduledOrderService;
        private readonly IBloodBankService _bloodBankService;
        public ScheduledOrderController(IScheduledOrderService scheduledOrderService,
            IBloodBankService bloodBankService)
        {
            _scheduledOrderService = scheduledOrderService;
            _bloodBankService = bloodBankService;
        }
        [HttpGet]
        public ActionResult GetAll()
        {
            try
            {
                return Ok(_scheduledOrderService.GetAll());
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public ActionResult Create(ScheduledOrder entity)
        {
            try
            {
                foreach(BloodBank bb in _bloodBankService.GetAll())
                {
                    if (entity.BankEmail.Equals(bb.Email.EmailAddress))
                    {
                        entity.BankApiKey = bb.ApiKey;
                    }
                }
                _scheduledOrderService.Create(entity);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("/testGetOrder")]
        public ActionResult TestGetOrder()
        {
            try
            {
                _scheduledOrderService.ReadOrederedBlood();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
