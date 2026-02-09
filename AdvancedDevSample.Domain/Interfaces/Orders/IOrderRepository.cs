using AdvancedDevSample.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdvancedDevSample.Domain.Interfaces.Orders
{
    public interface IOrderRepository
    {

        Task<Order?> GetByIdAsync(Guid id);
        Task<IEnumerable<Order>> GetAllAsync();
        Task AddAsync(Order order);
        Task UpdateAsync(Order order);
        Task DeleteAsync(Order order);

    }
}
