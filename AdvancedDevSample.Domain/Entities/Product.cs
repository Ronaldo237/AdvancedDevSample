using AdvancedDevSample.Domain.Exceptions;
using AdvancedDevSample.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdvancedDevSample.Domain.Entities
{
    public class Product
    {
        private Guid guid;

        /// <summary>
        /// Représente un produit vendable.
        /// </summary>
        public Guid Id { get; private set; } // Identité
        public Price Price { get; private set; } // Invariant encapsulé dans Price
        public bool IsActive { get; private set; } // true par défaut

       // public Product(Price price) : this(Guid.NewGuid(), price) { }

        public Product(Guid id, Price price, bool isActive)
        {
            Id = id == Guid.Empty ? Guid.NewGuid() : id;
            Price = price; // Price valide par construction
            IsActive = isActive;
        }

        // Constructeur requis par certains ORMs ; protégé pour empêcher l'utilisation publique.
        protected Product(Guid guid)
        {
            IsActive = true;
            this.guid = guid;
            Price = default!; // Ajouté pour satisfaire l'exigence de non-nullabilité
            Id = Guid.NewGuid();
        }

        // surcharge avec guid + price (utile si appelé depuis d'autres parties)
        public Product(Guid guid, Price price)
        {
            this.guid = guid;
            Id = guid == Guid.Empty ? Guid.NewGuid() : guid;
            Price = price;
            IsActive = true;
        }

        public Product(Price price)
        {
            Price = price;
            Id = Guid.NewGuid();
            IsActive = true;
        }

        // Constructeur sans paramètres requis si d'autres fichiers font new Product()
        public Product()
        {
            Price = default!; // Ajouté pour satisfaire l'exigence de non-nullabilité
            IsActive = true;
            Id = Guid.NewGuid();
        }

        public void ChangePrice(Price newPrice)
        {
            // Règle métier : le produit ne doit pas être inactif
            if (!IsActive)
            {
                throw new DomainException("Le produit est inactif.");
            }

            // Invariant déjà garanti par Price
            Price = newPrice;
        }

        public void Deactivate() => IsActive = false;
        public void Activate() => IsActive = true;

        public void ChangePrice(decimal newPriceValue)
        {
            throw new NotImplementedException();
        }
    }
}
