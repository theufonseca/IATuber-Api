using Domain.Interfaces;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.RabbitMQ.Services
{
    public class NewVideoMessage : INewVideoMessage
    {
        private readonly RabbitMQSettings settings;
        private readonly IModel channel;

        public NewVideoMessage(RabbitMQSettings settings, IModel channel)
        {
            this.settings = settings;
            this.channel = channel;
        }

        public Task<bool> Post(int newVideoId)
        {
            var message = new { newVideoId };
            var messageSerialized = JsonConvert.SerializeObject(message);
            var body = Encoding.UTF8.GetBytes(messageSerialized);

            channel.QueueDeclare(queue: settings.QueueName,
                                 durable: true,
                                 exclusive: false,
                                 autoDelete: false);

            channel.QueueBind(queue: settings.QueueName, exchange: settings.ExchangeName, routingKey: "#.video-process");

            channel.BasicPublish(exchange: settings.ExchangeName,
                                 routingKey: $"process-{newVideoId}.video-process",
                                 basicProperties: null,
                                 body: body);

            return Task.FromResult(true);
        }
    }
}
