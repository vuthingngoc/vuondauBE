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
    [Route("api/v1/admins")]
    public partial class AdminsController : ControllerBase
    {
        private readonly IAdminService _adminService;
        private readonly AutoMapper.IConfigurationProvider _mapper;
        private readonly IConfiguration _configuration;
        public AdminsController(IAdminService adminService, IMapper mapper, IConfiguration configuration)
        {
            _adminService = adminService;
            _mapper = mapper.ConfigurationProvider;
            _configuration = configuration;
        }
    }
}
