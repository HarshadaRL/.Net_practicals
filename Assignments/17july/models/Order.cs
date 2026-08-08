using System;
using System.Collections.Generic;
using System.Linq;

namespace ShopEaseConsoleApp.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        public DateTime OrderDate { get; set; }

        public string CustomerName { get; set; }

        public List<CartItem> Items { get; set; }

        public decimal SubTotal { get; set; }

        public decimal Discount { get; set; }

        public decimal GST { get; set; }

        public decimal GrandTotal { get; set; }

        public string PaymentMethod { get; set; }

        public string PaymentStatus { get; set; }

        public string DeliveryAddress { get; set; }

        public Order()
        {
            Items = new List<CartItem>();
            OrderDate = DateTime.Now;
        }

        public int TotalItems()
        {
            return Items.Sum(item => item.Quantity);
        }
    }
}