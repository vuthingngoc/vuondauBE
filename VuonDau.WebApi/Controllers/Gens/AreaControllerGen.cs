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
    [Route("api/v1/areas")]
    public partial class AreasController : ControllerBase
    {
        private readonly IAreaService _areaService;
        private readonly AutoMapper.IConfigurationProvider _mapper;
        private readonly IConfiguration _configuration;
        public AreasController(IAreaService areaService, IMapper mapper, IConfiguration configuration)
        {
            _areaService = areaService;
            _mapper = mapper.ConfigurationProvider;
            _configuration = configuration;
        }
    }
}
