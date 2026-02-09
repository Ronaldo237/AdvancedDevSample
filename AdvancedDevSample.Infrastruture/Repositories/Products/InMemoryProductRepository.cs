using AdvancedDevSample.Domain.Entities;
using AdvancedDevSample.Domain.Interfaces.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdvancedDevSample.Infrastruture.Repositories.Products
{
    public class InMemoryProductRepository : IProductRepository
    {

        private readonly List<Product> _products = new();

        public Task AddAsync(Product product)
        {
            _products.Add(product);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(Product product)
        {
            _products.Remove(product);
            return Task.CompletedTask;
        }

        public Task<IEnumerable<Product>> GetAllAsync()
            => Task.FromResult(_products.AsEnumerable());

        public Task<Product?> GetByIdAsync(Guid id)
            => Task.FromResult(_products.FirstOrDefault(p => p.Id == id));

        public Task UpdateAsync(Product product)
            => Task.CompletedTask;
        /*
        Product IProductRepository.GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        void IProductRepository.Save(Product product)
        {
            throw new NotImplementedException();
        }
        */
    }
}
