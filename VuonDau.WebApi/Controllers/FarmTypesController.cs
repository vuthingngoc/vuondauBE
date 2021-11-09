using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;
using VuonDau.Business.Requests.FarmType;
using VuonDau.Business.ViewModel;
using VuonDau.Data.Models;

namespace VuonDau.WebApi.Controllers
{
    public partial class FarmTypesController : ControllerBase
    {
        /// <summary>
        /// Get List Farm
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("~/api/v1/farm-types")]
        [SwaggerOperation(Tags = new[] { "FarmTypes" })]
        public async Task<IActionResult> GetFarmTypes([FromQuery] string name)
        {
            var farmTypes = await _farmTypeService.GetAllFarmTypes(name);
            return Ok(farmTypes);
        }

        /// <summary>
        /// Get Farm by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("~/api/v1/farm-types/{id:Guid}")]
        [SwaggerOperation(Tags = new[] { "FarmTypes" })]
        public async Task<IActionResult> GetFarmType([FromRoute] Guid id)
        {
            var farmType = await _farmTypeService.GetFarmTypeById(id);
            if (farmType == null)
            {
                return NotFound("NOT_FOUND_MESSAGE");
            }

            return Ok(farmType);
        }

        /// <summary>
        /// Tạo mới 1 Farm
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("~/api/v1/farm-types")]
        [SwaggerOperation(Tags = new[] { "FarmTypes" })]
        public async Task<IActionResult> CreateFarmType([FromBody] CreateFarmTypeRequest request)
        {
            var farmType = await _farmTypeService.CreateFarmType(request);
            if (farmType == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "INTERNAL_SERVER_ERROR");
            }

            return Created(nameof(CreateFarmType), farmType);
        }

        /// <summary>
        /// Cập nhập 1 Farm
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("~/api/v1/farm-types/{id:Guid}")]
        [SwaggerOperation(Tags = new[] { "FarmTypes" })]
        public async Task<IActionResult> UpdateFarmType([FromRoute] Guid id, UpdateFarmTypeRequest request)
        {
            var farmType = await _farmTypeService.UpdateFarmType(id, request);
            if (farmType == null)
            {
                return NotFound("Message");
            }

            return Ok(farmType);
        }

        /// <summary>
        /// Xóa 1 Farm qua id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("~/api/v1/farm-types/{id:Guid}")]
        [SwaggerOperation(Tags = new[] { "FarmTypes" })]
        public async Task<IActionResult> DeleteFarmType([FromRoute] Guid id)
        {
            var resultInt = await _farmTypeService.DeleteFarmType(id);
            if (resultInt != 1)
            {
                return BadRequest("BAD_REQUEST");
            }

            return NoContent();
        }
    }
}
