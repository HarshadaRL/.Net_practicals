using System;

namespace ShopEaseConsoleApp.Utilities
{
    public static class GenerateId
    {
        private static int customerId = 1000;
        private static int productId = 1000;
        private static int categoryId = 0;
        private static int orderId = 5000;
        private static int paymentId = 7000;
        private static int invoiceId = 9000;

        public static int GenerateCustomerId()
        {
            customerId++;
            return customerId;
        }

        public static int GenerateProductId()
        {
            productId++;
            return productId;
        }

        public static int GenerateCategoryId()
        {
            categoryId++;
            return categoryId;
        }

        public static int GenerateOrderId()
        {
            orderId++;
            return orderId;
        }

        public static int GeneratePaymentId()
        {
            paymentId++;
            return paymentId;
        }

        public static int GenerateInvoiceId()
        {
            invoiceId++;
            return invoiceId;
        }

        public static string GenerateTransactionId()
        {
            return "TXN" + DateTime.Now.ToString("yyyyMMddHHmmss");
        }
    }
}