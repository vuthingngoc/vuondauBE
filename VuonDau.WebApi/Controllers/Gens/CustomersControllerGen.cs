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
    [Route("api/v1/customers")]
    public partial class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly AutoMapper.IConfigurationProvider _mapper;
        private readonly IConfiguration _configuration;
        public CustomersController(ICustomerService customerService, IMapper mapper, IConfiguration configuration)
        {
            _customerService = customerService;
            _mapper = mapper.ConfigurationProvider;
            _configuration = configuration;
        }
    }
}
