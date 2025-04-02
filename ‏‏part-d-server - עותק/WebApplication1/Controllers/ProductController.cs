using Microsoft.AspNetCore.Mvc;
using Services.Dtos;
using Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IService<ProductDto> _productService;
        public ProductController(IService<ProductDto> service)
        {
            _productService = service;
        }
        // GET: api/<ProductController>
        [HttpGet]
        public List<ProductDto> Get()
        {
            return _productService.GetAll();
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public ProductDto Get(int id)
        {
            return _productService.Get(id);
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
