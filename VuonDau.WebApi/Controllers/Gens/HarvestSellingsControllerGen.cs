//using AutoMapper;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using VuonDau.Data.Models;
//using VuonDau.Business.Services;
//using System.Linq;
//namespace VuonDau.WebApi.Controllers.Gens
//{
//    [ApiController]
//    [Route("api/harvest-sellings")]
//    public partial class HarvestSellingsController : ControllerBase
//    {
//        private readonly IHarvestSellingService _harvestSellingService;
//        private readonly IConfigurationProvider _mapper;
//        public HarvestSellingsController(IHarvestSellingService harvestSellingService,IMapper mapper){
//            _harvestSellingService=harvestSellingService;
//            _mapper= mapper.ConfigurationProvider;
//        }
//        [HttpGet]
//        public IActionResult Gets()
//        {
//            return Ok(_harvestSellingService.Get().ToList());
//        }
//        [HttpGet("{id}")]
//        [ProducesResponseType(StatusCodes.Status200OK)]
//        [ProducesResponseType(StatusCodes.Status404NotFound)]
//        public IActionResult GetById(Guid id)
//        {
//            return Ok(_harvestSellingService.Get(id));
//        }
//        [HttpPost]
//        [ProducesResponseType(StatusCodes.Status201Created)]
//        [ProducesResponseType(StatusCodes.Status400BadRequest)]
//        public IActionResult Create(HarvestSelling entity)
//        {
//            _harvestSellingService.Create(entity);
//            return  CreatedAtAction(nameof(GetById), new { id = entity}, entity);
//        }
//        [HttpPut("{id}")]
//        [ProducesResponseType(StatusCodes.Status400BadRequest)]
//        public IActionResult Update(Guid id,HarvestSelling entity)
//        {
//            _harvestSellingService.Update(entity);
//            return Ok();
//        }
//        [HttpDelete("{id}")]
//        public IActionResult Delete(Guid id,HarvestSelling entity)
//        {
//            _harvestSellingService.Delete(entity);
//            return Ok();
//        }
//        [HttpGet("count")]
//        public IActionResult Count()
//        {
//            return Ok(_harvestSellingService.Count());
//        }
//    }
//}
