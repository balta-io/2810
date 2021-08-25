using System.Threading.Tasks;
using BaltaStoreMs.SharedContext.Events;

namespace BaltaStoreMs.SharedContext.ExternalServices
{
    public interface IEventService
    {
        public void Queue(IDomainEvent evt);
    }
}