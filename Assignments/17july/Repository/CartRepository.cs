using System.Collections.Generic;
using System.Linq;
using ShopEaseConsoleApp.Models;

namespace ShopEaseConsoleApp.Repository
{
    public class CartRepository
    {
        private readonly ShoppingCart cart;

        public CartRepository()
        {
            cart = new ShoppingCart();
        }

        public ShoppingCart GetCart()
        {
            return cart;
        }

        public void AddToCart(Product product, int quantity)
        {
            CartItem item = cart.Items.FirstOrDefault(i => i.Product.ProductId == product.ProductId);

            if (item == null)
            {
                cart.Items.Add(new CartItem(product, quantity));
            }
            else
            {
                item.Quantity += quantity;
            }
        }

        public bool RemoveFromCart(int productId)
        {
            CartItem item = cart.Items.FirstOrDefault(i => i.Product.ProductId == productId);

            if (item == null)
                return false;

            cart.Items.Remove(item);
            return true;
        }

        public bool UpdateQuantity(int productId, int quantity)
        {
            CartItem item = cart.Items.FirstOrDefault(i => i.Product.ProductId == productId);

            if (item == null)
                return false;

            item.Quantity = quantity;
            return true;
        }

        public void ClearCart()
        {
            cart.Items.Clear();
            cart.CouponCode = "";
            cart.CouponDiscount = 0;
        }
    }
}