using ShopEaseConsoleApp.Models;

namespace ShopEaseConsoleApp.Services
{
    public class InvoiceService
    {
        public Invoice GenerateInvoice(Order order)
        {
            Invoice invoice = new Invoice
            {
                InvoiceId = order.OrderId + 5000,
                OrderId = order.OrderId,
                CustomerName = order.CustomerName,
                SubTotal = order.SubTotal,
                Discount = order.Discount,
                GST = order.GST,
                GrandTotal = order.GrandTotal
            };

            return invoice;
        }

        public void PrintInvoice(Order order)
        {
            Invoice invoice = GenerateInvoice(order);
            invoice.DisplayInvoice();
        }
    }
}