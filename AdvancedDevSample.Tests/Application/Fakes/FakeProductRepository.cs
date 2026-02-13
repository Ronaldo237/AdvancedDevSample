using AdvancedDevSample.Domain.Entities;
using AdvancedDevSample.Domain.Interfaces.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdvancedDevSample.Tests.Application.Fakes
{
    public class FakeProductRepository : IProductRepository
    {
        public bool WasSaved { get; private set; }

        // Déclarez le champ _produit comme nullable pour corriger l'avertissement CS8618
        private readonly Product? _produit;

        private readonly List<Product> _products = new();

        public FakeProductRepository(Product produit)
        {
            _produit = produit;
        }

        public FakeProductRepository()
        {
        }

        public Product GetById(Guid id)
        {
            if (_produit is null)
                throw new InvalidOperationException("Aucun produit n'est défini dans ce repository factice.");
            return _produit;
        }
        

        public void Save(Product product)
        {
            WasSaved = true;
        }

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
    }
}
