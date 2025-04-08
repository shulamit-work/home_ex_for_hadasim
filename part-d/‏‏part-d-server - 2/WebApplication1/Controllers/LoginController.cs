using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Dtos;
using Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        // POST api/<LoginController>
        [HttpPost]
        public IActionResult Post([FromQuery] string name, [FromQuery] string pwd)
        {
            UserDto user = _loginService.Verify(name, pwd);
            if (user == null)
                return BadRequest("user not found");
            string token = _loginService.GenerateToken(user);
            return Ok(token);
        }

        [Authorize]
        [HttpGet("/getRole")]
        public bool GetRole()
        {
            return _loginService.CheckIsOwner(User);
        }
    }
}
