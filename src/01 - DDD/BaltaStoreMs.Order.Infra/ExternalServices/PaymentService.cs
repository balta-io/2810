using System.Threading.Tasks;
using BaltaStoreMs.Order.Domain.Entities;
using BaltaStoreMs.Order.Domain.ExternalServices;
using BaltaStoreMs.Order.Domain.ValueObjects;

namespace BaltaStoreMs.Order.Infra.ExternalServices
{
    public class PaymentService : IPaymentService
    {
        public async Task<Transaction> PayAsync(CreditCard creditCard)
        {
            await Task.Delay(5);
            return new Transaction(new CreditCard
            {
                Name = "JOÃO JOHN",
                Number = "4111111111111111",
                Expiration = "05/29",
                Cvv = "123"
            });
        }
    }
}