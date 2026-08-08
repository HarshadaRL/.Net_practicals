using System.Collections.Generic;
using System.Linq;
using ShopEaseConsoleApp.Models;

namespace ShopEaseConsoleApp.Repository
{
    public class OrderRepository
    {
        private readonly List<Order> orders;

        public OrderRepository()
        {
            orders = new List<Order>();
        }

        public void AddOrder(Order order)
        {
            orders.Add(order);
        }

        public List<Order> GetAllOrders()
        {
            return orders;
        }

        public List<Order> GetOrdersByCustomer(string customerName)
        {
            return orders.Where(o => o.CustomerName == customerName).ToList();
        }

        public Order GetOrderById(int orderId)
        {
            return orders.FirstOrDefault(o => o.OrderId == orderId);
        }

        public bool CancelOrder(int orderId)
        {
            Order order = GetOrderById(orderId);

            if (order == null)
                return false;

            orders.Remove(order);
            return true;
        }
    }
}