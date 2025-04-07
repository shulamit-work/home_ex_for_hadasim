using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Dtos;
using Services.Interfaces;
using Services.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService service)
        {
            _productService = service;
        }
        // GET: api/<ProductController>
        [Authorize(Roles = "owner")]
        [HttpGet]
        public List<ProductDto> Get()
        {
            return _productService.GetAll();
        }

        // GET api/<ProductController>/5
        [Authorize]
        [HttpGet("{id}")]
        public ProductDto Get(int id)
        {
            return _productService.Get(id);
        }

        [Authorize]
        [HttpGet("getProductsOfProvider/{provId}")]
        public ActionResult<List<OrderProductDto>> GetOrderProductsByOrderId(int provId)
        {
            //login
            List<ProductDto> products = _productService.GetByProviderId(provId);
            if (products == null || !products.Any())
                return NotFound("No products for this provider");
            return Ok(products);
        }

        // POST api/<ProductController>
        //[HttpPost]
        //public ProductDto Post([FromForm] ProductDto newP)
        //{
        //    ProductDto p = _productService.AddItem(newP);
        //    return p;
        //}

    }
}
