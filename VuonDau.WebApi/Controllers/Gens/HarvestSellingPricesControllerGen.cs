using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VuonDau.Data.Models;
using VuonDau.Business.Services;
using System.Linq;
namespace Reso_Audit.Controllers
{
    [ApiController]
    [Route("api/harvest-selling-prices")]
    public partial class HarvestSellingPricesController : ControllerBase
    {
        private readonly IHarvestSellingPriceService _harvestSellingPriceService;
        private readonly IConfigurationProvider _mapper;
        public HarvestSellingPricesController(IHarvestSellingPriceService harvestSellingPriceService,IMapper mapper){
            _harvestSellingPriceService=harvestSellingPriceService;
            _mapper= mapper.ConfigurationProvider;
        }
        [HttpGet]
        public IActionResult Gets()
        {
            return Ok(_harvestSellingPriceService.Get().ToList());
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(string id)
        {
            return Ok(_harvestSellingPriceService.Get(id));
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Create(HarvestSellingPrice entity)
        {
            _harvestSellingPriceService.Create(entity);
            return  CreatedAtAction(nameof(GetById), new { id = entity}, entity);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Update(string id,HarvestSellingPrice entity)
        {
            _harvestSellingPriceService.Update(entity);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(string id,HarvestSellingPrice entity)
        {
            _harvestSellingPriceService.Delete(entity);
            return Ok();
        }
        [HttpGet("count")]
        public IActionResult Count()
        {
            return Ok(_harvestSellingPriceService.Count());
        }
    }
}
