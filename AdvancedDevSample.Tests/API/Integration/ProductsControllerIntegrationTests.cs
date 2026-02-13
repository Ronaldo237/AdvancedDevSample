using AdvancedDevSample.Application.DTOs.Products;
using AdvancedDevSample.Domain.Interfaces.Products;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http.Json;
using System.Text;

namespace AdvancedDevSample.Tests.API.Integration
{
    public class ProductsControllerIntegrationTests : IClassFixture<CustomWebApplicationFactory>
    {

        private readonly HttpClient _client;
        private readonly InMemoryProductRepositoryAsync _repo;

        public ProductsControllerIntegrationTests(CustomWebApplicationFactory factory)
        {
            _client = factory.CreateClient();
            _repo = (InMemoryProductRepositoryAsync)factory.Services.GetRequiredService<IProductRepository>();
        }

        [Fact]
        public async Task Create_Product_Should_Return_Created_And_Save()
        {
            // Arrange
            var dto = new CreateProductDto(50);

            // Act
            var response = await _client.PostAsJsonAsync("/api/products", dto);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);

            // Vérifier qu’il est bien dans le repo
            var products = await _repo.GetAllAsync();
            Assert.Single(products);
            Assert.Equal(50, products.First().Price.Value);
        }

    }
}
