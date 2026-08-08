using System;

namespace ShopEaseConsoleApp.Models
{
    public class Invoice
    {
        public int InvoiceId { get; set; }

        public int OrderId { get; set; }

        public string CustomerName { get; set; }

        public DateTime InvoiceDate { get; set; }

        public decimal SubTotal { get; set; }

        public decimal Discount { get; set; }

        public decimal GST { get; set; }

        public decimal GrandTotal { get; set; }

        public Invoice()
        {
            InvoiceDate = DateTime.Now;
        }

        public Invoice(
            int invoiceId,
            int orderId,
            string customerName,
            decimal subTotal,
            decimal discount,
            decimal gst,
            decimal grandTotal)
        {
            InvoiceId = invoiceId;
            OrderId = orderId;
            CustomerName = customerName;
            InvoiceDate = DateTime.Now;
            SubTotal = subTotal;
            Discount = discount;
            GST = gst;
            GrandTotal = grandTotal;
        }

        public void DisplayInvoice()
        {
            Console.WriteLine("\n========================================");
            Console.WriteLine("              ShopEase");
            Console.WriteLine("========================================");
            Console.WriteLine($"Invoice ID     : {InvoiceId}");
            Console.WriteLine($"Order ID       : {OrderId}");
            Console.WriteLine($"Customer Name  : {CustomerName}");
            Console.WriteLine($"Invoice Date   : {InvoiceDate}");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine($"Subtotal       : ₹{SubTotal}");
            Console.WriteLine($"Discount       : ₹{Discount}");
            Console.WriteLine($"GST            : ₹{GST}");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine($"Grand Total    : ₹{GrandTotal}");
            Console.WriteLine("========================================");
            Console.WriteLine("Thank You For Shopping With ShopEase!");
            Console.WriteLine("========================================");
        }
    }
}