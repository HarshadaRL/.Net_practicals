using System;

namespace ShopEaseConsoleApp.Menus
{
    public class CartMenu
    {
        public int Show()
        {
            Console.Clear();

            Console.WriteLine("==============================================");
            Console.WriteLine("              SHOPPING CART");
            Console.WriteLine("==============================================");
            Console.WriteLine("1. View Cart");
            Console.WriteLine("2. Add Item");
            Console.WriteLine("3. Remove Item");
            Console.WriteLine("4. Update Quantity");
            Console.WriteLine("5. Apply Coupon");
            Console.WriteLine("6. Clear Cart");
            Console.WriteLine("7. View Total");
            Console.WriteLine("8. Back");
            Console.WriteLine("==============================================");
            Console.Write("Enter your choice : ");

            int choice;

            while (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.Write("Invalid choice. Enter again : ");
            }

            return choice;
        }
    }
}