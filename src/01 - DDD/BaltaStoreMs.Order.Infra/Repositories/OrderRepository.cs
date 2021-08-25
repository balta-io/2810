using System;
using System.Threading.Tasks;
using BaltaStoreMs.Order.Domain.Entities;
using BaltaStoreMs.Order.Domain.Repositories;

namespace BaltaStoreMs.Order.Infra.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        public async Task<User> GetUserAsync(string email)
        {
            await Task.Delay(12);
            return new User(email);
        }

        public async Task<Domain.Entities.Order> GetOrderAsync(Guid id)
        {
            await Task.Delay(18);
            var user = await GetUserAsync("hello@balta.io");
            return new Domain.Entities.Order(user);
        }
    }
}