using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Product.Application.DTO;
using Product.Application.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Product.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class PriceController : ControllerBase
    {
        private readonly IPriceService _priceService;

        public PriceController(IPriceService priceService)
        {
            _priceService = priceService;
        }

        // GET: api/<PriceController>
        
        [HttpGet]
        [Route("List")]
        public async Task<ActionResult<IEnumerable<PriceDTO>>> GetAll()
        {
            var result = await _priceService.GetAllAsync();

            return result.Response.ToList();
        }

        // GET api/<PriceController>/5
        [HttpGet]
        [Route("Details")]
        public async Task<ActionResult<PriceDTO>> Get(int id)
        {
            var result = await _priceService.GetByIDAsync(id);
            return result.Response;
        }

        // POST api/<PriceController>
        [HttpPost]
        [Route("CreateRecord")]
        public async Task<ActionResult<PriceDTO>> Post(PriceDTO value)
        {
            var result = await _priceService.AddAsync(value);
            //return result.Response;
            return CreatedAtAction(nameof(Get), new { id = result.Response.PriceID }, result.Response);
        }

        // PUT api/<PriceController>/5
        [HttpPost]
        [Route("UpdateProduct")]
        public async Task<ActionResult<IEnumerable<PriceDTO>>> Put(int id, PriceDTO value)
        {
            if (id != value.ProductID)
            {
                return BadRequest();
            }

            await _priceService.UpdateAsync(value);
            var result = await _priceService.GetAllAsync();
            return result.Response.ToList();

        }

        // DELETE api/<PriceController>/5

        [HttpPost]
        [Route("DeleteProduct")]
        public async Task<ActionResult<IEnumerable<PriceDTO>>> Delete(int id)
        {
            var productData = await _priceService.GetByIDAsync(id);
            if (productData == null)
            {
                return NotFound();
            }

            await _priceService.DeleteAsync(id);
            var result = await _priceService.GetAllAsync();
            return result.Response.ToList();



        }

    }
}
