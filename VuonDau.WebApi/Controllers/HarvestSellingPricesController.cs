using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;
using VuonDau.Business.Requests.HarvestSellingPrice;
using VuonDau.Data.Models;

namespace VuonDau.WebApi.Controllers
{
    public partial class HarvestSellingPricesController : ControllerBase
    {
        // GET: HarvestSellingPrices
        [HttpGet]
        [Route("~/api/v1/harvest-selling-prices")]
        [SwaggerOperation(Tags = new[] { "HarvestSellingPrices" })]
        public async Task<IActionResult> GetHarvestSellingPrices()
        {
            await _harvestSellingPriceService.GetAllHarvestSellingPrices();
            var harvestSellingPrices = await _harvestSellingPriceService.GetAllHarvestSellingPrices();
            return Ok(harvestSellingPrices);
        }

        // GET: HarvestSellingPrices/Details/5
        [HttpGet]
        [Route("~/api/v1/harvest-selling-prices/{id:Guid}")]
        [SwaggerOperation(Tags = new[] { "HarvestSellingPrices" })]
        public async Task<IActionResult> GetHarvestSellingPrices([FromRoute] Guid id)
        {
            var harvestSellingPrice = await _harvestSellingPriceService.GetHarvestSellingPriceById(id);
            if (harvestSellingPrice == null)
            {
                return NotFound("NOT_FOUND_MESSAGE");
            }

            return Ok(harvestSellingPrice);
        }



        // POST: HarvestSellingPrices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Route("~/api/v1/harvest-selling-prices")]
        [SwaggerOperation(Tags = new[] { "HarvestSellingPrices" })]
        public async Task<IActionResult> CreateHarvestSellingPrice([FromBody] CreateHarvestSellingPriceRequest request)
        {
            var harvestSellingPrice = await _harvestSellingPriceService.CreateHarvestSellingPrice(request);
            if (harvestSellingPrice == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "INTERNAL_SERVER_ERROR");
            }

            return Created(nameof(_harvestSellingPriceService), harvestSellingPrice);
        }



        // POST: HarvestSellingPrices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPut]
        [Route("~/api/v1/harvest-selling-prices/{id:Guid}")]
        [SwaggerOperation(Tags = new[] { "HarvestSellingPrices" })]
        public async Task<IActionResult> UpdateHarvestSellingPrice([FromRoute] Guid id, UpdateHarvestSellingPriceRequest request)
        {
            var harvestSellingPrice = await _harvestSellingPriceService.UpdateHarvestSellingPrice(id, request);
            if (harvestSellingPrice == null)
            {
                return NotFound("Message");
            }

            return Ok(harvestSellingPrice);
        }



        // POST: HarvestSellingPrices/Delete/5
        [HttpDelete]
        [Route("~/api/v1/harvest-selling-prices/{id:Guid}")]
        [SwaggerOperation(Tags = new[] { "HarvestSellingPrices" })]
        public async Task<IActionResult> DeleteHarvestSellingPrice([FromRoute] Guid id)
        {
            var resultInt = await _harvestSellingPriceService.DeleteHarvestSellingPrice(id);
            if (resultInt != 1)
            {
                return BadRequest("BAD_REQUEST");
            }

            return NoContent();
        }
    }
}
