using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;
using VuonDau.Business.Requests.Farmer;
using VuonDau.Data.Models;

namespace VuonDau.WebApi.Controllers
{
    public partial class ProductsController : ControllerBase
    {
        // GET: Products
        [HttpGet]
        [Route("~/api/products")]
        [SwaggerOperation(Tags = new[] { "Products" })]
        public async Task<IActionResult> GetProducts()
        {
            await _productService.GetAllProducts();
            var products = await _productService.GetAllProducts();
            return Ok(products);
        }

        // GET: Products/Details/5
        [HttpGet]
        [Route("~/api/products/{id:Guid}")]
        [SwaggerOperation(Tags = new[] { "Products" })]
        public async Task<IActionResult> GetProduct([FromRoute] Guid id)
        {
            var farmer = await _productService.GetProductById(id);
            if (farmer == null)
            {
                return NotFound("NOT_FOUND_MESSAGE");
            }

            return Ok(farmer);
        }

        // GET: Products/Create
        [HttpPost]
        [Route("~/api/products")]
        [SwaggerOperation(Tags = new[] { "Products" })]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductRequest request)
        {
            var product = await _productService.CreateProduct(request);
            if (product == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "INTERNAL_SERVER_ERROR");
            }

            return Created(nameof(CreateProduct), product);
        }

        /// <summary>
        /// Cập nhập 1 product
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("~/api/products/{id:Guid}")]
        [SwaggerOperation(Tags = new[] { "Products" })]
        public async Task<IActionResult> UpdateFarmer([FromRoute] Guid id, UpdateProductRequest request)
        {
            var product = await _productService.UpdateProduct(id, request);
            if (product == null)
            {
                return NotFound("Message");
            }

            return Ok(product);
        }

        /// <summary>
        /// Xóa 1 product qua id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("~/api/products/{id:Guid}")]
        [SwaggerOperation(Tags = new[] { "Products" })]
        public async Task<IActionResult> DeleteProduct([FromRoute] Guid id)
        {
            var resultInt = await _productService.DeleteProduct(id);
            if (resultInt != 1)
            {
                return BadRequest("BAD_REQUEST");
            }

            return NoContent();
        }
    }
}
