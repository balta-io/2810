using System;
using BaltaStoreMs.SharedContext.Events;

namespace BaltaStoreMs.Order.Domain.Events
{
    public class OrderCreatedEvent : IDomainEvent
    {
        public OrderCreatedEvent(Entities.Order order)
        {
            Order = order;
            OccuredAt = DateTime.Now;
        }

        public Entities.Order Order { get; set; }
        public DateTime OccuredAt { get; set; }
    }
}