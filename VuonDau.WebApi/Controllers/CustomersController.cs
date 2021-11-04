using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;
using VuonDau.Business.Requests;
using VuonDau.Business.Requests.Customer;
using VuonDau.Business.ViewModel;
using VuonDau.Data.Models;

namespace VuonDau.WebApi.Controllers
{
    public partial class CustomersController : ControllerBase
    {
        /// <summary>
        /// Get Customer by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("~/api/v1/customers/{id:Guid}")]
        [SwaggerOperation(Tags = new[] { "Customers" })]
        public async Task<IActionResult> GetCustomer([FromRoute] Guid id)
        {
            var customer = await _customerService.GetCustomerById(id);
            if (customer == null)
            {
                await _customerService.GetCustomerByType(id);
                var customers = await _customerService.GetCustomerByType(id);
                if (customers.Count > 0)
                {
                    return Ok(customers);
                }
                else
                {
                    return NotFound("NOT_FOUND_MESSAGE");
                }
            }
            return Ok(customer);
        }

        /// <summary>
        /// Get List Customer
        /// </summary>
        /// <returns></returns>
        [HttpGet]
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
        [CustomAuthorized(AppRoles = "Admin")]
=======
>>>>>>> update-database
=======
>>>>>>> b80301f358fce8737aa58cbd3a6ad0d1fecf2c06
=======
        [CustomAuthorized(AppRoles = "Admin")]
>>>>>>> 2a68c653fee721c9c8133eebbb6a46552a6c8b43
        [Route("~/api/v1/customers")]
        [SwaggerOperation(Tags = new[] { "Customers" })]
        public async Task<IActionResult> GetCustomers([FromQuery] CustomerViewModel filter)
        {
            var customers = await _customerService.GetAllCustomers(filter);
            return Ok(customers);
        }

        /// <summary>
        /// Tạo mới 1 Customer
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("~/api/v1/customers")]
        [SwaggerOperation(Tags = new[] { "Customers" })]
        public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerRequest request)
        {
            var customer = await _customerService.CreateCustomer(request, _configuration);
            if (customer == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "INTERNAL_SERVER_ERROR");
            }

            return Created(nameof(CreateCustomer), customer);
        }

        /// <summary>
        /// Cập nhập 1 Customer
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("~/api/v1/customers/{id:Guid}")]
        [SwaggerOperation(Tags = new[] { "Customers" })]
        public async Task<IActionResult> UpdateCustomer([FromRoute] Guid id, UpdateCustomerRequest request)
        {
            var customer = await _customerService.UpdateCustomer(id, request);
            if (customer == null)
            {
                return NotFound("Message");
            }

            return Ok(customer);
        }

        /// <summary>
        /// Xóa 1 Customer qua id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("~/api/v1/customers/{id:Guid}")]
        [SwaggerOperation(Tags = new[] { "Customers" })]
        public async Task<IActionResult> DeleteCustomer([FromRoute] Guid id)
        {
            var resultInt = await _customerService.DeleteCustomer(id);
            if (resultInt != 1)
            {
                return BadRequest("BAD_REQUEST");
            }

            return NoContent();
        }
    }
}
