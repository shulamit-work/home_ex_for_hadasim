using Microsoft.AspNetCore.Mvc;
using Services.Dtos;
using Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderProductController : ControllerBase
    {
        private readonly IService<OrderProductDto> _orderService;
        public OrderProductController(IService<OrderProductDto> service)
        {
            _orderService = service;
        }

        // GET: api/<OrderController>
        [HttpGet]
        public List<OrderProductDto> Get()
        {
            return _orderService.GetAll();
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public OrderProductDto Get(int id)
        {
            return _orderService.Get(id);
        }

        // POST api/<OrderController>
        [HttpPost]
        public OrderProductDto Post([FromForm] OrderProductDto newP)
        {
            OrderProductDto op = _orderService.AddItem(newP);
            return op;
        }
    }
}
