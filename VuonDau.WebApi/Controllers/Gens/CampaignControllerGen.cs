using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VuonDau.Data.Models;
using VuonDau.Business.Services;
using System.Linq;

namespace VuonDau.WebApi.Controllers
{
    [ApiController]
    [Route("api/v1/campaigns")]
    public partial class CampaignsController : ControllerBase
    {
        private readonly ICampaignService _campaignService;
        private readonly IConfigurationProvider _mapper;
        public CampaignsController(ICampaignService campaignService, IMapper mapper)
        {
            _campaignService = campaignService;
            _mapper = mapper.ConfigurationProvider;
        }
    }
}
