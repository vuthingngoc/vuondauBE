using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VuonDau.Data.Models;
using VuonDau.Business.Services;
using System.Linq;
namespace VuonDau.WebApi.Controllers
{
    [ApiController]
    [Route("api/v1/product-types")]
    public partial class ProductTypesController : ControllerBase
    {
        private readonly IProductTypeService _productTypeService;
        private readonly IConfigurationProvider _mapper;
        public ProductTypesController(IProductTypeService productTypeService, IMapper mapper)
        {
            _productTypeService = productTypeService;
            _mapper = mapper.ConfigurationProvider;
        }
    }
}
