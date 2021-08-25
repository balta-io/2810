using BaltaStoreMs.Order.Domain.ValueObjects;

namespace BaltaStoreMs.Order.Domain.Entities
{
    public class Transaction
    {
        public Transaction(CreditCard creditCard) => CreditCard = creditCard;
        
        public CreditCard CreditCard { get; }
    }
}