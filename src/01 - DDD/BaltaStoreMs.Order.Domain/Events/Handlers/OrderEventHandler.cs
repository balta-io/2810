using BaltaStoreMs.SharedContext.Events.Events;

namespace BaltaStoreMs.Order.Domain.Events.Handlers
{
    public class OrderEventHandler : IEventHandler<OrderPaidEvent>
    {
        public void Handle(OrderPaidEvent command)
        {
            throw new System.NotImplementedException();
        }
    }
}