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
    [Route("api/v1/wallets")]
    public partial class WalletsController : ControllerBase
    {
        private readonly IWalletService _walletService;
        private readonly IConfigurationProvider _mapper;
        private readonly IMemoryCache _memoryCache;// cache tren ram
        private readonly IDistributedCache _distributedCache;// redis
        private const string WALLET_CACHE = "WALLET_CACHE";
        public WalletsController(IWalletService walletService, IMapper mapper
            , IMemoryCache memoryCache, IDistributedCache distributedCache)
        {
            _walletService = walletService;
            _mapper = mapper.ConfigurationProvider;
            _memoryCache = memoryCache;
            _distributedCache = distributedCache;
        }
    }
}
