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
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }


        // GET: api/<ProductController>
        [HttpGet]
        [Route("List")]
        public async Task<ActionResult< IEnumerable<ProductDTO>>> GetAll()
        {
            var result = await _productService.GetAllAsync();

            return result.Response.ToList();
        }

        // GET api/<ProductController>/5
        [HttpGet]
        [Route("Details")]
        public async Task<ActionResult<ProductDTO>>  Get(int id)
        {
            var result= await _productService.GetByIDAsync(id);
            return result.Response;
        }

        // POST api/<ProductController>
        [HttpPost]
        [Route ("CreateRecord")]
        public async Task<ActionResult<ProductDTO>> Post(ProductDTO value)
        {
           var result= await _productService.AddAsync(value);
            //return result.Response;
            return CreatedAtAction(nameof(Get), new { id = result.Response.ProductID }, result.Response);
        }

        // PUT api/<ProductController>/5
        [HttpPost]
        [Route("UpdateProduct")]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> Put(int id, ProductDTO value)
        {
            if(id!= value.ProductID)
            {
                return BadRequest();
            }


            await _productService.UpdateAsync(value);
            var result = await _productService.GetAllAsync();
                return result.Response.ToList();

        }

        // DELETE api/<ProductController>/5
        [HttpPost]
        [Route ("DeleteProduct")]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> Delete(int id)
        {
             var productData = await _productService.GetByIDAsync(id);
            if (productData == null)
            {
               return NotFound();
            }

            await _productService.DeleteAsync(id);
            var result = await _productService.GetAllAsync();
            return result.Response.ToList();



        }
    }
}
