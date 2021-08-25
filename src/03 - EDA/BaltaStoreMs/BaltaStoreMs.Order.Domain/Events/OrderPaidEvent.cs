using System;
using BaltaStoreMs.SharedContext.Events;

namespace BaltaStoreMs.Order.Domain.Events
{
    public class OrderPaidEvent : IDomainEvent
    {
        public OrderPaidEvent(Entities.Order order)
        {
            Id = Guid.NewGuid();
            Order = order;
            OccuredAt = DateTime.Now;
        }

        public Guid Id { get; }
        public DateTime OccuredAt { get; }
        public Entities.Order Order { get; }
    }
}