using System.Collections.Generic;
using ShopEaseConsoleApp.Models;
using ShopEaseConsoleApp.Repository;

namespace ShopEaseConsoleApp.Services
{
    public class ProductService
    {
        private readonly ProductRepository productRepository;

        public ProductService(ProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public void AddProduct(Product product)
        {
            productRepository.AddProduct(product);
        }

        public List<Product> GetAllProducts()
        {
            return productRepository.GetAllProducts();
        }

        public Product GetProductById(int productId)
        {
            return productRepository.GetProductById(productId);
        }

        public List<Product> SearchProduct(string keyword)
        {
            return productRepository.SearchProduct(keyword);
        }

        public bool UpdateProduct(Product product)
        {
            return productRepository.UpdateProduct(product);
        }

        public bool DeleteProduct(int productId)
        {
            return productRepository.DeleteProduct(productId);
        }
    }
}