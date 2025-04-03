using Microsoft.AspNetCore.Authorization;
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
        private readonly IOrderProductsService _orderProductService;
        public OrderProductController(IOrderProductsService orderProductService)
        {
            _orderProductService= orderProductService;
        }

        // GET api/<OrderController>/5
        [Authorize]
        [HttpGet("getOrderProducts/{orderId}")]
        public ActionResult<List<OrderProductDto>> GetOrderProductsByOrderId(int orderId)
        {
            //login
            List<OrderProductDto> orderProducts = _orderProductService.GetByOrderId(orderId);
            if (orderProducts == null || !orderProducts.Any())
                return NotFound("No order products for this order");
            return Ok(orderProducts);
        }

        
    }
}
