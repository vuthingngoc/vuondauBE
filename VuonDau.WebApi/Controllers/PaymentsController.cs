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
using VuonDau.Business.Requests.Payment;
using VuonDau.Business.ViewModel;
using VuonDau.Data.Models;

namespace VuonDau.WebApi.Controllers
{
    public partial class PaymentsController : ControllerBase
    {
        /// <summary>
        /// Get List Payment
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("~/api/v1/payments")]
        [SwaggerOperation(Tags = new[] { "Payments" })]
        public async Task<IActionResult> GetPayments([FromQuery] PaymentViewModel filter)
        {
            List<PaymentViewModel> rs;
            _memoryCache.TryGetValue(PAYMENT_CACHE, out rs);
            if (rs != null)
            {
                return Ok(rs);
            }
            try
            {
                rs = await _distributedCache.GetAsync<List<PaymentViewModel>>(PAYMENT_CACHE);
            }
            catch (Exception)
            {
                throw;
            }
            if (rs != null)
            {
                return Ok(rs);
            }
            var payments = await _paymentService.GetAllPayments(filter);
            rs = payments;
            _memoryCache.Set(PAYMENT_CACHE, rs);
            try
            {
                await _distributedCache.SetObjectAsync(PAYMENT_CACHE, rs);
            }
            catch (Exception)
            {
            }
            return Ok(rs);
            //var payments = await _paymentService.GetAllPayments(filter);
            //return Ok(payments);
        }

        /// <summary>
        /// Get Payment by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("~/api/v1/payments/{id:Guid}")]
        [SwaggerOperation(Tags = new[] { "Payments" })]
        public async Task<IActionResult> GetPayment([FromRoute] Guid id)
        {
            var payment = await _paymentService.GetPaymentById(id);
            if (payment == null)
            {
                return NotFound("NOT_FOUND_MESSAGE");
            }

            return Ok(payment);
        }

        /// <summary>
        /// Tạo mới 1 Payment
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("~/api/v1/payments")]
        [SwaggerOperation(Tags = new[] { "Payments" })]
        public async Task<IActionResult> CreatePayment([FromBody] CreatePaymentRequest request)
        {
            var payment = await _paymentService.CreatePayment(request);
            if (payment == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "INTERNAL_SERVER_ERROR");
            }

            return Created(nameof(CreatePayment), payment);
        }

        /// <summary>
        /// Cập nhập 1 Payment
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("~/api/v1/payments/{id:Guid}")]
        [SwaggerOperation(Tags = new[] { "Payments" })]
        public async Task<IActionResult> UpdatePayment([FromRoute] Guid id, UpdatePaymentRequest request)
        {
            var payment = await _paymentService.UpdatePayment(id, request);
            if (payment == null)
            {
                return NotFound("Message");
            }

            return Ok(payment);
        }

        /// <summary>
        /// Xóa 1 Payment qua id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("~/api/v1/payments/{id:Guid}")]
        [SwaggerOperation(Tags = new[] { "Payments" })]
        public async Task<IActionResult> DeletePayment([FromRoute] Guid id)
        {
            var resultInt = await _paymentService.DeletePayment(id);
            if (resultInt != 1)
            {
                return BadRequest("BAD_REQUEST");
            }

            return NoContent();
        }
    }
}
