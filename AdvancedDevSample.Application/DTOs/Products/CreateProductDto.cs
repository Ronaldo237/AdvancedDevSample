using System;
using System.Collections.Generic;
using System.Text;

namespace AdvancedDevSample.Application.DTOs.Products
{
    public record CreateProductDto
    {
        public CreateProductDto(decimal price)
        {
            Price = price;
                }

        public decimal Price { get; init; }
    }
}
