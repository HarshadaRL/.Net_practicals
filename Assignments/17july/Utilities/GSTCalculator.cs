namespace ShopEaseConsoleApp.Utilities
{
    public static class GSTCalculator
    {
        private const decimal GstRate = 18m;

        public static decimal CalculateGST(decimal amount)
        {
            return amount * GstRate / 100;
        }

        public static decimal CalculateTotalWithGST(decimal amount)
        {
            return amount + CalculateGST(amount);
        }
    }
}