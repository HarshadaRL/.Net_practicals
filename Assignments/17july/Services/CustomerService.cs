using System.Collections.Generic;
using ShopEaseConsoleApp.Models;
using ShopEaseConsoleApp.Repository;

namespace ShopEaseConsoleApp.Services
{
    public class CustomerService
    {
        private readonly CustomerRepository customerRepository;

        public CustomerService(CustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public void AddCustomer(Customer customer)
        {
            customerRepository.AddCustomer(customer);
        }

        public List<Customer> GetAllCustomers()
        {
            return customerRepository.GetAllCustomers();
        }

        public Customer GetCustomer(string username)
        {
            return customerRepository.GetCustomerByUsername(username);
        }

        public bool UpdateCustomer(Customer customer)
        {
            return customerRepository.UpdateCustomer(customer);
        }

        public bool ChangePassword(string username, string newPassword)
        {
            return customerRepository.ChangePassword(username, newPassword);
        }

        public bool DeleteCustomer(string username)
        {
            return customerRepository.DeleteCustomer(username);
        }
    }
}