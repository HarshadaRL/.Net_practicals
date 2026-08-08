using System;
using ShopEaseConsoleApp.Models;
using ShopEaseConsoleApp.Repository;

namespace ShopEaseConsoleApp.Services
{
    public class AuthenticationService
    {
        private readonly CustomerRepository customerRepository;
        private readonly Admin admin;

        public AuthenticationService(CustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
            admin = new Admin();
        }

        public bool Register(Customer customer)
        {
            Customer existingCustomer = customerRepository.GetCustomerByUsername(customer.Username);

            if (existingCustomer != null)
            {
                return false;
            }

            customer.UserId = customerRepository.GetAllCustomers().Count + 1;
            customerRepository.AddCustomer(customer);

            return true;
        }

        public Customer CustomerLogin(string username, string password)
        {
            Customer customer = customerRepository.Login(username, password);

            if (customer != null)
            {
                customer.IsLoggedIn = true;
            }

            return customer;
        }

        public bool AdminLogin(string username, string password)
        {
            return admin.Username == username &&
                   admin.Password == password;
        }

        public void Logout(Customer customer)
        {
            if (customer != null)
            {
                customer.IsLoggedIn = false;
            }
        }

        public bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            Customer customer = customerRepository.GetCustomerByUsername(username);

            if (customer == null)
                return false;

            if (customer.Password != oldPassword)
                return false;

            customer.Password = newPassword;
            return true;
        }

        public bool UpdateProfile(Customer customer)
        {
            return customerRepository.UpdateCustomer(customer);
        }
    }
}