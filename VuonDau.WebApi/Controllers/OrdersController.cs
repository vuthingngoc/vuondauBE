using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using VuonDau.Business.Requests.Order;
using VuonDau.Business.Services;
using VuonDau.Business.ViewModel;

namespace VuonDau.WebApi.Controllers
{
    public partial class OrdersController : ControllerBase
    {
        /// <summary>
        /// Get List Order
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("~/api/v1/orders")]
        [SwaggerOperation(Tags = new[] { "Orders" })]
        public async Task<IActionResult> GetOrders([FromQuery] OrderViewModel filter)
        {
            var orders = await _orderService.GetAllOrders(filter);
            return Ok(orders);
        }

        /// <summary>
        /// Get Order by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("~/api/v1/orders/{id:Guid}")]
        [SwaggerOperation(Tags = new[] { "Orders" })]
        public async Task<IActionResult> GetOrder([FromRoute] Guid id)
        {
            var order = await _orderService.GetOrderById(id);
            if (order == null)
            {
                await _orderService.GetOrderByCustomerId(id);
                var orders = await _orderService.GetOrderByCustomerId(id);
                if (orders.Count > 0)
                {
                    return Ok(orders);
                }
                else
                {
                    return NotFound("NOT_FOUND_MESSAGE");
                }
            }

            return Ok(order);
        }

        /// <summary>
        /// Tạo mới 1 Order
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("~/api/v1/orders")]
        [SwaggerOperation(Tags = new[] { "Orders" })]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderRequest request)
        {
            var order = await _orderService.CreateOrder(request);
            if (order == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "INTERNAL_SERVER_ERROR");
            }

            return Created(nameof(CreateOrder), order);
        }

        /// <summary>
        /// Cập nhập 1 Order
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("~/api/v1/orders/{id:Guid}")]
        [SwaggerOperation(Tags = new[] { "Orders" })]
        public async Task<IActionResult> UpdateOrder([FromRoute] Guid id, UpdateOrderRequest request)
        {
            var order = await _orderService.UpdateOrder(id, request);
            if (order == null)
            {
                return NotFound("Message");
            }

            return Ok(order);
        }
        /// <summary>
        /// Cập nhập 1 Status order
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("~/api/v1/orders/status{id:Guid}")]
        [SwaggerOperation(Tags = new[] { "Orders" })]
        public async Task<IActionResult> UpdateStatusOrder([FromRoute] Guid id, UpdateOrderStatusRequest request)
        {
            var order = await _orderService.UpdateStatusOrder(id, request);
            if (order == null)
            {
                return NotFound("Message");
            }

            return Ok(order);
        }

        /// <summary>
        /// Xóa 1 Order qua id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("~/api/v1/orders/{id:Guid}")]
        [SwaggerOperation(Tags = new[] { "Orders" })]
        public async Task<IActionResult> DeleteOrder([FromRoute] Guid id)
        {
            var resultInt = await _orderService.DeleteOrder(id);
            if (resultInt != 1)
            {
                return BadRequest("BAD_REQUEST");
            }

            return NoContent();
        }
    }
}
