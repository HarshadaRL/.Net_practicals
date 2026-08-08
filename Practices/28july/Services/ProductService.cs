using _28july.Models;

namespace _28july.Services
{
    public class ProductService : IProductService
    {
        private static List<Product> products = new List<Product>() { 
            new Product { Id=101,Name="Pen",Price=20,Quantity=205 },
            new Product { Id=102,Name="Laptop",Price=45000,Quantity=9 },
            new Product { Id=103,Name="Book",Price=70,Quantity=75 },
            new Product { Id=104,Name="Mobile",Price=15000,Quantity=15 }
        };

        public List<Product> GetAll()
        {
            return products;
        }

        public Product? GetById(int id)
        {
            return products.FirstOrDefault(p => p.Id == id);
        }

        public Product AddProduct(Product product)
        {
            products.Add(product);
            return product;
        }

        public Product? UpdateProduct(int id, Product product)
        {
            var existing = products.FirstOrDefault(p => p.Id == id);
            if (existing == null)
                return null;

            existing.Price = product.Price;
            existing.Quantity = product.Quantity;

            return existing;
        }

        public bool DeleteProduct(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null)
                return false;

            products.Remove(product);
            return true;
        }
    }
}
