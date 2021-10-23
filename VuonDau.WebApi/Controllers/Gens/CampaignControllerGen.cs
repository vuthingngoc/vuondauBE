using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VuonDau.Data.Models;
using VuonDau.Business.Services;
using System.Linq;
using Microsoft.Extensions.Configuration;

namespace VuonDau.WebApi.Controllers
{
    [ApiController]
    [Route("api/v1/campaigns")]
    public partial class CampaignsController : ControllerBase
    {
        private readonly ICampaignService _campaignService;
        private readonly AutoMapper.IConfigurationProvider _mapper;
        private readonly IConfiguration _configuration;
        public CampaignsController(ICampaignService campaignService, IMapper mapper, IConfiguration configuration)
        {
            _campaignService = campaignService;
            _mapper = mapper.ConfigurationProvider;
            _configuration = configuration;
        }
    }
}
