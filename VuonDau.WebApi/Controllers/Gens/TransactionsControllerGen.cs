using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VuonDau.Data.Models;
using VuonDau.Business.Services;
using System.Linq;
namespace VuonDau.WebApi.Controllers
{
    [ApiController]
    [Route("api/v1/transactions")]
    public partial class TransactionsController : ControllerBase
    {
        private readonly ITransactionService _transactionService;
        private readonly IConfigurationProvider _mapper;
        public TransactionsController(ITransactionService transactionService, IMapper mapper)
        {
            _transactionService = transactionService;
            _mapper = mapper.ConfigurationProvider;
        }
    }
}
