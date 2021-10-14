using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VuonDau.Data.Models;
using VuonDau.Business.Services;
using System.Linq;
namespace VuonDau.WebApi.Controllers
{
    [ApiController]
    [Route("api/v1/customer-in-groups")]
    public partial class CustomerInGroupsController : ControllerBase
    {
        private readonly ICustomerInGroupService _customerInGroupService;
        private readonly IConfigurationProvider _mapper;
        public CustomerInGroupsController(ICustomerInGroupService customerInGroupService, IMapper mapper)
        {
            _customerInGroupService = customerInGroupService;
            _mapper = mapper.ConfigurationProvider;
        }
    }
}
