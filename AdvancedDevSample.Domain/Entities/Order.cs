using AdvancedDevSample.Domain.Exceptions;
using AdvancedDevSample.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdvancedDevSample.Domain.Entities
{
    public class Order
    {

        private readonly List<OrderLine> _lines = new();

        public Guid Id { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public IReadOnlyCollection<OrderLine> Lines => _lines.AsReadOnly();

        public Order()
        {                                       
            Id = Guid.NewGuid();
            CreatedAt = DateTime.UtcNow;
        }

        public void AddLine(Guid productId, int quantity)
        {
            if (_lines.Any(l => l.ProductId == productId))
                throw new DomainException("Le produit est déjà présent dans la commande.");

            _lines.Add(new OrderLine(productId, quantity));
        }

        public void RemoveLine(Guid productId)
        {
            var line = _lines.FirstOrDefault(l => l.ProductId == productId)
                ?? throw new DomainException("Ligne de commande introuvable.");

            _lines.Remove(line);
        }

        public bool IsEmpty() => !_lines.Any();

    }
}
