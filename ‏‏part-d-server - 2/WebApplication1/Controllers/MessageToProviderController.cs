using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using Services.Dtos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageToProviderController : ControllerBase
    {
        private readonly IMessageToProviderService _serivce;
        public MessageToProviderController(IMessageToProviderService serivce)
        {
            _serivce = serivce;
        }

        [HttpGet("getByProviderId/{id}")]
        public List<MessageToProviderDto> Get(int id)
        {
            return _serivce.GetByProviderId(id);
        }

    }
}
