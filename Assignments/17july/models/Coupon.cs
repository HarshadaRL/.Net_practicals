namespace ShopEaseConsoleApp.Models
{
    public class Coupon
    {
        public string CouponCode { get; set; }

        public decimal DiscountAmount { get; set; }

        public bool IsActive { get; set; }

        public Coupon()
        {
            IsActive = true;
        }

        public Coupon(string couponCode, decimal discountAmount)
        {
            CouponCode = couponCode;
            DiscountAmount = discountAmount;
            IsActive = true;
        }
    }
}