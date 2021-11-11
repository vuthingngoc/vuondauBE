using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VuonDau.Data.Models;
using VuonDau.Business.Services;
using System.Linq;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Caching.Distributed;

namespace VuonDau.WebApi.Controllers
{
    [ApiController]
    [Route("api/v1/customer-types")]
    public partial class CustomerTypesController : ControllerBase
    {
        private readonly ICustomerTypeService _customerTypeService;
        private readonly IConfigurationProvider _mapper;
        private readonly IMemoryCache _memoryCache;// cache tren ram
        private readonly IDistributedCache _distributedCache;// redis
        private const string CUSTOMERTYPE_CACHE = "CUSTOMERTYPE_CACHE";
        public CustomerTypesController(ICustomerTypeService customerTypeService, IMapper mapper
            , IMemoryCache memoryCache, IDistributedCache distributedCache)
        {
            _customerTypeService = customerTypeService;
            _mapper = mapper.ConfigurationProvider;
            _memoryCache = memoryCache;
            _distributedCache = distributedCache;
        }
    }
}
