using System.Threading.Tasks;
using BaltaStoreMs.SharedContext.Events;

namespace BaltaStoreMs.SharedContext.ExternalServices
{
    public interface IEventService
    {
        public Task QueueAsync(IDomainEvent evt);
    }
}