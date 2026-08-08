using System.Collections.Generic;
using ShopEaseConsoleApp.Models;
using ShopEaseConsoleApp.Repository;

namespace ShopEaseConsoleApp.Services
{
    public class AdminService
    {
        private readonly ProductRepository productRepository;
        private readonly CategoryRepository categoryRepository;
        private readonly CustomerRepository customerRepository;
        private readonly OrderRepository orderRepository;

        public AdminService(
            ProductRepository productRepository,
            CategoryRepository categoryRepository,
            CustomerRepository customerRepository,
            OrderRepository orderRepository)
        {
            this.productRepository = productRepository;
            this.categoryRepository = categoryRepository;
            this.customerRepository = customerRepository;
            this.orderRepository = orderRepository;
        }

        public List<Product> GetAllProducts()
        {
            return productRepository.GetAllProducts();
        }

        public List<Category> GetAllCategories()
        {
            return categoryRepository.GetAllCategories();
        }

        public List<Customer> GetAllCustomers()
        {
            return customerRepository.GetAllCustomers();
        }

        public List<Order> GetAllOrders()
        {
            return orderRepository.GetAllOrders();
        }
    }
}