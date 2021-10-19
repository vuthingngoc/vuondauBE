using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using VuonDau.Business.Requests.Farm;

namespace VuonDau.WebApi.Controllers
{
    public partial class FarmsController : ControllerBase
    {
        /// Get List Farms
        [HttpGet]
        //[Authorize]
        [Route("~/api/v1/farms")]
        [SwaggerOperation(Tags = new[] { "Farms" })]
        public async Task<IActionResult> GetFarms()
        {
            await _farmService.GetAllFarms();
            var farms = await _farmService.GetAllFarms();
            return Ok(farms);
        }

        /// Get Farm by id
        [HttpGet]
        [Route("~/api/v1/farms/{id:Guid}")]
        [SwaggerOperation(Tags = new[] { "Farms" })]
        public async Task<IActionResult> GetFarm([FromRoute] Guid id)
        {
            var farms = await _farmService.GetFarmById(id);
            if (farms == null)
            {
                return NotFound("NOT_FOUND_MESSAGE");
            }
            return Ok(farms);
        }
        /// Tạo mới 1 farm
        [HttpPost]
        [Route("~/api/v1/farms")]
        [SwaggerOperation(Tags = new[] { "Farms" })]
        public async Task<IActionResult> CreateFarm([FromBody] CreateFarmRequest request)
        {
            var farm = await _farmService.CreateFarm(request);
            if (farm == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "INTERNAL_SERVER_ERROR");
            }

            return Created(nameof(CreateFarm), farm);
        }
        /// Cập nhập 1 farm
        [HttpPut]
        [Route("~/api/v1/farms/{id:Guid}")]
        [SwaggerOperation(Tags = new[] { "Farms" })]
        public async Task<IActionResult> UpdateFarm([FromRoute] Guid id, UpdateFarmRequest request)
        {
            var farm = await _farmService.UpdateFarm(id, request);
            if (farm == null)
            {
                return NotFound("Message");
            }

            return Ok(farm);
        }

        /// Xóa 1 farmer qua id
        [HttpDelete]
        [Route("~/api/v1/farms/{id:Guid}")]
        [SwaggerOperation(Tags = new[] { "Farms" })]
        public async Task<IActionResult> DeleteFarm([FromRoute] Guid id)
        {
            var resultInt = await _farmService.DeleteFarm(id);
            if (resultInt != 1)
            {
                return BadRequest("BAD_REQUEST");
            }

            return NoContent();
        }
    }

}
