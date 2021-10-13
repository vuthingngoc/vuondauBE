//using AutoMapper;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using VuonDau.Data.Models;
//using VuonDau.Business.Services;
//using System.Linq;
//namespace VuonDau.WebApi.Controllers.Gens
//{
//    [ApiController]
//    [Route("api/orders")]
//    public partial class OrdersController : ControllerBase
//    {
//        private readonly IOrderService _orderService;
//        private readonly IConfigurationProvider _mapper;
//        public OrdersController(IOrderService orderService,IMapper mapper){
//            _orderService=orderService;
//            _mapper= mapper.ConfigurationProvider;
//        }
//        [HttpGet]
//        public IActionResult Gets()
//        {
//            return Ok(_orderService.Get().ToList());
//        }
//        [HttpGet("{id}")]
//        [ProducesResponseType(StatusCodes.Status200OK)]
//        [ProducesResponseType(StatusCodes.Status404NotFound)]
//        public IActionResult GetById(Guid id)
//        {
//            return Ok(_orderService.Get(id));
//        }
//        [HttpPost]
//        [ProducesResponseType(StatusCodes.Status201Created)]
//        [ProducesResponseType(StatusCodes.Status400BadRequest)]
//        public IActionResult Create(Order entity)
//        {
//            _orderService.Create(entity);
//            return  CreatedAtAction(nameof(GetById), new { id = entity}, entity);
//        }
//        [HttpPut("{id}")]
//        [ProducesResponseType(StatusCodes.Status400BadRequest)]
//        public IActionResult Update(Guid id,Order entity)
//        {
//            _orderService.Update(entity);
//            return Ok();
//        }
//        [HttpDelete("{id}")]
//        public IActionResult Delete(Guid id,Order entity)
//        {
//            _orderService.Delete(entity);
//            return Ok();
//        }
//        [HttpGet("count")]
//        public IActionResult Count()
//        {
//            return Ok(_orderService.Count());
//        }
//    }
//}
