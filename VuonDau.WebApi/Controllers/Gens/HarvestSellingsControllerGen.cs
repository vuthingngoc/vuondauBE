using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VuonDau.Data.Models;
using VuonDau.Business.Services;
using System.Linq;
namespace VuonDau.WebApi.Controllers
{
    [ApiController]
    [Route("api/v1/harvest-sellings")]
    public partial class HarvestSellingsController : ControllerBase
    {
        private readonly IHarvestSellingService _harvestSellingService;
        private readonly IConfigurationProvider _mapper;
        public HarvestSellingsController(IHarvestSellingService harvestSellingService, IMapper mapper)
        {
            _harvestSellingService = harvestSellingService;
            _mapper = mapper.ConfigurationProvider;
        }
    }
}
