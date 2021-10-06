using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VuonDau.Data.Models;
using VuonDau.Business.Gens.Services;
using System.Linq;
namespace VuonDau.WebApi.Controllers.Gens
{
    [ApiController]
    [Route("api/farmers")]
    public partial class FarmersController : ControllerBase
    {
        private readonly IFarmerService _farmerService;
        private readonly IConfigurationProvider _mapper;
        public FarmersController(IFarmerService farmerService, IMapper mapper)
        {
            _farmerService = farmerService;
            _mapper = mapper.ConfigurationProvider;
        }
    }
}
