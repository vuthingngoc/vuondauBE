using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VuonDau.Data.Models;
using VuonDau.Business.Services;
using System.Linq;
namespace VuonDau.WebApi.Controllers
{
    [ApiController]
    [Route("api/v1/product-pictures")]
    public partial class ProductPicturesController : ControllerBase
    {
        private readonly IProductPictureService _productPictureService;
        private readonly IConfigurationProvider _mapper;
        public ProductPicturesController(IProductPictureService productPictureService, IMapper mapper)
        {
            _productPictureService = productPictureService;
            _mapper = mapper.ConfigurationProvider;
        }
    }
}

