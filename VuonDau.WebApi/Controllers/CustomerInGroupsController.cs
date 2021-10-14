using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VuonDau.Data.Models;
using Swashbuckle.AspNetCore.Annotations;
using VuonDau.Business.Requests.CustomerInGroup;



namespace VuonDau.WebApi.Controllers
{
    public partial class CustomerInGroupsController : ControllerBase
    {
        /// <summary>
        /// Get List Customer
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("~/api/v1/customer-in-groups")]
        [SwaggerOperation(Tags = new[] { "CustomerInGroups" })]
        public async Task<IActionResult> GetCustomerInGroups()
        {
            await _customerInGroupService.GetAllCustomerInGroups();
            var customerInGroups = await _customerInGroupService.GetAllCustomerInGroups();
            return Ok(customerInGroups);
        }

        /// <summary>
        /// Get Customer by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("~/api/v1/customer-in-groups/{id:Guid}")]
        [SwaggerOperation(Tags = new[] { "CustomerInGroups" })]
        public async Task<IActionResult> GetCustomerInGroup([FromRoute] Guid id)
        {
            var customerInGroup = await _customerInGroupService.GetCustomerInGroupById(id);
            if (customerInGroup == null)
            {
                return NotFound("NOT_FOUND_MESSAGE");
            }

            return Ok(customerInGroup);
        }

        /// <summary>
        /// Tạo mới 1 Customer
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("~/api/v1/customer-in-groups")]
        [SwaggerOperation(Tags = new[] { "CustomerInGroups" })]
        public async Task<IActionResult> CreateCustomerInGroup([FromBody] CreateCustomerInGroupRequest request)
        {
            var customerInGroup = await _customerInGroupService.CreateCustomerInGroup(request);
            if (customerInGroup == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "INTERNAL_SERVER_ERROR");
            }

            return Created(nameof(_customerInGroupService), customerInGroup);
        }

        /// <summary>
        /// Cập nhập 1 Customer
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("~/api/v1/customer-in-groups/{id:Guid}")]
        [SwaggerOperation(Tags = new[] { "CustomerInGroups" })]
        public async Task<IActionResult> UpdateCustomerInGroup([FromRoute] Guid id, UpdateCustomerInGroupRequest request)
        {
            var customerInGroup = await _customerInGroupService.UpdateCustomerInGroup(id, request);
            if (customerInGroup == null)
            {
                return NotFound("Message");
            }

            return Ok(customerInGroup);
        }

        /// <summary>
        /// Xóa 1 Customer qua id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("~/api/v1/customer-in-groups/{id:Guid}")]
        [SwaggerOperation(Tags = new[] { "CustomerInGroups" })]
        public async Task<IActionResult> DeleteCustomerInGroup([FromRoute] Guid id)
        {
            var resultInt = await _customerInGroupService.DeleteCustomerInGroup(id);
            if (resultInt != 1)
            {
                return BadRequest("BAD_REQUEST");
            }

            return NoContent();
        }
    }
}
