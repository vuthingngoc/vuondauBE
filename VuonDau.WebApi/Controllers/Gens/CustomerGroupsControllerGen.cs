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
    [Route("api/v1/customer-groups")]
    public partial class CustomerGroupsController : ControllerBase
    {
        private readonly ICustomerGroupService _customerGroupService;
        private readonly IConfigurationProvider _mapper;
        private readonly IMemoryCache _memoryCache;// cache tren ram
        private readonly IDistributedCache _distributedCache;// redis
        private const string CUSTOMERGROUP_CACHE = "CUSTOMERGROUP_CACHE";
        public CustomerGroupsController(ICustomerGroupService customerGroupService, IMapper mapper
            , IMemoryCache memoryCache, IDistributedCache distributedCache)
        {
            _customerGroupService = customerGroupService;
            _mapper = mapper.ConfigurationProvider;
            _memoryCache = memoryCache;
            _distributedCache = distributedCache;
        }
    }
}
