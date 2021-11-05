using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;
using VuonDau.Business.Requests.HarvestPicture;
using VuonDau.Business.ViewModel;
using VuonDau.Data.Models;

namespace VuonDau.WebApi.Controllers
{
    public partial class HarvestPicturesController : ControllerBase
    {
        /// Get List HarvestPictures
        [HttpGet]
        [Route("~/api/v1/harvest-pictures")]
        [SwaggerOperation(Tags = new[] { "HarvestPictures" })]
       public async Task<IActionResult> GetHarvestPictures([FromQuery] HarvestPictureViewModel filter)
        {
            var harvests = await _harvestPictureService.GetAllHarvestPictures(filter);
            return Ok(harvests);
        }

        /// Get HarvestPicture by id
        [HttpGet]
        [Route("~/api/v1/harvest-pictures/{id:Guid}")]
        [SwaggerOperation(Tags = new[] { "HarvestPictures" })]
        public async Task<IActionResult> GetHarvestPicture([FromRoute] Guid id)
        {
            var harvestPictures = await _harvestPictureService.GetHarvestPictureById(id);
            if (harvestPictures == null)
            {
                return NotFound("NOT_FOUND_MESSAGE");
            }
            return Ok(harvestPictures);
        }
        /// Tạo mới 1 harvestPicture
        [HttpPost]
        [Route("~/api/v1/harvest-pictures")]
        [SwaggerOperation(Tags = new[] { "HarvestPictures" })]
        public async Task<IActionResult> CreateHarvestPicture([FromBody] CreateHarvestPictureRequest request)
        {
            var harvestPicture = await _harvestPictureService.CreateHarvestPicture(request);
            if (harvestPicture == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "INTERNAL_SERVER_ERROR");
            }

            return Created(nameof(CreateHarvestPicture), harvestPicture);
        }
        /// Cập nhập 1 harvestPicture
        [HttpPut]
        [Route("~/api/v1/harvest-pictures/{id:Guid}")]
        [SwaggerOperation(Tags = new[] { "HarvestPictures" })]
        public async Task<IActionResult> UpdateHarvestPicture([FromRoute] Guid id, UpdateHarvestPictureRequest request)
        {
            var harvestPicture = await _harvestPictureService.UpdateHarvestPicture(id, request);
            if (harvestPicture == null)
            {
                return NotFound("Message");
            }

            return Ok(harvestPicture);
        }

        /// Xóa 1 harvestPictureer qua id
        [HttpDelete]
        [Route("~/api/v1/harvest-pictures/{id:Guid}")]
        [SwaggerOperation(Tags = new[] { "HarvestPictures" })]
        public async Task<IActionResult> DeleteHarvestPicture([FromRoute] Guid id)
        {
            var resultInt = await _harvestPictureService.DeleteHarvestPicture(id);
            if (resultInt != 1)
            {
                return BadRequest("BAD_REQUEST");
            }

            return NoContent();
        }
    }
}
