using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VuonDau.Data.Models;
using VuonDau.Business.Services;
using System.Linq;
namespace VuonDau.WebApi.Controllers
{
    [ApiController]
    [Route("api/v1/farms")]
    public partial class FarmsController : ControllerBase
    {
        private readonly IFarmService _farmService;
        private readonly IConfigurationProvider _mapper;
        public FarmsController(IFarmService farmService, IMapper mapper)
        {
            _farmService = farmService;
            _mapper = mapper.ConfigurationProvider;
        }
    }
}

