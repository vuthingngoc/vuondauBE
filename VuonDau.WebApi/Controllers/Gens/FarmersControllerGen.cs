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
    [Route("api/v1/farmers")]
    public partial class FarmersController : ControllerBase
    {
        private readonly IFarmerService _farmerService;
        private readonly AutoMapper.IConfigurationProvider _mapper;
        private readonly IConfiguration _configuration;
        public FarmersController(IFarmerService farmerService, IMapper mapper, IConfiguration configuration)
        {
            _farmerService = farmerService;
            _mapper = mapper.ConfigurationProvider;
            _configuration = configuration;
        }
    }
}
