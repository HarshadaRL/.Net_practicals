using System.Collections.Generic;
using System.Linq;

namespace ShopEaseConsoleApp.Models
{
    public class ShoppingCart
    {
        public List<CartItem> Items { get; set; }

        public string CouponCode { get; set; }

        public decimal CouponDiscount { get; set; }

        public ShoppingCart()
        {
            Items = new List<CartItem>();
            CouponCode = "";
            CouponDiscount = 0;
        }

        public decimal SubTotal
        {
            get
            {
                return Items.Sum(item => item.Total);
            }
        }

        public decimal GST
        {
            get
            {
                return SubTotal * 0.18m;
            }
        }

        public decimal GrandTotal
        {
            get
            {
                return (SubTotal + GST) - CouponDiscount;
            }
        }
    }
}