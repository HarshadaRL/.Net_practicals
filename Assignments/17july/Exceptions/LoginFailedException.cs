using System;

namespace ShopEaseConsoleApp.Exceptions
{
    public class LoginFailedException : Exception
    {
        public LoginFailedException()
            : base("Invalid username or password.")
        {
        }

        public LoginFailedException(string message)
            : base(message)
        {
        }
    }
}