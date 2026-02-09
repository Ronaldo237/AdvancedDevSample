using AdvancedDevSample.Domain.Entities;
using AdvancedDevSample.Domain.Interfaces.Products;
using AdvancedDevSample.Domain.ValueObjects;
using AdvancedDevSample.Infrastruture.Repositories.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdvancedDevSample.Infrastruture.Repositories
{
    public class EfProductRepository : IProductRepository
    {

        // Simuler une base de données en mémoire
        private readonly List<Product> _products = new();

        // Ajouter un produit
        public Task AddAsync(Product product)
        {
            _products.Add(product);
            Console.WriteLine($"Produit ajouté : {product.Id} - Prix : {product.Price.Value}");
            return Task.CompletedTask;
        }

        // Supprimer un produit
        public Task DeleteAsync(Product product)
        {
            _products.Remove(product);
            Console.WriteLine($"Produit supprimé : {product.Id}");
            return Task.CompletedTask;
        }

        // Lister tous les produits
        public Task<IEnumerable<Product>> GetAllAsync()
        {
            return Task.FromResult(_products.AsEnumerable());
        }

        // Récupérer un produit par son Id
        public Task<Product?> GetByIdAsync(Guid id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            return Task.FromResult(product);
        }

        // Mettre à jour un produit
        public Task UpdateAsync(Product product)
        {
            var index = _products.FindIndex(p => p.Id == product.Id);
            if (index >= 0)
            {
                _products[index] = product;
                Console.WriteLine($"Produit mis à jour : {product.Id} - Prix : {product.Price.Value}");
            }
            return Task.CompletedTask;
        }

    }
}
