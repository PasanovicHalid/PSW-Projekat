using IntegrationLibrary.Core.Model;
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
        public ScheduledOrderController(IScheduledOrderService scheduledOrderService)
        {
            _scheduledOrderService = scheduledOrderService;
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
                _scheduledOrderService.Create(entity);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
