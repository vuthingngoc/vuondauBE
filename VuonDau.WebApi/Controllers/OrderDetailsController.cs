using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using VuonDau.Business.Requests.OrderDetail;

namespace VuonDau.WebApi.Controllers
{
    public partial class OrderDetailsController : ControllerBase
    {
        /// <summary>
        /// Get List Customer
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("~/api/v1/order-details")]
        [SwaggerOperation(Tags = new[] { "OrderDetails" })]
        public async Task<IActionResult> GetOrderDetails()
        {
            await _orderDetailService.GetAllOrderDetails();
            var orderDetails = await _orderDetailService.GetAllOrderDetails();
            return Ok(orderDetails);
        }

        /// <summary>
        /// Get Customer by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("~/api/v1/order-details/{id:Guid}")]
        [SwaggerOperation(Tags = new[] { "OrderDetails" })]
        public async Task<IActionResult> GetOrderDetail([FromRoute] Guid id)
        {
            var orderDetail = await _orderDetailService.GetOrderDetailById(id);
            if (orderDetail == null)
            {
                return NotFound("NOT_FOUND_MESSAGE");
            }

            return Ok(orderDetail);
        }

        /// <summary>
        /// Tạo mới 1 Customer
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("~/api/v1/order-details")]
        [SwaggerOperation(Tags = new[] { "OrderDetails" })]
        public async Task<IActionResult> CreateOrderDetail([FromBody] CreateOrderDetailRequest request)
        {
            var orderDetail = await _orderDetailService.CreateOrderDetail(request);
            if (orderDetail == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "INTERNAL_SERVER_ERROR");
            }

            return Created(nameof(CreateOrderDetail), orderDetail);
        }

        /// <summary>
        /// Cập nhập 1 Customer
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("~/api/v1/order-details/{id:Guid}")]
        [SwaggerOperation(Tags = new[] { "OrderDetails" })]
        public async Task<IActionResult> UpdateOrderDetail([FromRoute] Guid id, UpdateOrderDetailRequest request)
        {
            var orderDetail = await _orderDetailService.UpdateOrderDetail(id, request);
            if (orderDetail == null)
            {
                return NotFound("Message");
            }

            return Ok(orderDetail);
        }

        /// <summary>
        /// Xóa 1 Customer qua id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("~/api/v1/order-details/{id:Guid}")]
        [SwaggerOperation(Tags = new[] { "OrderDetails" })]
        public async Task<IActionResult> DeleteOrderDetail([FromRoute] Guid id)
        {
            var resultInt = await _orderDetailService.DeleteOrderDetail(id);
            if (resultInt != 1)
            {
                return BadRequest("BAD_REQUEST");
            }

            return NoContent();
        }
    }
}
