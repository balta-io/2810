using System;
using BaltaStoreMs.SharedContext.Events;

namespace BaltaStoreMs.Order.Domain.Events
{
    public class OrderCreatedEvent : IDomainEvent
    {
        public OrderCreatedEvent(Entities.Order order)
        {
            Id = Guid.NewGuid();
            Order = order;
            OccuredAt = DateTime.Now;
        }

        public Guid Id { get; }
        public Entities.Order Order { get; }
        public DateTime OccuredAt { get; }
    }
}