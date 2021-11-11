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
    [Route("api/v1/transactions")]
    public partial class TransactionsController : ControllerBase
    {
        private readonly ITransactionService _transactionService;
        private readonly IConfigurationProvider _mapper;
        private readonly IMemoryCache _memoryCache;// cache tren ram
        private readonly IDistributedCache _distributedCache;// redis
        private const string TRANSACTION_CACHE = "TRANSACTION_CACHE";
        public TransactionsController(ITransactionService transactionService, IMapper mapper, IMemoryCache memoryCache, IDistributedCache distributedCache)
        {
            _transactionService = transactionService;
            _mapper = mapper.ConfigurationProvider;
            _memoryCache = memoryCache;
            _distributedCache = distributedCache;
        }
    }
}
