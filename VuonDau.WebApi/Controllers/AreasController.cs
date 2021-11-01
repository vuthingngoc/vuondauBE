using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;
using VuonDau.Business.Requests;
using VuonDau.Business.Requests.Area;
using VuonDau.Business.ViewModel;
using VuonDau.Data.Models;

namespace VuonDau.WebApi.Controllers
{
    public partial class AreasController : ControllerBase
    {
               /// <summary>
        /// Get List Area
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("~/api/v1/areas")]
        [SwaggerOperation(Tags = new[] { "Areas" })]
        public async Task<IActionResult> GetAreas([FromQuery] AreaViewModel filter)
        {
            var areas = await _areaService.GetAllAreas(filter);
            return Ok(areas);
        }


        /// <summary>
        /// Get Area by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("~/api/v1/areas/{id:Guid}")]
        [SwaggerOperation(Tags = new[] { "Areas" })]
        public async Task<IActionResult> GetArea([FromRoute] Guid id)
        {
            var area = await _areaService.GetAreaById(id);
            if (area == null)
            {
                return NotFound("NOT_FOUND_MESSAGE");
            }

            return Ok(area);
        }

 
        ///// <summary>
        ///// Get Area by id
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //[HttpGet]
        //[Route("~/api/v1/areas/{id:Guid}")]
        //[SwaggerOperation(Tags = new[] { "Areas" })]
        //public async Task<IActionResult> GetArea([FromRoute] Guid id)
        //{
        //    var area = await _areaService.GetAreaById(id);
        //    if (area == null)
        //    {
        //        return NotFound("NOT_FOUND_MESSAGE");
        //    }

        //    return Ok(area);
        //}

        /// <summary>
        /// Tạo mới 1 Area
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("~/api/v1/areas")]
        [SwaggerOperation(Tags = new[] { "Areas" })]
        public async Task<IActionResult> CreateArea([FromBody] CreateAreaRequest request)
        {
            var area = await _areaService.CreateArea(request);
            if (area == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "INTERNAL_SERVER_ERROR");
            }

            return Created(nameof(CreateArea), area);
        }

        /// <summary>
        /// Cập nhập 1 Area
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("~/api/v1/areas/{id:Guid}")]
        [SwaggerOperation(Tags = new[] { "Areas" })]
        public async Task<IActionResult> UpdateArea([FromRoute] Guid id, UpdateAreaRequest request)
        {
            var area = await _areaService.UpdateArea(id, request);
            if (area == null)
            {
                return NotFound("Message");
            }

            return Ok(area);
        }

        /// <summary>
        /// Xóa 1 Area qua id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("~/api/v1/areas/{id:Guid}")]
        [SwaggerOperation(Tags = new[] { "Areas" })]
        public async Task<IActionResult> DeleteArea([FromRoute] Guid id)
        {
            var resultInt = await _areaService.DeleteArea(id);
            if (resultInt != 1)
            {
                return BadRequest("BAD_REQUEST");
            }

            return NoContent();
        }
    }
}
