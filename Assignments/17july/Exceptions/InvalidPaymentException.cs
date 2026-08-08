using System;

namespace ShopEaseConsoleApp.Exceptions
{
    public class InvalidPaymentException : Exception
    {
        public InvalidPaymentException()
            : base("Invalid payment option selected.")
        {
        }

        public InvalidPaymentException(string message)
            : base(message)
        {
        }
    }
}