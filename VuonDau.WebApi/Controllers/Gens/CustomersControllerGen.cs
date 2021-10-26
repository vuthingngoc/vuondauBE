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
        public CustomersController(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper.ConfigurationProvider;
        }
    }
}
