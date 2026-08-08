using ShopEaseConsoleApp.Models;
using ShopEaseConsoleApp.Repository;

namespace ShopEaseConsoleApp.Services
{
    public class CartService
    {
        private readonly CartRepository cartRepository;

        public CartService(CartRepository cartRepository)
        {
            this.cartRepository = cartRepository;
        }

        public ShoppingCart GetCart()
        {
            return cartRepository.GetCart();
        }

        public void AddToCart(Product product, int quantity)
        {
            cartRepository.AddToCart(product, quantity);
        }

        public bool RemoveFromCart(int productId)
        {
            return cartRepository.RemoveFromCart(productId);
        }

        public bool UpdateQuantity(int productId, int quantity)
        {
            return cartRepository.UpdateQuantity(productId, quantity);
        }

        public void ClearCart()
        {
            cartRepository.ClearCart();
        }

        public bool ApplyCoupon(string couponCode)
        {
            ShoppingCart cart = cartRepository.GetCart();

            if (couponCode == "SAVE10")
            {
                cart.CouponCode = couponCode;
                cart.CouponDiscount = 500;
                return true;
            }

            if (couponCode == "SAVE20")
            {
                cart.CouponCode = couponCode;
                cart.CouponDiscount = 1000;
                return true;
            }

            return false;
        }
    }
}