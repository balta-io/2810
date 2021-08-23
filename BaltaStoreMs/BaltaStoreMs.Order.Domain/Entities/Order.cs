using System;
using System.Collections.Generic;
using BaltaStoreMs.SharedContext.Entities;

namespace BaltaStoreMs.Order.Domain.Entities
{
    public class Order : Entity, IAggregateRoot
    {
        public Order(User user)
        {
            User = user;
            LastUpdateDate = DateTime.Now;
        }

        private List<Transaction> _transactions = new();

        public event EventHandler OnOrderPlaced;
        public event EventHandler OnOrderPaid;

        public User User { get; }
        public DateTime LastUpdateDate { get; private set; }
        public IReadOnlyCollection<Transaction> Transactions => _transactions;

        public void Place()
        {
            LastUpdateDate = DateTime.Now;
        }

        public void Pay(Transaction transaction)
        {
            LastUpdateDate = DateTime.Now;
            _transactions.Add(transaction);
        }
    }
}