using AdvancedDevSample.Domain.Entities;
using AdvancedDevSample.Domain.ValueObjects;


namespace AdvancedDevSample.Infrastruture.Repositories.Products
{
    public class ProductEntity
    {
        public Guid Id { get; set; }
        public decimal Price { get; set; }
        public bool IsActive { get; set; }

        public static ProductEntity FromDomain(Product product)
            => new ProductEntity
            {
                Id = product.Id,
                Price = product.Price.Value,
                IsActive = product.IsActive
            };

        public Product ToDomain()
        {
            var product = new Product(new Price(Price));

            if (!IsActive)
                product.Deactivate();

            return product;
        }

    }
}
