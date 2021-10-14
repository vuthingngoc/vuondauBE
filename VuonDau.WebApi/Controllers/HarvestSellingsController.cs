using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;
using VuonDau.Business.Requests.HarvestSelling;
using VuonDau.Data.Models;

namespace VuonDau.WebApi.Controllers
{
    public partial class HarvestSellingsController : ControllerBase
    {
        // GET: HarvestSellings
        [HttpGet]
        [Route("~/api/v1/harvest-sellings")]
        [SwaggerOperation(Tags = new[] { "HarvestSellings" })]
        public async Task<IActionResult> GetHarvestSellings()
        {
            await _harvestSellingService.GetAllHarvestSellings();
            var harvestSellings = await _harvestSellingService.GetAllHarvestSellings();
            return Ok(harvestSellings);
        }

        // GET: HarvestSellings/Details/5
        [HttpGet]
        [Route("~/api/v1/harvest-sellings/{id:Guid}")]
        [SwaggerOperation(Tags = new[] { "HarvestSellings" })]
        public async Task<IActionResult> GetHarvestSellings([FromRoute] Guid id)
        {
            var harvestSelling = await _harvestSellingService.GetHarvestSellingById(id);
            if (harvestSelling == null)
            {
                return NotFound("NOT_FOUND_MESSAGE");
            }

            return Ok(harvestSelling);
        }



        // POST: HarvestSellings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Route("~/api/v1/harvest-sellings")]
        [SwaggerOperation(Tags = new[] { "HarvestSellings" })]
        public async Task<IActionResult> CreateHarvestSelling([FromBody] CreateHarvestSellingRequest request)
        {
            var harvestSelling = await _harvestSellingService.CreateHarvestSelling(request);
            if (harvestSelling == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "INTERNAL_SERVER_ERROR");
            }

            return Created(nameof(_harvestSellingService), harvestSelling);
        }



        // POST: HarvestSellings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPut]
        [Route("~/api/v1/harvest-sellings/{id:Guid}")]
        [SwaggerOperation(Tags = new[] { "HarvestSellings" })]
        public async Task<IActionResult> UpdateHarvestSelling([FromRoute] Guid id, UpdateHarvestSellingRequest request)
        {
            var harvestSelling = await _harvestSellingService.UpdateHarvestSelling(id, request);
            if (harvestSelling == null)
            {
                return NotFound("Message");
            }

            return Ok(harvestSelling);
        }



        // POST: HarvestSellings/Delete/5
        [HttpDelete]
        [Route("~/api/v1/harvest-sellings/{id:Guid}")]
        [SwaggerOperation(Tags = new[] { "HarvestSellings" })]
        public async Task<IActionResult> DeleteHarvestSelling([FromRoute] Guid id)
        {
            var resultInt = await _harvestSellingService.DeleteHarvestSelling(id);
            if (resultInt != 1)
            {
                return BadRequest("BAD_REQUEST");
            }

            return NoContent();
        }
    }
}
