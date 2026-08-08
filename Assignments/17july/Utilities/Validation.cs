using System.Text.RegularExpressions;

namespace ShopEaseConsoleApp.Utilities
{
    public static class Validation
    {
        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            return Regex.IsMatch(
                email,
                @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        public static bool IsValidMobile(string mobile)
        {
            if (string.IsNullOrWhiteSpace(mobile))
                return false;

            return Regex.IsMatch(
                mobile,
                @"^[6-9][0-9]{9}$");
        }

        public static bool IsValidPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                return false;

            return password.Length >= 6;
        }

        public static bool IsValidQuantity(int quantity)
        {
            return quantity > 0;
        }

        public static bool IsValidPrice(decimal price)
        {
            return price > 0;
        }

        public static bool IsValidRating(double rating)
        {
            return rating >= 0 && rating <= 5;
        }
    }
}