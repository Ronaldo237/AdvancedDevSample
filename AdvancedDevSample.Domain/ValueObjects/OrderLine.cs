using AdvancedDevSample.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdvancedDevSample.Domain.ValueObjects
{

    /// <summary>
    /// Ligne de commande (immutabilité métier)
    /// </summary>
    public class OrderLine
    {
        public Guid ProductId { get; }
        public int Quantity { get; }

        public OrderLine(Guid productId, int quantity)
        {
            if (productId == Guid.Empty)
                throw new DomainException("ProductId invalide.");

            if (quantity <= 0)
                throw new DomainException("La quantité doit être supérieure à zéro.");

            ProductId = productId;
            Quantity = quantity;
        }
    }
}
