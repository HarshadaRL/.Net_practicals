using System.Collections.Generic;
using System.Linq;
using ShopEaseConsoleApp.Models;

namespace ShopEaseConsoleApp.Repository
{
    public class CustomerRepository
    {
        private readonly List<Customer> customers;

        public CustomerRepository()
        {
            customers = new List<Customer>();
        }

        public void AddCustomer(Customer customer)
        {
            customers.Add(customer);
        }

        public List<Customer> GetAllCustomers()
        {
            return customers;
        }

        public Customer GetCustomerByUsername(string username)
        {
            return customers.FirstOrDefault(c => c.Username == username);
        }

        public Customer Login(string username, string password)
        {
            return customers.FirstOrDefault(c =>
                c.Username == username &&
                c.Password == password);
        }

        public bool UpdateCustomer(Customer customer)
        {
            Customer existing = GetCustomerByUsername(customer.Username);

            if (existing == null)
                return false;

            existing.FullName = customer.FullName;
            existing.Email = customer.Email;
            existing.Mobile = customer.Mobile;
            existing.Address = customer.Address;

            return true;
        }

        public bool ChangePassword(string username, string newPassword)
        {
            Customer customer = GetCustomerByUsername(username);

            if (customer == null)
                return false;

            customer.Password = newPassword;
            return true;
        }

        public bool DeleteCustomer(string username)
        {
            Customer customer = GetCustomerByUsername(username);

            if (customer == null)
                return false;

            customers.Remove(customer);
            return true;
        }
    }
}