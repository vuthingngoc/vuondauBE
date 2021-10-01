using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VuonDau.Data.Models;
using VuonDau.Business.Services;
using System.Linq;
namespace Reso_Audit.Controllers
{
    [ApiController]
    [Route("api/order-details")]
    public partial class OrderDetailsController : ControllerBase
    {
        private readonly IOrderDetailService _orderDetailService;
        private readonly IConfigurationProvider _mapper;
        public OrderDetailsController(IOrderDetailService orderDetailService,IMapper mapper){
            _orderDetailService=orderDetailService;
            _mapper= mapper.ConfigurationProvider;
        }
        [HttpGet]
        public IActionResult Gets()
        {
            return Ok(_orderDetailService.Get().ToList());
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(string id)
        {
            return Ok(_orderDetailService.Get(id));
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Create(OrderDetail entity)
        {
            _orderDetailService.Create(entity);
            return  CreatedAtAction(nameof(GetById), new { id = entity}, entity);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Update(string id,OrderDetail entity)
        {
            _orderDetailService.Update(entity);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(string id,OrderDetail entity)
        {
            _orderDetailService.Delete(entity);
            return Ok();
        }
        [HttpGet("count")]
        public IActionResult Count()
        {
            return Ok(_orderDetailService.Count());
        }
    }
}
