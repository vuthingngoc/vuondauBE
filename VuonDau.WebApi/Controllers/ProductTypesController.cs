using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Reso.Core.Extension;
using Swashbuckle.AspNetCore.Annotations;
using VuonDau.Business.Requests.ProductType;
using VuonDau.Business.ViewModel;
using VuonDau.Data.Models;

namespace VuonDau.WebApi.Controllers
{
    public partial class ProductTypesController : ControllerBase
    {
        /// <summary>
        /// Get List Product
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("~/api/v1/product-types")]
        [SwaggerOperation(Tags = new[] { "ProductTypes" })]
        public async Task<IActionResult> GetProductTypes([FromQuery] ProductTypeViewModel filter)
        {
            List<ProductTypeViewModel> rs;
            _memoryCache.TryGetValue(PRODUCTTYPE_CACHE, out rs);
            if (rs != null)
            {
                return Ok(rs);
            }
            try
            {
                rs = await _distributedCache.GetAsync<List<ProductTypeViewModel>>(PRODUCTTYPE_CACHE);
            }
            catch (Exception)
            {
                throw;
            }
            if (rs != null)
            {
                return Ok(rs);
            }
            var ProductTypes = await _productTypeService.GetAllProductTypes(filter);
            rs = ProductTypes;
            _memoryCache.Set(PRODUCTTYPE_CACHE, rs);
            try
            {
                await _distributedCache.SetObjectAsync(PRODUCTTYPE_CACHE, rs);
            }
            catch (Exception)
            {
            }
            return Ok(rs);
            //var productTypes = await _productTypeService.GetAllProductTypes(filter);
            //return Ok(productTypes);
        }

        /// <summary>
        /// Get Product by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("~/api/v1/product-types/{id:Guid}")]
        [SwaggerOperation(Tags = new[] { "ProductTypes" })]
        public async Task<IActionResult> GetProductType([FromRoute] Guid id)
        {
            var productType = await _productTypeService.GetProductTypeById(id);
            if (productType == null)
            {
                return NotFound("NOT_FOUND_MESSAGE");
            }

            return Ok(productType);
        }

        /// <summary>
        /// Tạo mới 1 Product
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("~/api/v1/product-types")]
        [SwaggerOperation(Tags = new[] { "ProductTypes" })]
        public async Task<IActionResult> CreateProductType([FromBody] CreateProductTypeRequest request)
        {
            var productType = await _productTypeService.CreateProductType(request);
            if (productType == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "INTERNAL_SERVER_ERROR");
            }

            return Created(nameof(CreateProductType), productType);
        }

        /// <summary>
        /// Cập nhập 1 Product
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("~/api/v1/product-types/{id:Guid}")]
        [SwaggerOperation(Tags = new[] { "ProductTypes" })]
        public async Task<IActionResult> UpdateProductType([FromRoute] Guid id, UpdateProductTypeRequest request)
        {
            var productType = await _productTypeService.UpdateProductType(id, request);
            if (productType == null)
            {
                return NotFound("Message");
            }

            return Ok(productType);
        }

        /// <summary>
        /// Xóa 1 Product qua id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("~/api/v1/product-types/{id:Guid}")]
        [SwaggerOperation(Tags = new[] { "ProductTypes" })]
        public async Task<IActionResult> DeleteProductType([FromRoute] Guid id)
        {
            var resultInt = await _productTypeService.DeleteProductType(id);
            if (resultInt != 1)
            {
                return BadRequest("BAD_REQUEST");
            }

            return NoContent();
        }
    }
}
