using System.Threading.Tasks;
using BaltaStoreMs.Order.Domain.Commands;
using BaltaStoreMs.Order.Domain.Commands.Handlers;
using BaltaStoreMs.Order.Infra.ExternalServices;
using BaltaStoreMs.Order.Infra.Repositories;

namespace BaltaStoreMs.Order.App
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var command = new PlaceOrderCommand
            {
                Email = "andre@email.io"
            };

            var repository = new OrderRepository();
            var paymentService = new PaymentService();
            var kafkaService = new KafkaEventService();
            var rabbitMqService = new RabbitMQEventService();

            //var handler = new OrderCommandHandler(repository, paymentService, kafkaService);
            var handler = new OrderCommandHandler(repository, paymentService, rabbitMqService);
            await handler.HandleAsync(command);
        }
    }
}
