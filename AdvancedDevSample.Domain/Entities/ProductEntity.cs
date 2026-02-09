using System;
using System.Collections.Generic;
using System.Text;
using AdvancedDevSample.Domain.ValueObjects; // Remplacez par le namespace correct si besoin

namespace AdvancedDevSample.Domain.Entities
{
    public class ProductEntity
    {

        public Guid Id { get; set; }
        public decimal Price { get; set; }
        public bool IsActive { get; set; }

        public ProductEntity() { }

        public ProductEntity(Guid id, decimal price, bool isActive)
        {
            Id = id;
            Price = price;
            IsActive = isActive;
        }

        /// <summary>
        /// Convertit l'entité de persistence en objet domaine.
        /// </summary>
        public Product ToDomain()
        {
            var domain = new Product();
            domain.ChangePrice(new Price(Price));
            if (!IsActive) domain.Deactivate();
            else domain.Activate();
            return domain;
        }

        /// <summary>
        /// Crée une entité de persistence à partir de l'objet domaine.
        /// </summary>
        public static ProductEntity FromDomain(Product product) =>
            new ProductEntity(product.Id, product.Price.Value, product.IsActive);

    }
}
