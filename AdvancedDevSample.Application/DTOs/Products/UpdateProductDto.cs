using System;
using System.Collections.Generic;
using System.Text;

namespace AdvancedDevSample.Application.DTOs.Products
{
    public record UpdateProductDto
    {

        public decimal Price { get; init; }
         public bool IsActive { get; init; }

    }
}
