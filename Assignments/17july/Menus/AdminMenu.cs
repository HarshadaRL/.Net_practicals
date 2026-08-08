using System;

namespace ShopEaseConsoleApp.Menus
{
    public class AdminMenu
    {
        public int Show()
        {
            Console.Clear();

            Console.WriteLine("==============================================");
            Console.WriteLine("               ADMIN DASHBOARD");
            Console.WriteLine("==============================================");
            Console.WriteLine("1. Product Management");
            Console.WriteLine("2. Category Management");
            Console.WriteLine("3. Customer Management");
            Console.WriteLine("4. Reports");
            Console.WriteLine("5. Logout");
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