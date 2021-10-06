using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VuonDau.Data.Models;
using VuonDau.Business.Gens.Services;
using System.Linq;
namespace VuonDau.WebApi.Controllers.Gens
{
    [ApiController]
    [Route("api/product-types")]
    public partial class ProductTypesController : ControllerBase
    {
        private readonly IProductTypeService _productTypeService;
        private readonly IConfigurationProvider _mapper;
        public ProductTypesController(IProductTypeService productTypeService,IMapper mapper){
            _productTypeService=productTypeService;
            _mapper= mapper.ConfigurationProvider;
        }
        [HttpGet]
        public IActionResult Gets()
        {
            return Ok(_productTypeService.Get().ToList());
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(int id)
        {
            return Ok(_productTypeService.Get(id));
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Create(ProductType entity)
        {
            _productTypeService.Create(entity);
            return  CreatedAtAction(nameof(GetById), new { id = entity}, entity);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Update(int id,ProductType entity)
        {
            _productTypeService.Update(entity);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id,ProductType entity)
        {
            _productTypeService.Delete(entity);
            return Ok();
        }
        [HttpGet("count")]
        public IActionResult Count()
        {
            return Ok(_productTypeService.Count());
        }
    }
}
