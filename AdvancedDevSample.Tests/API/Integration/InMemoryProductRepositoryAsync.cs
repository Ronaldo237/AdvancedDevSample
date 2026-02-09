using AdvancedDevSample.Domain.Entities;
using AdvancedDevSample.Domain.Interfaces.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdvancedDevSample.Tests.API.Integration
{
    public class InMemoryProductRepositoryAsync : IProductRepository
    {
        private readonly Dictionary<Guid, Product> _store = new();

        public Task AddAsync(Product product)
        {
            _store[product.Id] = product;
            return Task.CompletedTask;
        }

        public Task UpdateAsync(Product product)
        {
            if (_store.ContainsKey(product.Id))
                _store[product.Id] = product;
            return Task.CompletedTask;
        }

        public Task DeleteAsync(Product product)
        {
            _store.Remove(product.Id);
            return Task.CompletedTask;
        }

        public Task<Product?> GetByIdAsync(Guid id)
        {
            _store.TryGetValue(id, out var product);
            return Task.FromResult(product);
        }

        public Task<IEnumerable<Product>> GetAllAsync()
        {
            return Task.FromResult(_store.Values.AsEnumerable());
        }

        // Helper pour initialiser les tests
        public void Seed(Product product)
        {
            _store[product.Id] = product;
        }
    }
}
