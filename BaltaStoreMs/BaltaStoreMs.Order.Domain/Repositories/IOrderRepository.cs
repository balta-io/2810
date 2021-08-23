using System;
using System.Threading.Tasks;
using BaltaStoreMs.Order.Domain.Entities;

namespace BaltaStoreMs.Order.Domain.Repositories
{
    public interface IOrderRepository
    {
        public Task<User> GetUserAsync(string email);
        public Task<Entities.Order> GetOrderAsync(Guid id);
    }
}