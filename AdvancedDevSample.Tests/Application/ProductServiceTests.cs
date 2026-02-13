using AdvancedDevSample.Application.DTOs.Products;
using AdvancedDevSample.Application.Services;
using AdvancedDevSample.Domain.Exceptions;
using AdvancedDevSample.Tests.Application.Fakes;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdvancedDevSample.Tests.Application
{
    public class ProductServiceTests
    {

        [Fact]
        public async Task Create_Product_Should_Work()
        {
            // Arrange
            var repo = new FakeProductRepository();
            var service = new ProductService(repo);

            var dto = new CreateProductDto(50); // prix strictement positif

            // Act
            var id = await service.CreateAsync(dto);

            // Assert
            Assert.NotEqual(Guid.Empty, id);

            var savedProduct = await repo.GetByIdAsync(id);
            Assert.NotNull(savedProduct);
            Assert.Equal(50, savedProduct.Price.Value);
        }

        [Fact]
        public async Task Create_Product_With_NonPositive_Price_Should_Fail()
        {
            var repo = new FakeProductRepository();
            var service = new ProductService(repo);

            var dto = new CreateProductDto(0); // prix invalide

            await Assert.ThrowsAsync<DomainException>(async () =>
                await service.CreateAsync(dto)
            );
        }

    }
}
