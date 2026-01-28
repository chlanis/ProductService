using System;

namespace Product.Domain.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string SKU { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public static Product Create(string name, string sku, decimal price)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Product name is required", nameof(name));
            
            if (string.IsNullOrWhiteSpace(sku))
                throw new ArgumentException("SKU is required", nameof(sku));

            if (price < 0)
                throw new ArgumentException("Price cannot be negative", nameof(price));

            return new Product
            {
                Id = Guid.NewGuid(),
                Name = name,
                SKU = sku,
                Price = price,
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            };
        }

        public void Update(string name, string sku, decimal price, bool isActive)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Product name is required", nameof(name));
            
            if (string.IsNullOrWhiteSpace(sku))
                throw new ArgumentException("SKU is required", nameof(sku));

            if (price < 0)
                throw new ArgumentException("Price cannot be negative", nameof(price));

            Name = name;
            SKU = sku;
            Price = price;
            IsActive = isActive;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
