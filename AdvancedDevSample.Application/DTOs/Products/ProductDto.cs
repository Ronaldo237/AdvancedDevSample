using System;
using System.Collections.Generic;
using System.Text;

namespace AdvancedDevSample.Application.DTOs.Products
{
    public record ProductDto
    {
        public ProductDto(Guid id, decimal value, bool isActive)
        {
            Id = id;
            Value = value;
            IsActive = isActive;
        }

        public Guid Id { get; init; }
        public bool IsActive { get; init; }
        public decimal Price { get; init; }
        public decimal Value { get; }
    }
}
