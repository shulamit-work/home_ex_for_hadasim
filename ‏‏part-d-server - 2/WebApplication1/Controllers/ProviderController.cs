using Microsoft.AspNetCore.Mvc;
using Services.Dtos;
using Services.Interfaces;
using WebApi.HeopesrSructures;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProviderController : ControllerBase
    {
        private readonly IProviderSerivce _providerService;
        public ProviderController(IProviderSerivce service)
        {
            _providerService = service;
        }
        // GET: api/<ProviderController>
        [HttpGet]
        public List<ProviderDto> Get()
        {
            return _providerService.GetAll();
        }

        // GET api/<ProviderController>/5
        [HttpGet("{id}")]
        public ProviderDto Get(int id)
        {
            return _providerService.Get(id);
        }

        // POST api/<ProviderController>
        [HttpPost]
        public IActionResult Post([FromBody] Provider_Products req)
        {
            ProviderDto newP = req.Provider;
            List<ProductDto> products = req.Products;
            try
            {
                ProviderDto p = _providerService.AddProvider(newP, products);
                if (p != null)
                {
                    return Ok(p);
                }
                return BadRequest("has to have products");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

    }
}
