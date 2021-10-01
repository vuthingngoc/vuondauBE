using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VuonDau.Data.Models;
using VuonDau.Business.Services;
using System.Linq;
namespace Reso_Audit.Controllers
{
    [ApiController]
    [Route("api/farmers")]
    public partial class FarmersController : ControllerBase
    {
        private readonly IFarmerService _farmerService;
        private readonly IConfigurationProvider _mapper;
        public FarmersController(IFarmerService farmerService,IMapper mapper){
            _farmerService=farmerService;
            _mapper= mapper.ConfigurationProvider;
        }
        [HttpGet]
        public IActionResult Gets()
        {
            return Ok(_farmerService.Get().ToList());
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(string id)
        {
            return Ok(_farmerService.Get(id));
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Create(Farmer entity)
        {
            _farmerService.Create(entity);
            return  CreatedAtAction(nameof(GetById), new { id = entity}, entity);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Update(string id,Farmer entity)
        {
            _farmerService.Update(entity);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(string id,Farmer entity)
        {
            _farmerService.Delete(entity);
            return Ok();
        }
        [HttpGet("count")]
        public IActionResult Count()
        {
            return Ok(_farmerService.Count());
        }
    }
}
