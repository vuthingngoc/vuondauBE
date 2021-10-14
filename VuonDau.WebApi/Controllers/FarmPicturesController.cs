using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;
using VuonDau.Business.Requests.FarmPicture;
using VuonDau.Data.Models;

namespace VuonDau.WebApi.Controllers
{
    public partial class FarmPicturesController : ControllerBase
    {
        /// Get List FarmPictures
        [HttpGet]
        [Route("~/api/v1/farm-pictures")]
        [SwaggerOperation(Tags = new[] { "FarmPictures" })]
        public async Task<IActionResult> GetFarmPictures()
        {
            await _farmPictureService.GetAllFarmPictures();
            var farmPictures = await _farmPictureService.GetAllFarmPictures();
            return Ok(farmPictures);
        }

        /// Get FarmPicture by id
        [HttpGet]
        [Route("~/api/v1/farm-pictures/{id:Guid}")]
        [SwaggerOperation(Tags = new[] { "FarmPictures" })]
        public async Task<IActionResult> GetFarmPicture([FromRoute] Guid id)
        {
            var farmPictures = await _farmPictureService.GetFarmPictureById(id);
            if (farmPictures == null)
            {
                return NotFound("NOT_FOUND_MESSAGE");
            }
            return Ok(farmPictures);
        }
        /// Tạo mới 1 farmPicture
        [HttpPost]
        [Route("~/api/v1/farm-pictures")]
        [SwaggerOperation(Tags = new[] { "FarmPictures" })]
        public async Task<IActionResult> CreateFarmPicture([FromBody] CreateFarmPictureRequest request)
        {
            var farmPicture = await _farmPictureService.CreateFarmPicture(request);
            if (farmPicture == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "INTERNAL_SERVER_ERROR");
            }

            return Created(nameof(CreateFarmPicture), farmPicture);
        }
        /// Cập nhập 1 farmPicture
        [HttpPut]
        [Route("~/api/v1/farm-pictures/{id:Guid}")]
        [SwaggerOperation(Tags = new[] { "FarmPictures" })]
        public async Task<IActionResult> UpdateFarmPicture([FromRoute] Guid id, UpdateFarmPictureRequest request)
        {
            var farmPicture = await _farmPictureService.UpdateFarmPicture(id, request);
            if (farmPicture == null)
            {
                return NotFound("Message");
            }

            return Ok(farmPicture);
        }

        /// Xóa 1 farmPictureer qua id
        [HttpDelete]
        [Route("~/api/v1/farm-pictures/{id:Guid}")]
        [SwaggerOperation(Tags = new[] { "FarmPictures" })]
        public async Task<IActionResult> DeleteFarmPicture([FromRoute] Guid id)
        {
            var resultInt = await _farmPictureService.DeleteFarmPicture(id);
            if (resultInt != 1)
            {
                return BadRequest("BAD_REQUEST");
            }

            return NoContent();
        }
    }
}
