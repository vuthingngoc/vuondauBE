using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VuonDau.Data.Models;
using VuonDau.Business.Services;
using System.Linq;
namespace VuonDau.WebApi.Controllers
{
    [ApiController]
    [Route("api/v1/farm-pictures")]
    public partial class FarmPicturesController : ControllerBase
    {
        private readonly IFarmPictureService _farmPictureService;
        private readonly IConfigurationProvider _mapper;
        public FarmPicturesController(IFarmPictureService farmPictureService, IMapper mapper)
        {
            _farmPictureService = farmPictureService;
            _mapper = mapper.ConfigurationProvider;
        }
    }
}

