using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;
using VuonDau.Business.Requests.CustomerType;
using VuonDau.Data.Models;

namespace VuonDau.WebApi.Controllers
{
    public partial class CustomerTypesController : ControllerBase
    {
        /// <summary>
        /// Get List Customer
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("~/api/v1/customer-types")]
        [SwaggerOperation(Tags = new[] { "CustomerTypes" })]
        public async Task<IActionResult> GetCustomerTypes()
        {
            await _customerTypeService.GetAllCustomerTypes();
            var customerTypes = await _customerTypeService.GetAllCustomerTypes();
            return Ok(customerTypes);
        }

        /// <summary>
        /// Get Customer by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("~/api/v1/customer-types/{id:Guid}")]
        [SwaggerOperation(Tags = new[] { "CustomerTypes" })]
        public async Task<IActionResult> GetCustomerType([FromRoute] Guid id)
        {
            var customerType = await _customerTypeService.GetCustomerTypeById(id);
            if (customerType == null)
            {
                return NotFound("NOT_FOUND_MESSAGE");
            }

            return Ok(customerType);
        }

        /// <summary>
        /// Tạo mới 1 Customer
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("~/api/v1/customer-types")]
        [SwaggerOperation(Tags = new[] { "CustomerTypes" })]
        public async Task<IActionResult> CreateCustomerType([FromBody] CreateCustomerTypeRequest request)
        {
            var customerType = await _customerTypeService.CreateCustomerType(request);
            if (customerType == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "INTERNAL_SERVER_ERROR");
            }

            return Created(nameof(CreateCustomerType), customerType);
        }

        /// <summary>
        /// Cập nhập 1 Customer
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("~/api/v1/customer-types/{id:Guid}")]
        [SwaggerOperation(Tags = new[] { "CustomerTypes" })]
        public async Task<IActionResult> UpdateCustomerType([FromRoute] Guid id, UpdateCustomerTypeRequest request)
        {
            var customerType = await _customerTypeService.UpdateCustomerType(id, request);
            if (customerType == null)
            {
                return NotFound("Message");
            }

            return Ok(customerType);
        }

        /// <summary>
        /// Xóa 1 Customer qua id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("~/api/v1/customer-types/{id:Guid}")]
        [SwaggerOperation(Tags = new[] { "CustomerTypes" })]
        public async Task<IActionResult> DeleteCustomerType([FromRoute] Guid id)
        {
            var resultInt = await _customerTypeService.DeleteCustomerType(id);
            if (resultInt != 1)
            {
                return BadRequest("BAD_REQUEST");
            }

            return NoContent();
        }
    }
}
