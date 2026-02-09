using AdvancedDevSample.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdvancedDevSample.Infrastruture.Repositories.Orders
{
    public class OrderEntity
    {

        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<OrderLineEntity> Lines { get; set; } = new();

        public static OrderEntity FromDomain(Order order)
            => new OrderEntity
            {
                Id = order.Id,
                CreatedAt = order.CreatedAt,
                Lines = order.Lines.Select(l =>
                    new OrderLineEntity
                    {
                        ProductId = l.ProductId,
                        Quantity = l.Quantity
                    }).ToList()
            };

        public Order ToDomain()
        {
            var order = new Order();

            foreach (var line in Lines)
                order.AddLine(line.ProductId, line.Quantity);

            return order;
        }

    }
}
