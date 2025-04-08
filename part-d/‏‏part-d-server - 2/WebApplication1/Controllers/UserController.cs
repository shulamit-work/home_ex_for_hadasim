using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Services.Dtos;
using Services.Interfaces;
using Services.Services;
using WebApi.HeopesrSructures;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IProviderSerivce _providerService;
        public UserController(IProviderSerivce service)
        {
            _providerService = service;
        }
        // GET: api/<ProviderController>
        [Authorize]
        [HttpGet]
        public List<UserDto> Get()
        {
            return _providerService.GetAll();
        }

        [Authorize]
        // GET api/<ProviderController>/5
        [HttpGet("{id}")]
        public UserDto Get(int id)
        {
            return _providerService.Get(id);
        }


        [Authorize]
        [HttpGet("profile")]
        public IActionResult GetProfile()
        {
            try
            {
                var userProfile = _providerService.GetUserProfile(User, $"{Request.Scheme}://{Request.Host}");
                return Ok(userProfile);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(ex.Message);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // POST api/<ProviderController>
        [HttpPost]
        public IActionResult Post([FromForm] UserDto newP, [FromForm] string prods)
        {
            //UserDto newP = req.Provider;

            List<ProductDto> products = JsonConvert.DeserializeObject<List<ProductDto>>(prods);
            try
            {
                UserDto p = _providerService.AddProvider(newP, products);
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
