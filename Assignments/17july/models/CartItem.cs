namespace ShopEaseConsoleApp.Models
{
    public class CartItem
    {
        public Product Product { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice
        {
            get
            {
                return Product.Price;
            }
        }

        public decimal DiscountAmount
        {
            get
            {
                return UnitPrice * Quantity * (decimal)(Product.Discount / 100);
            }
        }

        public decimal Total
        {
            get
            {
                return (UnitPrice * Quantity) - DiscountAmount;
            }
        }

        public CartItem()
        {
        }

        public CartItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }
    }
}