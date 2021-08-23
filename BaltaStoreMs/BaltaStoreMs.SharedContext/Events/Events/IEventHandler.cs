namespace BaltaStoreMs.SharedContext.Events.Events
{
    public interface IEventHandler<in T> where T : IDomainEvent
    {
        void Handle(T command);
    }
}