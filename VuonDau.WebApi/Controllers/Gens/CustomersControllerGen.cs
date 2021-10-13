//using AutoMapper;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using VuonDau.Data.Models;
//using VuonDau.Business.Services;
//using System.Linq;
//namespace VuonDau.WebApi.Controllers.Gens
//{
//    [ApiController]
//    [Route("api/customers")]
//    public partial class CustomersController : ControllerBase
//    {
//        private readonly ICustomerService _customerService;
//        private readonly IConfigurationProvider _mapper;
//        public CustomersController(ICustomerService customerService,IMapper mapper){
//            _customerService=customerService;
//            _mapper= mapper.ConfigurationProvider;
//        }
//        [HttpGet]
//        public IActionResult Gets()
//        {
//            return Ok(_customerService.Get().ToList());
//        }
//        [HttpGet("{id}")]
//        [ProducesResponseType(StatusCodes.Status200OK)]
//        [ProducesResponseType(StatusCodes.Status404NotFound)]
//        public IActionResult GetById(Guid id)
//        {
//            return Ok(_customerService.Get(id));
//        }
//        [HttpPost]
//        [ProducesResponseType(StatusCodes.Status201Created)]
//        [ProducesResponseType(StatusCodes.Status400BadRequest)]
//        public IActionResult Create(Customer entity)
//        {
//            _customerService.Create(entity);
//            return  CreatedAtAction(nameof(GetById), new { id = entity}, entity);
//        }
//        [HttpPut("{id}")]
//        [ProducesResponseType(StatusCodes.Status400BadRequest)]
//        public IActionResult Update(Guid id,Customer entity)
//        {
//            _customerService.Update(entity);
//            return Ok();
//        }
//        [HttpDelete("{id}")]
//        public IActionResult Delete(Guid id,Customer entity)
//        {
//            _customerService.Delete(entity);
//            return Ok();
//        }
//        [HttpGet("count")]
//        public IActionResult Count()
//        {
//            return Ok(_customerService.Count());
//        }
//    }
//}
