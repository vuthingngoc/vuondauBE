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
    [Route("api/v1/areas")]
    public partial class AreasController : ControllerBase
    {
        private readonly IAreaService _areaService;
        private readonly IConfigurationProvider _mapper;
        private readonly IMemoryCache _memoryCache;// cache tren ram
        private readonly IDistributedCache _distributedCache;// redis
        private const string AREA_CACHE = "AREA_CACHE";
        public AreasController(IAreaService areaService, IMapper mapper
            , IMemoryCache memoryCache, IDistributedCache distributedCache)
        {
            _areaService = areaService;
            _mapper = mapper.ConfigurationProvider;
            _memoryCache = memoryCache;
            _distributedCache = distributedCache;
        }
    }
}
