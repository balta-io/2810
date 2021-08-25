using System;

namespace BaltaStoreMs.SharedContext.Events
{
    public interface IDomainEvent
    {
        public DateTime OccuredAt { get; set; }
    }
}