using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VuonDau.Data.Models;
using VuonDau.Business.Services;
using System.Linq;
namespace VuonDau.WebApi.Controllers
{
    [ApiController]
    [Route("api/v1/customer-groups")]
    public partial class CustomerGroupsController : ControllerBase
    {
        private readonly ICustomerGroupService _customerGroupService;
        private readonly IConfigurationProvider _mapper;
        public CustomerGroupsController(ICustomerGroupService customerGroupService, IMapper mapper)
        {
            _customerGroupService = customerGroupService;
            _mapper = mapper.ConfigurationProvider;
        }
    }
}
