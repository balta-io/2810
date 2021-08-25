using System.Threading.Tasks;
using BaltaStoreMs.Order.Domain.Entities;
using BaltaStoreMs.Order.Domain.ValueObjects;

namespace BaltaStoreMs.Order.Domain.ExternalServices
{
    public interface IPaymentService
    {
        public Task<Transaction> PayAsync(CreditCard creditCard);
    }
}