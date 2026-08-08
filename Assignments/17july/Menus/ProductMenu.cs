using System;

namespace ShopEaseConsoleApp.Menus
{
    public class ProductMenu
    {
        public int Show()
        {
            Console.Clear();

            Console.WriteLine("==============================================");
            Console.WriteLine("           PRODUCT MANAGEMENT");
            Console.WriteLine("==============================================");
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. Update Product");
            Console.WriteLine("3. Delete Product");
            Console.WriteLine("4. Search Product");
            Console.WriteLine("5. View All Products");
            Console.WriteLine("6. Back");
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