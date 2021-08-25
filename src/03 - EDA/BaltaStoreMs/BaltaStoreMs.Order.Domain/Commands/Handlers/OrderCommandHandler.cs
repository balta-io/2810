using System;
using System.Threading.Tasks;
using BaltaStoreMs.Order.Domain.Events;
using BaltaStoreMs.Order.Domain.ExternalServices;
using BaltaStoreMs.Order.Domain.Repositories;
using BaltaStoreMs.Order.Domain.ValueObjects;
using BaltaStoreMs.SharedContext.Commands.Handlers;
using BaltaStoreMs.SharedContext.ExternalServices;

namespace BaltaStoreMs.Order.Domain.Commands.Handlers
{
    public class OrderCommandHandler :
        ICommandHandler<PlaceOrderCommand>,
        ICommandHandler<PayOrderCommand>
    {
        private readonly IOrderRepository _repository;
        private readonly IPaymentService _paymentService;
        private readonly IEventService _eventService;

        public OrderCommandHandler(
            IOrderRepository repository,
            IPaymentService paymentService,
            IEventService eventService)
        {
            _repository = repository;
            _paymentService = paymentService;
            _eventService = eventService;
        }

        public async Task HandleAsync(PlaceOrderCommand command)
        {
            // Valida o comando
            var user = await _repository.GetUserAsync(command.Email);

            if (user == null)
                return;

            var order = new Entities.Order(user);
            order.OnOrderPlaced += OnOrderPlaced;

            order.Place();
        }

        public async Task HandleAsync(PayOrderCommand command)
        {
            var order = await _repository.GetOrderAsync(command.Id);
            order.OnOrderPaid += OnOrderPaid;

            var creditCard = new CreditCard
            {
                Name = command.Name,
                Number = command.Number,
                Expiration = command.Expiration,
                Cvv = command.Cvv
            };
            var transaction = await _paymentService.PayAsync(creditCard);

            order.Pay(transaction);
        }

        private void OnOrderPlaced(object sender, EventArgs e) =>
            _eventService.Queue(new OrderCreatedEvent((Entities.Order) sender));

        private void OnOrderPaid(object sender, EventArgs e) =>
            _eventService.Queue(new OrderPaidEvent((Entities.Order) sender));
    }
}