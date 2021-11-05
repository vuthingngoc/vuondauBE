using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VuonDau.Data.Models;
using VuonDau.Business.Services;
using System.Linq;
namespace VuonDau.WebApi.Controllers
{
    [ApiController]
    [Route("api/v1/harvest-pictures")]
    public partial class HarvestPicturesController : ControllerBase
    {
        private readonly IHarvestPictureService _harvestPictureService;
        private readonly IConfigurationProvider _mapper;
        public HarvestPicturesController(IHarvestPictureService harvestPictureService, IMapper mapper)
        {
            _harvestPictureService = harvestPictureService;
            _mapper = mapper.ConfigurationProvider;
        }
    }
}

