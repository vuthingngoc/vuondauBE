using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VuonDau.Data.Models;
using VuonDau.Business.Services;
using System.Linq;
namespace VuonDau.WebApi.Controllers
{
    [ApiController]
    [Route("api/v1/productInCarts")]
    public partial class ProductInCartsController : ControllerBase
    {
        private readonly IProductInCartService _productInCartService;
        private readonly IConfigurationProvider _mapper;
        public ProductInCartsController(IProductInCartService productInCartService, IMapper mapper)
        {
            _productInCartService = productInCartService;
            _mapper = mapper.ConfigurationProvider;
        }
    }
}
