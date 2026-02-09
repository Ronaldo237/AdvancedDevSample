using AdvancedDevSample.Domain.Entities;
using AdvancedDevSample.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdvancedDevSample.Tests.Domain.Entities
{
    public class OrderTests
    {

        [Fact]
        public void Create_Order_Should_Be_Empty()
        {
            var order = new Order();

            Assert.True(order.IsEmpty());
        }

        [Fact]
        public void Add_Line_Should_Work()
        {
            var order = new Order();
            var productId = Guid.NewGuid();

            order.AddLine(productId, 2);

            Assert.Single(order.Lines);
        }

        [Fact]
        public void Add_Same_Product_Twice_Should_Fail()
        {
            var order = new Order();
            var productId = Guid.NewGuid();

            order.AddLine(productId, 1);

            Assert.Throws<DomainException>(() =>
                order.AddLine(productId, 2));
        }

        [Fact]
        public void Remove_Unknown_Line_Should_Fail()
        {
            var order = new Order();

            Assert.Throws<DomainException>(() =>
                order.RemoveLine(Guid.NewGuid()));
        }

    }
}
