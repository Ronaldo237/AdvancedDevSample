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

        [Fact]
        public void Change_Price_On_Inactive_Product_Should_Fail()
        {
            var product = new Product(new Price(100));
            product.Deactivate();

            Assert.Throws<DomainException>(() =>
                product.ChangePrice(200));
        }

        [Fact]
        public void Change_Price_Should_Work()
        {
            var product = new Product(new Price(100));

            product.ChangePrice(150);

            Assert.Equal(150, product.Price.Value);
        }

    }
}
