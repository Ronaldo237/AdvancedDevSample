using System;
using System.Collections.Generic;
using System.Text;

namespace AdvancedDevSample.Infrastruture.Repositories.Orders
{
    public class OrderLineEntity
    {

        public Guid ProductId { get; set; }
        public int Quantity { get; set; }

    }
}
