using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VuonDau.Data.Models;
using VuonDau.Business.Services;
using System.Linq;
namespace VuonDau.WebApi.Controllers
{
    [ApiController]
    [Route("api/v1/customer-types")]
    public partial class CustomerTypesController : ControllerBase
    {
        private readonly ICustomerTypeService _customerTypeService;
        private readonly IConfigurationProvider _mapper;
        public CustomerTypesController(ICustomerTypeService customerTypeService, IMapper mapper)
        {
            _customerTypeService = customerTypeService;
            _mapper = mapper.ConfigurationProvider;
        }
    }
}
