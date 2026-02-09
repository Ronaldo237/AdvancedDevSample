using System;
using System.Collections.Generic;
using System.Text;

namespace AdvancedDevSample.Application.DTOs.Orders
{
    public record CreateOrderDto
    {

        public List<OrderLineDto> Lines { get; init; } = new();
    }
}
