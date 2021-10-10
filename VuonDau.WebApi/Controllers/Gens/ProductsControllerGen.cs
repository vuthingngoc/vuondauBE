using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VuonDau.Data.Models;
using VuonDau.Business.Services;
using System.Linq;
namespace VuonDau.WebApi.Controllers
{
    [ApiController]
    [Route("api/products")]
    public partial class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IConfigurationProvider _mapper;
        public ProductsController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper.ConfigurationProvider;
        }
    }
}
