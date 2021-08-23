using BaltaStoreMs.SharedContext;
using BaltaStoreMs.SharedContext.Commands;

namespace BaltaStoreMs.Order.Domain.Commands
{
    public class PlaceOrderCommand : ICommand
    {
        public string Email { get; set; }
    }
}