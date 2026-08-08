using System;

namespace ShopEaseConsoleApp.Menus
{
    public class MainMenu
    {
        public int Show()
        {
            Console.Clear();

            Console.WriteLine("==============================================");
            Console.WriteLine("             ShopEase Console App");
            Console.WriteLine("==============================================");
            Console.WriteLine("1. Admin Login");
            Console.WriteLine("2. Customer Register");
            Console.WriteLine("3. Customer Login");
            Console.WriteLine("4. Exit");
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