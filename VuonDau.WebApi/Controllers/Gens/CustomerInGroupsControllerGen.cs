using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VuonDau.Data.Models;
using VuonDau.Business.Gens.Services;
using System.Linq;
namespace VuonDau.WebApi.Controllers.Gens
{
    [ApiController]
    [Route("api/customer-in-groups")]
    public partial class CustomerInGroupsController : ControllerBase
    {
        private readonly ICustomerInGroupService _customerInGroupService;
        private readonly IConfigurationProvider _mapper;
        public CustomerInGroupsController(ICustomerInGroupService customerInGroupService,IMapper mapper){
            _customerInGroupService=customerInGroupService;
            _mapper= mapper.ConfigurationProvider;
        }
        [HttpGet]
        public IActionResult Gets()
        {
            return Ok(_customerInGroupService.Get().ToList());
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(int id)
        {
            return Ok(_customerInGroupService.Get(id));
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Create(CustomerInGroup entity)
        {
            _customerInGroupService.Create(entity);
            return  CreatedAtAction(nameof(GetById), new { id = entity}, entity);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Update(int id,CustomerInGroup entity)
        {
            _customerInGroupService.Update(entity);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id,CustomerInGroup entity)
        {
            _customerInGroupService.Delete(entity);
            return Ok();
        }
        [HttpGet("count")]
        public IActionResult Count()
        {
            return Ok(_customerInGroupService.Count());
        }
    }
}
