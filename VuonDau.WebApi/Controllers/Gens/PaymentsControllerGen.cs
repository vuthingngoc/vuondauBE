using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VuonDau.Data.Models;
using VuonDau.Business.Services;
using System.Linq;
namespace VuonDau.WebApi.Controllers
{
    [ApiController]
    [Route("api/v1/payments")]
    public partial class PaymentsController : ControllerBase
    {
        private readonly IPaymentService _paymentService;
        private readonly IConfigurationProvider _mapper;
        public PaymentsController(IPaymentService paymentService, IMapper mapper)
        {
            _paymentService = paymentService;
            _mapper = mapper.ConfigurationProvider;
        }
    }
}
