using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using VuonDau.Business.Services;

namespace VuonDau.WebApi.Controllers
{
    [ApiController]
    [Route("api/v1/admins")]
    public partial class AdminsController : ControllerBase
    {
        private readonly IAdminService _adminService;
        private readonly AutoMapper.IConfigurationProvider _mapper;
        private readonly IConfiguration _configuration;
        private readonly IStringLocalizer<VuonDau.Data.Resources.Resource> _localize;
        public AdminsController(IAdminService adminService, IMapper mapper, IConfiguration configuration, 
            IStringLocalizer<VuonDau.Data.Resources.Resource> localize)
        {
            _adminService = adminService;
            _mapper = mapper.ConfigurationProvider;
            _configuration = configuration;
            _localize = localize;
        }
    }
}
