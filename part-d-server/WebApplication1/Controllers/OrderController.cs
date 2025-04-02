using Microsoft.AspNetCore.Mvc;
using Services.Dtos;
using Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IService<OrderDto> _orderService;
        public OrderController(IService<OrderDto> service)
        {
            _orderService = service;
        }
        // GET: api/<OrderController>
        [HttpGet]
        public List<OrderDto> Get()
        {
            return _orderService.GetAll();
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public OrderDto Get(int id)
        {
            return _orderService.Get(id);
        }

        // POST api/<OrderController>
        [HttpPost]
        public OrderDto Post([FromForm] OrderDto newP)
        {
            OrderDto o = _orderService.AddItem(newP);
            return o;
        }

    }
}
