//using AutoMapper;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using VuonDau.Data.Models;
//using VuonDau.Business.Services;
//using System.Linq;
//namespace VuonDau.WebApi.Controllers.Gens
//{
//    [ApiController]
//    [Route("api/product-pictures")]
//    public partial class ProductPicturesController : ControllerBase
//    {
//        private readonly IProductPictureService _productPictureService;
//        private readonly IConfigurationProvider _mapper;
//        public ProductPicturesController(IProductPictureService productPictureService,IMapper mapper){
//            _productPictureService=productPictureService;
//            _mapper= mapper.ConfigurationProvider;
//        }
//        [HttpGet]
//        public IActionResult Gets()
//        {
//            return Ok(_productPictureService.Get().ToList());
//        }
//        [HttpGet("{id}")]
//        [ProducesResponseType(StatusCodes.Status200OK)]
//        [ProducesResponseType(StatusCodes.Status404NotFound)]
//        public IActionResult GetById(Guid id)
//        {
//            return Ok(_productPictureService.Get(id));
//        }
//        [HttpPost]
//        [ProducesResponseType(StatusCodes.Status201Created)]
//        [ProducesResponseType(StatusCodes.Status400BadRequest)]
//        public IActionResult Create(ProductPicture entity)
//        {
//            _productPictureService.Create(entity);
//            return  CreatedAtAction(nameof(GetById), new { id = entity}, entity);
//        }
//        [HttpPut("{id}")]
//        [ProducesResponseType(StatusCodes.Status400BadRequest)]
//        public IActionResult Update(Guid id,ProductPicture entity)
//        {
//            _productPictureService.Update(entity);
//            return Ok();
//        }
//        [HttpDelete("{id}")]
//        public IActionResult Delete(Guid id,ProductPicture entity)
//        {
//            _productPictureService.Delete(entity);
//            return Ok();
//        }
//        [HttpGet("count")]
//        public IActionResult Count()
//        {
//            return Ok(_productPictureService.Count());
//        }
//    }
//}
