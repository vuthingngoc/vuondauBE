using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VuonDau.Data.Models;
using VuonDau.Business.Services;
using System.Linq;


namespace VuonDau.WebApi.Controllers
{
    [ApiController]
    [Route("api/v1/areas")]
    public partial class AreasController : ControllerBase
    {
        private readonly IAreaService _areaService;
        private readonly IConfigurationProvider _mapper;
        public AreasController(IAreaService areaService, IMapper mapper)
        {
            _areaService = areaService;
            _mapper = mapper.ConfigurationProvider;
        }
    }
}
