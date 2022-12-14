
using IntegrationLibrary.Core.Model.Tender;
using IntegrationLibrary.Core.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;

namespace IntegrationAPI.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class BidController : Controller
    {
        private readonly IBidService _bidService;

        public BidController(IBidService bidService)
        {
            _bidService = bidService;
        }

        [HttpPost]
        public ActionResult Create(Bid entity)
        {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        try
        {
            _bidService.Create(entity);
            return Ok(entity);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
        }   
    [HttpGet("{id}")]
    public ActionResult GetById(int id)
    {
        try
        {
            Bid bid = _bidService.GetById(id);
            if (bid == null)
            {
                return NotFound();
            }

            return Ok(bid);
        }
        catch
        {
            return BadRequest();
        }
    }

    [HttpGet]
    public ActionResult GetAll()
    {
        try
        {
            return Ok(_bidService.GetAll());
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }


        [HttpGet("Tender/{id}")]
        public ActionResult GetByTenderId(int id)
        {
            try
            {
                return Ok(_bidService.GetByTenderId(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("CloseTender")]
        public ActionResult SelectWinner(Bid bid)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _bidService.SelectWinner(bid.Id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
