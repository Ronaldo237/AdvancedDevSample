using AdvancedDevSample.Application.DTOs.Orders;
using AdvancedDevSample.Application.Exceptions;
using AdvancedDevSample.Domain.Entities;
using AdvancedDevSample.Domain.Interfaces.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvancedDevSample.Application.Services
{
    public class OrderService
    {
        private readonly IOrderRepository _repository;

        public OrderService(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<OrderDto>> GetAllAsync()
        {
            var orders = await _repository.GetAllAsync();

            return orders.Select(o =>
                new OrderDto(
                    o.Id,
                    o.CreatedAt,
                    o.Lines.Select(l => new OrderLineDto(l.ProductId, l.Quantity)).ToList()
                )).ToList();
        }

        public async Task<OrderDto> GetByIdAsync(Guid id)
        {
            var order = await _repository.GetByIdAsync(id)
                ?? throw new NotFoundException("Commande introuvable.");

            return new OrderDto(
                order.Id,
                order.CreatedAt,
                order.Lines.Select(l => new OrderLineDto(l.ProductId, l.Quantity)).ToList()
            );
        }

        public async Task<Guid> CreateAsync(CreateOrderDto dto)
        {
            var order = new Order();

            foreach (var line in dto.Lines)
                order.AddLine(line.ProductId, line.Quantity);

            await _repository.AddAsync(order);
            return order.Id;
        }

        public async Task DeleteAsync(Guid id)
        {
            var order = await _repository.GetByIdAsync(id)
                ?? throw new NotFoundException("Commande introuvable.");

            await _repository.DeleteAsync(order);
        }
    }
}
