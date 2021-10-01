using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VuonDau.Data.Models;
using VuonDau.Business.Services;
using System.Linq;
namespace Reso_Audit.Controllers
{
    [ApiController]
    [Route("api/customer-types")]
    public partial class CustomerTypesController : ControllerBase
    {
        private readonly ICustomerTypeService _customerTypeService;
        private readonly IConfigurationProvider _mapper;
        public CustomerTypesController(ICustomerTypeService customerTypeService,IMapper mapper){
            _customerTypeService=customerTypeService;
            _mapper= mapper.ConfigurationProvider;
        }
        [HttpGet]
        public IActionResult Gets()
        {
            return Ok(_customerTypeService.Get().ToList());
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(string id)
        {
            return Ok(_customerTypeService.Get(id));
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Create(CustomerType entity)
        {
            _customerTypeService.Create(entity);
            return  CreatedAtAction(nameof(GetById), new { id = entity}, entity);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Update(string id,CustomerType entity)
        {
            _customerTypeService.Update(entity);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(string id,CustomerType entity)
        {
            _customerTypeService.Delete(entity);
            return Ok();
        }
        [HttpGet("count")]
        public IActionResult Count()
        {
            return Ok(_customerTypeService.Count());
        }
    }
}
