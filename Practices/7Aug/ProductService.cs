using _7_Aug.Data;
using _7_Aug.Models;
using _7_Aug.Repository;

namespace _7_Aug.Services
{
    public class ProductService : IProductService
    {

        private readonly AppDbContext context;

        public ProductService(AppDbContext context)
        {
            this.context = context;
        }

        public Product AddProduct(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
            return product;
        }

        public Product? GetProductById(int id)
        {
            return context.Products.Find(id);
        }

        public List<Product> GetProducts()
        {
            return context.Products.ToList();
        }

    }
}
