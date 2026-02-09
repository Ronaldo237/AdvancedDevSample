using AdvancedDevSample.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdvancedDevSample.Domain.Interfaces.Products
{
    public interface IProductRepository
    {

      // public void Save(Product product);

       // public Product GetById(Guid id);

        Task<Product?> GetByIdAsync(Guid id);
        Task<IEnumerable<Product>> GetAllAsync();
        Task AddAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(Product product);


    }
}
