using _5_Aug.Data;
using _5_Aug.Repository;
using _5_Aug.Models;
using System.Collections.Generic;
using System.Linq;

namespace _5_Aug.Services
{
    public class ProductService : IProductRepository
    {
        private readonly AppDbContext context;

        public ProductService(AppDbContext context)
        {
            this.context = context;
        }

        public void AddProduct(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
        }

        public void DeleteProduct(int id)
        {
            var product = context.Products.Find(id);

            if (product != null)
            {
                context.Products.Remove(product);
                context.SaveChanges();
            }
        }

        public List<Product> GetAll()
        {
            return context.Products.ToList();
        }

        public Product? GetProduct(int id)
        {
            return context.Products.Find(id);
        }

        public void UpdateProduct(Product product)
        {
            var existingProduct = context.Products.Find(product.Id);

            if (existingProduct != null)
            {
                existingProduct.PName = product.PName;
                existingProduct.Price = product.Price;
                existingProduct.Quantity = product.Quantity;

                context.SaveChanges();
            }
        }
    }
}