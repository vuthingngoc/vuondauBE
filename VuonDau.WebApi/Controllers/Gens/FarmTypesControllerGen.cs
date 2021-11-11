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
    [Route("api/v1/farm-types")]
    public partial class FarmTypesController : ControllerBase
    {
        private readonly IFarmTypeService _farmTypeService;
        private readonly IConfigurationProvider _mapper;
        private readonly IMemoryCache _memoryCache;// cache tren ram
        private readonly IDistributedCache _distributedCache;// redis
        private const string FARMTYPE_CACHE = "FARMTYPE_CACHE";
        public FarmTypesController(IFarmTypeService farmTypeService, IMapper mapper, IMemoryCache memoryCache, IDistributedCache distributedCache)
        {
            _farmTypeService = farmTypeService;
            _mapper = mapper.ConfigurationProvider;
            _memoryCache = memoryCache;
            _distributedCache = distributedCache;
        }
    }
}
