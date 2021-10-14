using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using VuonDau.Business.Requests.Transaction;

namespace VuonDau.WebApi.Controllers
{
    public partial class TransactionsController : ControllerBase
    {
        /// <summary>
        /// Get List Customer
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("~/api/v1/transactions")]
        [SwaggerOperation(Tags = new[] { "Transactions" })]
        public async Task<IActionResult> GetTransactions()
        {
            await _transactionService.GetAllTransactions();
            var transactions = await _transactionService.GetAllTransactions();
            return Ok(transactions);
        }

        /// <summary>
        /// Get Customer by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("~/api/v1/transactions/{id:Guid}")]
        [SwaggerOperation(Tags = new[] { "Transactions" })]
        public async Task<IActionResult> GetTransaction([FromRoute] Guid id)
        {
            var transaction = await _transactionService.GetTransactionById(id);
            if (transaction == null)
            {
                return NotFound("NOT_FOUND_MESSAGE");
            }

            return Ok(transaction);
        }

        /// <summary>
        /// Tạo mới 1 Customer
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("~/api/v1/transactions")]
        [SwaggerOperation(Tags = new[] { "Transactions" })]
        public async Task<IActionResult> CreateTransaction([FromBody] CreateTransactionRequest request)
        {
            var transaction = await _transactionService.CreateTransaction(request);
            if (transaction == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "INTERNAL_SERVER_ERROR");
            }

            return Created(nameof(CreateTransaction), transaction);
        }

        /// <summary>
        /// Cập nhập 1 Customer
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("~/api/v1/transactions/{id:Guid}")]
        [SwaggerOperation(Tags = new[] { "Transactions" })]
        public async Task<IActionResult> UpdateTransaction([FromRoute] Guid id, UpdateTransactionRequest request)
        {
            var transaction = await _transactionService.UpdateTransaction(id, request);
            if (transaction == null)
            {
                return NotFound("Message");
            }

            return Ok(transaction);
        }

        /// <summary>
        /// Xóa 1 Customer qua id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("~/api/v1/transactions/{id:Guid}")]
        [SwaggerOperation(Tags = new[] { "Transactions" })]
        public async Task<IActionResult> DeleteTransaction([FromRoute] Guid id)
        {
            var resultInt = await _transactionService.DeleteTransaction(id);
            if (resultInt != 1)
            {
                return BadRequest("BAD_REQUEST");
            }

            return NoContent();
        }
    }
}
