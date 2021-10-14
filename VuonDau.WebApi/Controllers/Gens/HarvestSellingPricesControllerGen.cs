using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VuonDau.Data.Models;
using VuonDau.Business.Services;
using System.Linq;
namespace VuonDau.WebApi.Controllers
{
    [ApiController]
    [Route("api/v1/harvest-selling-prices")]
    public partial class HarvestSellingPricesController : ControllerBase
    {
        private readonly IHarvestSellingPriceService _harvestSellingPriceService;
        private readonly IConfigurationProvider _mapper;
        public HarvestSellingPricesController(IHarvestSellingPriceService harvestSellingPriceService, IMapper mapper)
        {
            _harvestSellingPriceService = harvestSellingPriceService;
            _mapper = mapper.ConfigurationProvider;
        }
    }
}
