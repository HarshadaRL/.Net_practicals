using System;
using ShopEaseConsoleApp.Models;

namespace ShopEaseConsoleApp.Services
{
    public class PaymentService
    {
        public Payment MakePayment(int orderId, decimal amount, int option)
        {
            Payment payment = new Payment();

            payment.PaymentId = new Random().Next(10000, 99999);
            payment.OrderId = orderId;
            payment.Amount = amount;
            payment.PaymentDate = DateTime.Now;

            switch (option)
            {
                case 1:
                    payment.PaymentMethod = "Credit Card";
                    payment.PaymentStatus = "Success";
                    break;

                case 2:
                    payment.PaymentMethod = "Debit Card";
                    payment.PaymentStatus = "Success";
                    break;

                case 3:
                    payment.PaymentMethod = "UPI";
                    payment.PaymentStatus = "Success";
                    break;

                case 4:
                    payment.PaymentMethod = "Cash On Delivery";
                    payment.PaymentStatus = "Pending";
                    break;

                default:
                    payment.PaymentMethod = "Unknown";
                    payment.PaymentStatus = "Failed";
                    break;
            }

            return payment;
        }
    }
}