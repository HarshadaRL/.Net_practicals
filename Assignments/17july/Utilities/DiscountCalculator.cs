namespace ShopEaseConsoleApp.Utilities
{
    public static class DiscountCalculator
    {
        public static decimal CalculateProductDiscount(decimal price, double discountPercentage)
        {
            return price * (decimal)discountPercentage / 100;
        }

        public static decimal CalculateFinalPrice(decimal price, double discountPercentage)
        {
            decimal discount = CalculateProductDiscount(price, discountPercentage);
            return price - discount;
        }

        public static decimal ApplyCoupon(decimal amount, string couponCode)
        {
            switch (couponCode.ToUpper())
            {
                case "SAVE10":
                    return amount - 500;

                case "SAVE20":
                    return amount - 1000;

                case "WELCOME":
                    return amount - 250;

                default:
                    return amount;
            }
        }
    }
}