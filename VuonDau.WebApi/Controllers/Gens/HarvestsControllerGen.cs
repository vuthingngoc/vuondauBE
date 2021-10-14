using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VuonDau.Data.Models;
using VuonDau.Business.Services;
using System.Linq;
namespace VuonDau.WebApi.Controllers
{
    [ApiController]
    [Route("api/v1/harvests")]
    public partial class HarvestsController : ControllerBase
    {
        private readonly IHarvestService _harvestService;
        private readonly IConfigurationProvider _mapper;
        public HarvestsController(IHarvestService harvestService, IMapper mapper)
        {
            _harvestService = harvestService;
            _mapper = mapper.ConfigurationProvider;
        }
    }
}
