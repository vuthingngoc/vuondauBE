using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;
using VuonDau.Business.Requests.CustomerGroup;
using VuonDau.Business.ViewModel;
using VuonDau.Data.Models;

namespace VuonDau.WebApi.Controllers
{
    public partial class CustomerGroupsController : ControllerBase
    {
        /// <summary>
        /// Get List Customer
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("~/api/v1/customer-groups")]
        [SwaggerOperation(Tags = new[] { "CustomerGroups" })]
        public async Task<IActionResult> GetCustomerGroups([FromQuery] SearchCustomerGroupRequest request)
        {
            var customerGroups = await _customerGroupService.GetAllCustomerGroups(request);
            return Ok(customerGroups);
        }

        /// <summary>
        /// Get Customer by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("~/api/v1/customer-groups/{id:Guid}")]
        [SwaggerOperation(Tags = new[] { "CustomerGroups" })]
        public async Task<IActionResult> GetCustomerGroup([FromRoute] Guid id)
        {
            var customerGroup = await _customerGroupService.GetCustomerGroupById(id);
            if (customerGroup == null)
            {
                await _customerGroupService.GetCustomerGroupByHarvestSellingId(id);
                var customerGroups = await _customerGroupService.GetCustomerGroupByHarvestSellingId(id);
                if (customerGroups.Count > 0)
                {
                    return Ok(customerGroups);
                }
                else
                {
                    return NotFound("NOT_FOUND_MESSAGE");
                }
            }

            return Ok(customerGroup);
        }

        /// <summary>
        /// Tạo mới 1 Customer
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("~/api/v1/customer-groups")]
        [SwaggerOperation(Tags = new[] { "CustomerGroups" })]
        public async Task<IActionResult> CreateCustomerGroup([FromBody] CreateCustomerGroupRequest request)
        {
            var customerGroup = await _customerGroupService.CreateCustomerGroup(request);
            if (customerGroup == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "INTERNAL_SERVER_ERROR");
            }

            return Created(nameof(_customerGroupService), customerGroup);
        }

        /// <summary>
        /// Cập nhập 1 Customer
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("~/api/v1/customer-groups/{id:Guid}")]
        [SwaggerOperation(Tags = new[] { "CustomerGroups" })]
        public async Task<IActionResult> UpdateCustomerGroup([FromRoute] Guid id, UpdateCustomerGroupRequest request)
        {
            var customerGroup = await _customerGroupService.UpdateCustomerGroup(id, request);
            if (customerGroup == null)
            {
                return NotFound("Message");
            }

            return Ok(customerGroup);
        }

        /// <summary>
        /// Xóa 1 Customer qua id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("~/api/v1/customer-groups/{id:Guid}")]
        [SwaggerOperation(Tags = new[] { "CustomerGroups" })]
        public async Task<IActionResult> DeleteCustomerGroup([FromRoute] Guid id)
        {
            var resultInt = await _customerGroupService.DeleteCustomerGroup(id);
            if (resultInt != 1)
            {
                return BadRequest("BAD_REQUEST");
            }

            return NoContent();
        }
    }
}
