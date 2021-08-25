using System;

namespace BaltaStoreMs.SharedContext.Events
{
    public interface IDomainEvent
    {
        Guid Id { get; }
        DateTime OccuredAt { get; }
    }
}