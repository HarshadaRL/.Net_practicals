using System;

namespace ShopEaseConsoleApp.Menus
{
    public class CustomerMenu
    {
        public int Show()
        {
            Console.Clear();

            Console.WriteLine("==============================================");
            Console.WriteLine("             CUSTOMER DASHBOARD");
            Console.WriteLine("==============================================");
            Console.WriteLine("1. View Products");
            Console.WriteLine("2. Search Product");
            Console.WriteLine("3. Shopping Cart");
            Console.WriteLine("4. Checkout");
            Console.WriteLine("5. Order History");
            Console.WriteLine("6. Update Profile");
            Console.WriteLine("7. Change Password");
            Console.WriteLine("8. Logout");
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