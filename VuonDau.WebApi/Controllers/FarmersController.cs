using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;
using VuonDau.Business.Requests.Farmer;
using VuonDau.Business.Services;
using VuonDau.Business.ViewModel;
using VuonDau.Data.Models;

namespace VuonDau.WebApi.Controllers
{
    
    public partial class FarmersController : ControllerBase
    {
        /// <summary>
        /// Get List Farmers
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("~/api/v1/farmers")]
        [SwaggerOperation(Tags = new[] { "Farmers" })]
        public async Task<IActionResult> GetFarmers([FromQuery] SearchFarmerRequest request)
        {
            var farmers = await _farmerService.GetAllFarmers(request);
            return Ok(farmers);
        }

        /// <summary>
        /// Get Farmer by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("~/api/v1/farmers/{id:Guid}")]
        [SwaggerOperation(Tags = new[] { "Farmers" })]
        public async Task<IActionResult> GetFarmer([FromRoute] Guid id)
        {
            var farmer = await _farmerService.GetFarmerById(id);
            if (farmer == null)
            {
                return NotFound("NOT_FOUND_MESSAGE");
            }

            return Ok(farmer);
        }

        /// <summary>
        /// Tạo mới 1 farmer
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("~/api/v1/farmers")]
        [SwaggerOperation(Tags = new[] { "Farmers" })]
        public async Task<IActionResult> CreateFarmer([FromBody] CreateFarmerRequest request)
        {
            var farmer = await _farmerService.CreateFarmer(request, _configuration);
            if (farmer == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "INTERNAL_SERVER_ERROR");
            }

            return Created(nameof(CreateFarmer), farmer);
        }

        /// <summary>
        /// Cập nhập 1 farmer
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("~/api/v1/farmers/{id:Guid}")]
        [SwaggerOperation(Tags = new[] { "Farmers" })]
        public async Task<IActionResult> UpdateFarmer([FromRoute] Guid id, UpdateFarmerRequest request)
        {
            var farmer = await _farmerService.UpdateFarmer(id, request);
            if (farmer == null)
            {
                return NotFound("Message");
            }

            return Ok(farmer);
        }

        /// <summary>
        /// Xóa 1 farmer qua id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("~/api/v1/farmers/{id:Guid}")]
        [SwaggerOperation(Tags = new[] { "Farmers" })]
        public async Task<IActionResult> DeleteFarmer([FromRoute] Guid id)
        {
            var resultInt = await _farmerService.DeleteFarmer(id);
            if (resultInt != 1)
            {
                return BadRequest("BAD_REQUEST");
            }

            return NoContent();
        }
    }

}
