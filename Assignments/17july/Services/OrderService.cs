using System;
using System.Collections.Generic;
using ShopEaseConsoleApp.Models;
using ShopEaseConsoleApp.Repository;

namespace ShopEaseConsoleApp.Services
{
    public class OrderService
    {
        private readonly OrderRepository orderRepository;

        public OrderService(OrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public Order PlaceOrder(
            Customer customer,
            ShoppingCart cart,
            string paymentMethod,
            string paymentStatus,
            string deliveryAddress)
        {
            Order order = new Order();

            order.OrderId = orderRepository.GetAllOrders().Count + 1001;
            order.OrderDate = DateTime.Now;
            order.CustomerName = customer.FullName;
            order.Items = new List<CartItem>(cart.Items);
            order.SubTotal = cart.SubTotal;
            order.Discount = cart.CouponDiscount;
            order.GST = cart.GST;
            order.GrandTotal = cart.GrandTotal;
            order.PaymentMethod = paymentMethod;
            order.PaymentStatus = paymentStatus;
            order.DeliveryAddress = deliveryAddress;

            orderRepository.AddOrder(order);

            return order;
        }

        public List<Order> GetAllOrders()
        {
            return orderRepository.GetAllOrders();
        }

        public List<Order> GetCustomerOrders(string customerName)
        {
            return orderRepository.GetOrdersByCustomer(customerName);
        }

        public Order SearchOrder(int orderId)
        {
            return orderRepository.GetOrderById(orderId);
        }

        public bool CancelOrder(int orderId)
        {
            return orderRepository.CancelOrder(orderId);
        }
    }
}