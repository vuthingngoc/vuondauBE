using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VuonDau.Data.Models;
using VuonDau.Business.Services;
using System.Linq;
namespace VuonDau.WebApi.Controllers
{
    [ApiController]
    [Route("api/v1/farm-types")]
    public partial class FarmTypesController : ControllerBase
    {
        private readonly IFarmTypeService _farmTypeService;
        private readonly IConfigurationProvider _mapper;
        public FarmTypesController(IFarmTypeService farmTypeService, IMapper mapper)
        {
            _farmTypeService = farmTypeService;
            _mapper = mapper.ConfigurationProvider;
        }
    }
}
