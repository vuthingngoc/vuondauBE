using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;
using VuonDau.Business.Requests.ProductInCart;
using VuonDau.Data.Models;

namespace VuonDau.WebApi.Controllers
{
    public partial class ProductInCartsController : ControllerBase
    {
        // GET: ProductInCarts
        [HttpGet]
        [Route("~/api/v1/productInCarts")]
        [SwaggerOperation(Tags = new[] { "ProductInCarts" })]
        public async Task<IActionResult> GetProductInCarts()
        {
            await _productInCartService.GetAllProductInCarts();
            var productInCarts = await _productInCartService.GetAllProductInCarts();
            return Ok(productInCarts);
        }

        // GET: ProductInCarts/Details/5
        [HttpGet]
        [Route("~/api/v1/productInCarts/{id:Guid}")]
        [SwaggerOperation(Tags = new[] { "ProductInCarts" })]
        public async Task<IActionResult> GetProductInCart([FromRoute] Guid id)
        {
            var poductInCart = await _productInCartService.GetProductInCartById(id);
            if (poductInCart == null)
            {
                return NotFound("NOT_FOUND_MESSAGE");
            }

            return Ok(poductInCart);
        }

        // GET: ProductInCarts/Create
        [HttpPost]
        [Route("~/api/v1/productInCarts")]
        [SwaggerOperation(Tags = new[] { "ProductInCarts" })]
        public async Task<IActionResult> CreateProductInCart([FromBody] CreateProductInCartRequest request)
        {
            var productInCart = await _productInCartService.CreateProductInCart(request);
            if (productInCart == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "INTERNAL_SERVER_ERROR");
            }

            return Created(nameof(CreateProductInCart), productInCart);
        }

        /// <summary>
        /// Cập nhập 1 productInCart
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        //[HttpPut]
        //[Route("~/api/v1/productInCarts/{id:Guid}")]
        //[SwaggerOperation(Tags = new[] { "ProductInCarts" })]
        //public async Task<IActionResult> UpdateProductInCart([FromRoute] Guid id, UpdateProductInCartRequest request)
        //{
        //    var productInCart = await _productInCartService.UpdateProductInCart(id, request);
        //    if (productInCart == null)
        //    {
        //        return NotFound("Message");
        //    }

        //    return Ok(productInCart);
        //}

        /// <summary>
        /// Xóa 1 productInCart qua id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("~/api/v1/productInCarts/{id:Guid}")]
        [SwaggerOperation(Tags = new[] { "ProductInCarts" })]
        public async Task<IActionResult> DeleteProductInCart([FromRoute] Guid id)
        {
            var resultInt = await _productInCartService.DeleteProductInCart(id);
            if (resultInt != 1)
            {
                return BadRequest("BAD_REQUEST");
            }

            return NoContent();
        }
    }
}
