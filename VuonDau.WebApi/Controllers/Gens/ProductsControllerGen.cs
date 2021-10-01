using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VuonDau.Data.Models;
using VuonDau.Business.Services;
using System.Linq;
namespace Reso_Audit.Controllers
{
    [ApiController]
    [Route("api/products")]
    public partial class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IConfigurationProvider _mapper;
        public ProductsController(IProductService productService,IMapper mapper){
            _productService=productService;
            _mapper= mapper.ConfigurationProvider;
        }
        [HttpGet]
        public IActionResult Gets()
        {
            return Ok(_productService.Get().ToList());
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(string id)
        {
            return Ok(_productService.Get(id));
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Create(Product entity)
        {
            _productService.Create(entity);
            return  CreatedAtAction(nameof(GetById), new { id = entity}, entity);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Update(string id,Product entity)
        {
            _productService.Update(entity);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(string id,Product entity)
        {
            _productService.Delete(entity);
            return Ok();
        }
        [HttpGet("count")]
        public IActionResult Count()
        {
            return Ok(_productService.Count());
        }
    }
}
