using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VuonDau.Data.Models;
using VuonDau.Business.Services;
using System.Linq;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;

namespace VuonDau.WebApi.Controllers
{
    [ApiController]
    [Route("api/v1/product-types")]
    public partial class ProductTypesController : ControllerBase
    {
        private readonly IProductTypeService _productTypeService;
        private readonly IConfigurationProvider _mapper;
        private readonly IMemoryCache _memoryCache;// cache tren ram
        private readonly IDistributedCache _distributedCache;// redis
        private const string PRODUCTTYPE_CACHE = "PRODUCTTYPE_CACHE";
        public ProductTypesController(IProductTypeService productTypeService, IMapper mapper, IMemoryCache memoryCache, IDistributedCache distributedCache)
        {
            _productTypeService = productTypeService;
            _mapper = mapper.ConfigurationProvider;
            _memoryCache = memoryCache;
            _distributedCache = distributedCache;
        }
    }
}
