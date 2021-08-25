using System.Threading.Tasks;

namespace BaltaStoreMs.SharedContext.Commands.Handlers
{
    public interface ICommandHandler<in T> where T : ICommand
    {
        Task HandleAsync(T command);
    }
}