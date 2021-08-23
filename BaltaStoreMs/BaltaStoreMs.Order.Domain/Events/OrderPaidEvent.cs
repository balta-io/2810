using System;
using BaltaStoreMs.SharedContext.Events;

namespace BaltaStoreMs.Order.Domain.Events
{
    public class OrderPaidEvent : IDomainEvent
    {
        public OrderPaidEvent(Entities.Order order)
        {
            Order = order;
            OccuredAt = DateTime.Now;
        }
        
        public DateTime OccuredAt { get; set; }
        public Entities.Order Order { get; set; }
    }
}