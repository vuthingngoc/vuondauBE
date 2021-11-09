using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;
using VuonDau.Business.Requests.Harvest;
using VuonDau.Business.ViewModel;
using VuonDau.Data.Models;

namespace VuonDau.WebApi.Controllers
{
    public partial class HarvestsController : ControllerBase
    {
        // GET: Harvests
        [HttpGet]
        [Route("~/api/v1/harvests")]
        [SwaggerOperation(Tags = new[] { "Harvests" })]
        public async Task<IActionResult> GetHarvests([FromQuery] HarvestViewModel filter)
        {
            var harvests = await _harvestService.GetAllHarvests(filter);
            return Ok(harvests);
        }

        // GET: Harvests/Details/5
        [HttpGet]
        [Route("~/api/v1/harvests/{id:Guid}")]
        [SwaggerOperation(Tags = new[] { "Harvests" })]
        public async Task<IActionResult> GetHarvests([FromRoute] Guid id)
        {
            var harvest = await _harvestService.GetHarvestById(id);
            if (harvest == null)
            {
                await _harvestService.GetHarvestByFarmId(id);
                var harvests = await _harvestService.GetHarvestByFarmId(id);
                if (harvests.Count > 0)
                {
                    return Ok(harvests);
                }
                else
                {
                    await _harvestService.GetHarvestByProductId(id);
                    harvests = await _harvestService.GetHarvestByProductId(id);
                    if (harvests.Count > 0)
                    {
                        return Ok(harvests);
                    }
                    else
                    {
                        return NotFound("NOT_FOUND_MESSAGE");
                    }
                }
            }

            return Ok(harvest);
        }



        // POST: Harvests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Route("~/api/v1/harvests")]
        [SwaggerOperation(Tags = new[] { "Harvests" })]
        public async Task<IActionResult> CreateHarvest([FromBody] CreateHarvestRequest request)
        {
            var harvest = await _harvestService.CreateHarvest(request);
            if (harvest == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "INTERNAL_SERVER_ERROR");
            }

            return Created(nameof(_harvestService), harvest);
        }



        // POST: Harvests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPut]
        [Route("~/api/v1/harvests/{id:Guid}")]
        [SwaggerOperation(Tags = new[] { "Harvests" })]
        public async Task<IActionResult> UpdateHarvest([FromRoute] Guid id, UpdateHarvestRequest request)
        {
            var harvest = await _harvestService.UpdateHarvest(id, request);
            if (harvest == null)
            {
                return NotFound("Message");
            }

            return Ok(harvest);
        }



        // POST: Harvests/Delete/5
        [HttpDelete]
        [Route("~/api/v1/harvests/{id:Guid}")]
        [SwaggerOperation(Tags = new[] { "Harvests" })]
        public async Task<IActionResult> DeleteHarvest([FromRoute] Guid id)
        {
            var resultInt = await _harvestService.DeleteHarvest(id);
            if (resultInt != 1)
            {
                return BadRequest("BAD_REQUEST");
            }

            return NoContent();
        }
    }
}
