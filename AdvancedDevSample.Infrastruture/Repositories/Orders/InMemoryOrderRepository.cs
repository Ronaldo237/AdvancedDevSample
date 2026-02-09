using AdvancedDevSample.Domain.Entities;
using AdvancedDevSample.Domain.Interfaces.Orders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdvancedDevSample.Infrastruture.Repositories.Orders
{
    public class InMemoryOrderRepository : IOrderRepository
    {

        private readonly List<Order> _orders = new();

        public Task AddAsync(Order order)
        {
            _orders.Add(order);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(Order order)
        {
            _orders.Remove(order);
            return Task.CompletedTask;
        }

        public Task<IEnumerable<Order>> GetAllAsync()
            => Task.FromResult(_orders.AsEnumerable());

        public Task<Order?> GetByIdAsync(Guid id)
            => Task.FromResult(_orders.FirstOrDefault(o => o.Id == id));

        public Task UpdateAsync(Order order)
            => Task.CompletedTask;

    }
}
