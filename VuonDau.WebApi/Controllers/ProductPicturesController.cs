using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;
using VuonDau.Business.Requests.ProductPicture;
using VuonDau.Data.Models;

namespace VuonDau.WebApi.Controllers
{
    public partial class ProductPicturesController : ControllerBase
    {
        /// Get List ProductPictures
        [HttpGet]
        [Route("~/api/v1/product-pictures")]
        [SwaggerOperation(Tags = new[] { "ProductPictures" })]
        public async Task<IActionResult> GetProductPictures()
        {
            await _productPictureService.GetAllProductPictures();
            var productPictures = await _productPictureService.GetAllProductPictures();
            return Ok(productPictures);
        }

        /// Get ProductPicture by id
        [HttpGet]
        [Route("~/api/v1/product-pictures/{id:Guid}")]
        [SwaggerOperation(Tags = new[] { "ProductPictures" })]
        public async Task<IActionResult> GetProductPicture([FromRoute] Guid id)
        {
            var productPictures = await _productPictureService.GetProductPictureById(id);
            if (productPictures == null)
            {
                return NotFound("NOT_FOUND_MESSAGE");
            }
            return Ok(productPictures);
        }
        /// Tạo mới 1 productPicture
        [HttpPost]
        [Route("~/api/v1/product-pictures")]
        [SwaggerOperation(Tags = new[] { "ProductPictures" })]
        public async Task<IActionResult> CreateProductPicture([FromBody] CreateProductPictureRequest request)
        {
            var productPicture = await _productPictureService.CreateProductPicture(request);
            if (productPicture == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "INTERNAL_SERVER_ERROR");
            }

            return Created(nameof(CreateProductPicture), productPicture);
        }
        /// Cập nhập 1 productPicture
        [HttpPut]
        [Route("~/api/v1/product-pictures/{id:Guid}")]
        [SwaggerOperation(Tags = new[] { "ProductPictures" })]
        public async Task<IActionResult> UpdateProductPicture([FromRoute] Guid id, UpdateProductPictureRequest request)
        {
            var productPicture = await _productPictureService.UpdateProductPicture(id, request);
            if (productPicture == null)
            {
                return NotFound("Message");
            }

            return Ok(productPicture);
        }

        /// Xóa 1 productPictureer qua id
        [HttpDelete]
        [Route("~/api/v1/product-pictures/{id:Guid}")]
        [SwaggerOperation(Tags = new[] { "ProductPictures" })]
        public async Task<IActionResult> DeleteProductPicture([FromRoute] Guid id)
        {
            var resultInt = await _productPictureService.DeleteProductPicture(id);
            if (resultInt != 1)
            {
                return BadRequest("BAD_REQUEST");
            }

            return NoContent();
        }
    }
}
