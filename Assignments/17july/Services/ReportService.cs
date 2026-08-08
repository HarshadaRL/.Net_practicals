using System.Collections.Generic;
using System.Linq;
using ShopEaseConsoleApp.Models;
using ShopEaseConsoleApp.Repository;

namespace ShopEaseConsoleApp.Services
{
    public class ReportService
    {
        private readonly CustomerRepository customerRepository;
        private readonly ProductRepository productRepository;
        private readonly OrderRepository orderRepository;

        public ReportService(
            CustomerRepository customerRepository,
            ProductRepository productRepository,
            OrderRepository orderRepository)
        {
            this.customerRepository = customerRepository;
            this.productRepository = productRepository;
            this.orderRepository = orderRepository;
        }

        public List<Customer> GetAllCustomers()
        {
            return customerRepository.GetAllCustomers();
        }

        public List<Product> GetAllProducts()
        {
            return productRepository.GetAllProducts();
        }

        public List<Order> GetAllOrders()
        {
            return orderRepository.GetAllOrders();
        }

        public decimal GetTotalSales()
        {
            return orderRepository
                .GetAllOrders()
                .Sum(order => order.GrandTotal);
        }

        public int GetTotalCustomers()
        {
            return customerRepository
                .GetAllCustomers()
                .Count;
        }

        public int GetTotalProducts()
        {
            return productRepository
                .GetAllProducts()
                .Count;
        }

        public int GetTotalOrders()
        {
            return orderRepository
                .GetAllOrders()
                .Count;
        }
    }
}