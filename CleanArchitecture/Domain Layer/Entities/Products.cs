using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Entities
{
    public class Product
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public int CategoryId { get; private set; }
        public Category Category { get; private set; }

        public Product(string name, decimal price, int categoryId)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name is required.");
            if (price <= 0) throw new ArgumentException("Price must be greater than zero.");
            Name = name;
            Price = price;
            CategoryId = categoryId;
        }

        public void UpdatePrice(decimal newPrice)
        {
            if (newPrice <= 0) throw new ArgumentException("Price must be greater than zero.");
            Price = newPrice;
        }
    }
}
