using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VuonDau.Data.Models;
using VuonDau.Business.Services;
using System.Linq;
namespace VuonDau.WebApi.Controllers
{
    [ApiController]
    [Route("api/v1/wallets")]
    public partial class WalletsController : ControllerBase
    {
        private readonly IWalletService _walletService;
        private readonly IConfigurationProvider _mapper;
        public WalletsController(IWalletService walletService, IMapper mapper)
        {
            _walletService = walletService;
            _mapper = mapper.ConfigurationProvider;
        }
    }
}
