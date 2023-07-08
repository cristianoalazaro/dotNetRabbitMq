using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rabbit.Models.Entities;
using Rabbit.Services.Interfaces;

namespace Rabbit.Publisher.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RabbitMessageController : ControllerBase
    {
        private readonly IRabbitMessageService _rabbitmessageService;
        public RabbitMessageController(IRabbitMessageService rabbitMessageService)
        {
            _rabbitmessageService = rabbitMessageService;
        }

        [HttpGet]
        public void Req()
        {
            string coisa = "coisa";
        }

        [HttpPost]
        public void AddMessage(RabbitMessage message)
        {
            _rabbitmessageService.SendMessage(message);
        }
    }
}
