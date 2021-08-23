using System.Threading.Tasks;
using BaltaStoreMs.SharedContext.Events;
using BaltaStoreMs.SharedContext.ExternalServices;

namespace BaltaStoreMs.Order.Infra.ExternalServices
{
    public class EventService : IEventService
    {
        public Task QueueAsync(IDomainEvent evt)
        {
            throw new System.NotImplementedException();
        }
    }
}