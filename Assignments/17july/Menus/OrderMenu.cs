using System;

namespace ShopEaseConsoleApp.Menus
{
    public class OrderMenu
    {
        public int Show()
        {
            Console.Clear();

            Console.WriteLine("==============================================");
            Console.WriteLine("              ORDER HISTORY");
            Console.WriteLine("==============================================");
            Console.WriteLine("1. View Previous Orders");
            Console.WriteLine("2. Search Order");
            Console.WriteLine("3. Cancel Order");
            Console.WriteLine("4. Download Invoice");
            Console.WriteLine("5. Back");
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