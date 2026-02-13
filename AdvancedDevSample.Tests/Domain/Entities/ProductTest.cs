using AdvancedDevSample.Domain.Entities;
using AdvancedDevSample.Domain.Exceptions;
using AdvancedDevSample.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdvancedDevSample.Tests.Domain.Entities
{
    public class ProductTest
    {
        [Fact]
        public void Create_Product_With_Invalid_Price_Should_Throw()
        {
            Assert.Throws<DomainException>(() => new Product(new Price(0)));
        }

       /* [Fact]
        public void ChangePriceOnInactiveProductShouldFail(decimal newPriceValue)
        {
            var price = new Price(newPriceValue);

            // Vérification du statut actif
            if (!IsActive)
                throw new DomainException("Le produit est inactif."); // <-- Correct pour le test

            Price = price;
        }*/

        [Fact]
        public void Change_Price_Should_Work()
        {
            var product = new Product(new Price(100));

            product.ChangePrice(150);

            Assert.Equal(150, product.Price.Value);
        }

    }
}
