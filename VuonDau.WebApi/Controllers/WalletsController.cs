using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;
using VuonDau.Business.Requests.Wallet;
using VuonDau.Data.Models;

namespace VuonDau.WebApi.Controllers
{
    public partial class WalletsController : ControllerBase
    {
        /// <summary>
        /// Get List Wallet
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("~/api/v1/wallets")]
        [SwaggerOperation(Tags = new[] { "Wallets" })]
        public async Task<IActionResult> GetWallets()
        {
            await _walletService.GetAllWallets();
            var wallets = await _walletService.GetAllWallets();
            return Ok(wallets);
        }

        /// <summary>
        /// Get Wallet by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("~/api/v1/wallets/{id:Guid}")]
        [SwaggerOperation(Tags = new[] { "Wallets" })]
        public async Task<IActionResult> GetWallet([FromRoute] Guid id)
        {
            var wallet = await _walletService.GetWalletById(id);
            if (wallet == null)
            {
                return NotFound("NOT_FOUND_MESSAGE");
            }

            return Ok(wallet);
        }

        /// <summary>
        /// Tạo mới 1 Wallet
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("~/api/v1/wallets")]
        [SwaggerOperation(Tags = new[] { "Wallets" })]
        public async Task<IActionResult> CreateWallet([FromBody] CreateWalletRequest request)
        {
            var wallet = await _walletService.CreateWallet(request);
            if (wallet == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "INTERNAL_SERVER_ERROR");
            }

            return Created(nameof(CreateWallet), wallet);
        }

        /// <summary>
        /// Cập nhập 1 Wallet
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("~/api/v1/wallets/{id:Guid}")]
        [SwaggerOperation(Tags = new[] { "Wallets" })]
        public async Task<IActionResult> UpdateWallet([FromRoute] Guid id, UpdateWalletRequest request)
        {
            var wallet = await _walletService.UpdateWallet(id, request);
            if (wallet == null)
            {
                return NotFound("Message");
            }

            return Ok(wallet);
        }

        /// <summary>
        /// Xóa 1 Wallet qua id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("~/api/v1/wallets/{id:Guid}")]
        [SwaggerOperation(Tags = new[] { "Wallets" })]
        public async Task<IActionResult> DeleteWallet([FromRoute] Guid id)
        {
            var resultInt = await _walletService.DeleteWallet(id);
            if (resultInt != 1)
            {
                return BadRequest("BAD_REQUEST");
            }

            return NoContent();
        }
    }
}
