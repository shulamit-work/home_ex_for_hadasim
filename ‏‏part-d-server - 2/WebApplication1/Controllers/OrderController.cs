using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Dtos;
using Services.Interfaces;
using WebApi.HeopesrSructures;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderSerivce _orderService;
        public OrderController(IOrderSerivce service)
        {
            _orderService = service;
        }
        // GET: api/<OrderController>
        [Authorize(Roles = "owner")]
        [HttpGet]
        public List<OrderDto> Get()
        {
            return _orderService.GetAll();
        }

        // GET api/<OrderController>/5
        [Authorize(Roles = "owner")]
        [HttpGet("{id}")]
        public OrderDto Get(int id)
        {
            return _orderService.Get(id);
        }


        [Authorize]
        [HttpGet("getOrdersByProvderId/{id}")]
        public List<OrderDto> getOrdersByProvderId(int id)
        {
            return _orderService.GetOrdersByProvderId(id);
        }

        // POST api/<OrderController>
        [Authorize(Roles = "owner")]
        [HttpPost]
        public IActionResult Post([FromBody] Order_OrderProduct req)
        {
            OrderDto newO = req.Order;
            List<OrderProductDto> orderProducts = req.OrderProducts;
            
            OrderDto o = _orderService.AddOrder(newO, orderProducts);
            if (o != null)
            {
                return Ok(o);
            }
            return BadRequest("order must have products");
        }

        [Authorize]
        [HttpPut("changeStatus")]
        public OrderDto ChangeStatus(int id, bool isOwner)
        {
            return _orderService.ConfirmOrder(id, isOwner);
        }
    }
}
