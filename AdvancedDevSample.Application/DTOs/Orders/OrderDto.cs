using System;
using System.Collections.Generic;
using System.Text;

namespace AdvancedDevSample.Application.DTOs.Orders
{
    public record OrderDto
    {

        public Guid Id { get; init; }
        public DateTime CreatedAt { get; init; }
        public IReadOnlyCollection<OrderLineDto> Lines { get; init; }

        public OrderDto(Guid id, DateTime createdAt, IReadOnlyCollection<OrderLineDto> lines)
        {
            Id = id;
            CreatedAt = createdAt;
            Lines = lines;
        }
    }
}
