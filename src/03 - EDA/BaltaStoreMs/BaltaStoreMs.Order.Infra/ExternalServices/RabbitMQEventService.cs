using BaltaStoreMs.SharedContext.Events;
using BaltaStoreMs.SharedContext.ExternalServices;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace BaltaStoreMs.Order.Infra.ExternalServices
{
    public class RabbitMQEventService : IEventService
    { 
        public void Queue(IDomainEvent evt)
        {
            using var channel = LoadChannel();
            CreateQueue(channel, "payments");
            var value = JsonSerializer.Serialize(evt);
            Publish(channel, "payments", value);
        }

        private void Publish(IModel channel, string routingKey, string message)
        {
            var body = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish(exchange: string.Empty,
                     routingKey: routingKey,
                     basicProperties: null,
                     body: body);
        }

        private void CreateQueue(IModel channel, string queueName)
        {
            channel.QueueDeclare(queue: queueName,
                     durable: false,
                     exclusive: false,
                     autoDelete: false,
                     arguments: null);
        }

        private static IModel LoadChannel()
        {
            var factory = new ConnectionFactory { 
                //HostName = "localhost",
                //UserName = "guest",
                //Password = "guest",               
            };
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();

            return channel;
        }
    }
}
