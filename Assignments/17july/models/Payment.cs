using System;

namespace ShopEaseConsoleApp.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }

        public int OrderId { get; set; }

        public string PaymentMethod { get; set; }

        public decimal Amount { get; set; }

        public string PaymentStatus { get; set; }

        public DateTime PaymentDate { get; set; }

        public Payment()
        {
            PaymentDate = DateTime.Now;
            PaymentStatus = "Pending";
        }

        public Payment(int paymentId, int orderId, string paymentMethod, decimal amount)
        {
            PaymentId = paymentId;
            OrderId = orderId;
            PaymentMethod = paymentMethod;
            Amount = amount;
            PaymentDate = DateTime.Now;
            PaymentStatus = "Pending";
        }
    }
}