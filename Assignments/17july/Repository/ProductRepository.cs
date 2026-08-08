using System.Collections.Generic;
using System.Linq;
using ShopEaseConsoleApp.Models;

namespace ShopEaseConsoleApp.Repository
{
    public class ProductRepository
    {
        private readonly List<Product> products;

        public ProductRepository()
        {
            products = new List<Product>();

            products.Add(new Product(1001, "Laptop", "Electronics", "Dell Inspiron", 65000, 20, "Dell", 10, 4.6));
            products.Add(new Product(1002, "Mouse", "Electronics", "Wireless Mouse", 800, 50, "Logitech", 5, 4.5));
            products.Add(new Product(1003, "Keyboard", "Electronics", "Mechanical Keyboard", 2500, 30, "Redragon", 8, 4.7));
        }

        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        public List<Product> GetAllProducts()
        {
            return products;
        }

        public Product GetProductById(int productId)
        {
            return products.FirstOrDefault(p => p.ProductId == productId);
        }

        public List<Product> SearchProduct(string keyword)
        {
            keyword = keyword.ToLower();

            return products.Where(p =>
                p.Name.ToLower().Contains(keyword) ||
                p.Category.ToLower().Contains(keyword) ||
                p.Brand.ToLower().Contains(keyword))
                .ToList();
        }

        public bool UpdateProduct(Product product)
        {
            Product existing = GetProductById(product.ProductId);

            if (existing == null)
                return false;

            existing.Name = product.Name;
            existing.Category = product.Category;
            existing.Description = product.Description;
            existing.Price = product.Price;
            existing.Quantity = product.Quantity;
            existing.Brand = product.Brand;
            existing.Discount = product.Discount;
            existing.Rating = product.Rating;

            return true;
        }

        public bool DeleteProduct(int productId)
        {
            Product product = GetProductById(productId);

            if (product == null)
                return false;

            products.Remove(product);
            return true;
        }
    }
}