using AdvancedDevSample.Application.DTOs.Products;
using AdvancedDevSample.Application.Exceptions;
using AdvancedDevSample.Domain.Entities;
using AdvancedDevSample.Domain.Interfaces.Products;
using AdvancedDevSample.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdvancedDevSample.Application.Services
{
    public class ProductService
    {

        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            var products = await _repository.GetAllAsync();

            return products.Select(p =>
                new ProductDto(p.Id, p.Price.Value, p.IsActive));
        }

        public async Task<ProductDto> GetByIdAsync(Guid id)
        {
            var product = await _repository.GetByIdAsync(id)
                ?? throw new NotFoundException("Produit introuvable.");

            return new ProductDto(product.Id, product.Price.Value, product.IsActive);
        }

        public async Task<Guid> CreateAsync(CreateProductDto dto)
        {
            var product = new Product(new Price(dto.Price));
            await _repository.AddAsync(product);
            return product.Id;
        }

        public async Task UpdateAsync(Guid id, UpdateProductDto dto)
        {
            var product = await _repository.GetByIdAsync(id)
                ?? throw new NotFoundException("Produit introuvable.");

            product.ChangePrice(dto.Price);

            if (dto.IsActive) product.Activate();
            else product.Deactivate();

            await _repository.UpdateAsync(product);
        }

        public async Task DeleteAsync(Guid id)
        {
            var product = await _repository.GetByIdAsync(id)
                ?? throw new NotFoundException("Produit introuvable.");

            await _repository.DeleteAsync(product);
        }

    }
}
