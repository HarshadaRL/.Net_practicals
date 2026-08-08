using System;

namespace ShopEaseConsoleApp.Menus
{
    public class CategoryMenu
    {
        public int Show()
        {
            Console.Clear();

            Console.WriteLine("==============================================");
            Console.WriteLine("          CATEGORY MANAGEMENT");
            Console.WriteLine("==============================================");
            Console.WriteLine("1. Add Category");
            Console.WriteLine("2. Update Category");
            Console.WriteLine("3. Delete Category");
            Console.WriteLine("4. View All Categories");
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