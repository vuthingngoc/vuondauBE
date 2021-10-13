//using AutoMapper;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using VuonDau.Data.Models;
//using VuonDau.Business.Services;
//using System.Linq;
//namespace VuonDau.WebApi.Controllers.Gens
//{
//    [ApiController]
//    [Route("api/harvests")]
//    public partial class HarvestsController : ControllerBase
//    {
//        private readonly IHarvestService _harvestService;
//        private readonly IConfigurationProvider _mapper;
//        public HarvestsController(IHarvestService harvestService,IMapper mapper){
//            _harvestService=harvestService;
//            _mapper= mapper.ConfigurationProvider;
//        }
//        [HttpGet]
//        public IActionResult Gets()
//        {
//            return Ok(_harvestService.Get().ToList());
//        }
//        [HttpGet("{id}")]
//        [ProducesResponseType(StatusCodes.Status200OK)]
//        [ProducesResponseType(StatusCodes.Status404NotFound)]
//        public IActionResult GetById(Guid id)
//        {
//            return Ok(_harvestService.Get(id));
//        }
//        [HttpPost]
//        [ProducesResponseType(StatusCodes.Status201Created)]
//        [ProducesResponseType(StatusCodes.Status400BadRequest)]
//        public IActionResult Create(Harvest entity)
//        {
//            _harvestService.Create(entity);
//            return  CreatedAtAction(nameof(GetById), new { id = entity}, entity);
//        }
//        [HttpPut("{id}")]
//        [ProducesResponseType(StatusCodes.Status400BadRequest)]
//        public IActionResult Update(Guid id,Harvest entity)
//        {
//            _harvestService.Update(entity);
//            return Ok();
//        }
//        [HttpDelete("{id}")]
//        public IActionResult Delete(Guid id,Harvest entity)
//        {
//            _harvestService.Delete(entity);
//            return Ok();
//        }
//        [HttpGet("count")]
//        public IActionResult Count()
//        {
//            return Ok(_harvestService.Count());
//        }
//    }
//}
