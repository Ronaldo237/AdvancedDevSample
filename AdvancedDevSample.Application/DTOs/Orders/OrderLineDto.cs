using System;
using System.Collections.Generic;
using System.Text;

namespace AdvancedDevSample.Application.DTOs.Orders
{
    public record OrderLineDto
    {
        public OrderLineDto(Guid productId, int quantity)
        {
            ProductId = productId;
            Quantity = quantity;
        }

        public Guid ProductId { get; init; }
        public int Quantity { get; init; }

    }
}
