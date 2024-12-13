using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Domain.Entities;
namespace CleanArchitecture.Application.Services
{
    public class ProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ProductService(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
        {
            var products = await _productRepository.GetAllAsync();
            return products.Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                CategoryName = p.Category.Name // Flattened for ease of consumption
            });
        }

        public async Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync()
        {
            var categories = await _categoryRepository.GetAllAsync();
            return categories.Select(c => new CategoryDto
            {
                Id = c.Id,
                Name = c.Name,
                ProductCount = c.Products.Count // Derived data
            });
        }

        public async Task AddProductAsync(string name, decimal price, int categoryId)
        {
            var product = new Product(name, price, categoryId); // Entity enforces rules
            await _productRepository.AddAsync(product);
        }

        public async Task UpdateProductPriceAsync(int productId, decimal newPrice)
        {
            var product = await _productRepository.GetByIdAsync(productId);
            if (product == null) throw new Exception("Product not found.");

            product.UpdatePrice(newPrice); // Business logic lives in the entity
            await _productRepository.AddAsync(product);
        }
    }
}
