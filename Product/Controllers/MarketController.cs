using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Product.Application.DTO;
using Product.Application.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Product.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class MarketController : ControllerBase
    {

        private readonly IMarketService _marketService;

        public MarketController(IMarketService marketService)
        {
            _marketService = marketService;
        }


        // GET: api/<MarketController>
        [HttpGet]
        [Route("List")]
        public async Task<ActionResult<IEnumerable<MarketDTO>>> GetAll()
        {
            var result = await _marketService.GetAllAsync();

            return result.Response.ToList();
        }

        // GET api/<MarketController>/5
        [HttpGet]
        [Route("Details")]
        public async Task<ActionResult<MarketDTO>> Get(int id)
        {
            var result = await _marketService.GetByIDAsync(id);
            return result.Response;
        }

        // POST api/<MarketController>
        [HttpPost]
        [Route("CreateRecord")]
        public async Task<ActionResult<MarketDTO>> Post(MarketDTO value)
        {
            var result = await _marketService.AddAsync(value);
            //return result.Response;
            return CreatedAtAction(nameof(Get), new { id = result.Response.MarketID }, result.Response);
        }

        // PUT api/<MarketController>/5
        [HttpPost]
        [Route("UpdateProduct")]
        public async Task<ActionResult<IEnumerable<MarketDTO>>> Put(int id, MarketDTO value)
        {
            if (id != value.MarketID)
            {
                return BadRequest();
            }

            //var productData = await _productService.CheckByIDAsync(id);
            //if (productData == null)
            //{
            //    return NotFound();
            //}

            await _marketService.UpdateAsync(value);
            var result = await _marketService.GetAllAsync();
            return result.Response.ToList();

        }

        // DELETE api/<MarketController>/5
        [HttpPost]
        [Route("DeleteProduct")]
        public async Task<ActionResult<IEnumerable<MarketDTO>>> Delete(int id)
        {
            var productData = await _marketService.GetByIDAsync(id);
            if (productData == null)
            {
                return NotFound();
            }

            await _marketService.DeleteAsync(id);
            var result = await _marketService.GetAllAsync();
            return result.Response.ToList();



        }
    }
}
