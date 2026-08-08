using System;

namespace ShopEaseConsoleApp.Menus
{
    public class ReportMenu
    {
        public int Show()
        {
            Console.Clear();

            Console.WriteLine("==============================================");
            Console.WriteLine("                 REPORTS");
            Console.WriteLine("==============================================");
            Console.WriteLine("1. View All Customers");
            Console.WriteLine("2. View All Products");
            Console.WriteLine("3. View All Orders");
            Console.WriteLine("4. Total Sales");
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