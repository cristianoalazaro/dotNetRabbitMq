using Rabbit.Models.Entities;
using Rabbit.Repositories.Interfaces;
using Rabbit.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rabbit.Services
{
    public class RabbitMessageService : IRabbitMessageService
    {
        private readonly IRabbitMessageRepository _rabbitMessageRepository;
        public RabbitMessageService(IRabbitMessageRepository rabbitMessageRepository)
        {
            _rabbitMessageRepository = rabbitMessageRepository;
        }
        public void SendMessage(RabbitMessage message)
        {
            _rabbitMessageRepository.SendMessage(message);
        }
    }
}
