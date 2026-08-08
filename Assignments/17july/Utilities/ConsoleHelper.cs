using System;

namespace ShopEaseConsoleApp.Utilities
{
    public static class ConsoleHelper
    {
        public static void Header(string title)
        {
            Console.Clear();
            Console.WriteLine("==================================================");
            Console.WriteLine("                 ShopEase");
            Console.WriteLine("==================================================");
            Console.WriteLine(title);
            Console.WriteLine("==================================================");
        }

        public static void Success(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public static void Error(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public static void Warning(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public static void Pause()
        {
            Console.WriteLine();
            Console.Write("Press any key to continue...");
            Console.ReadKey();
        }

        public static int ReadInt(string message)
        {
            int value;

            while (true)
            {
                Console.Write(message);

                if (int.TryParse(Console.ReadLine(), out value))
                    return value;

                Error("Please enter a valid number.");
            }
        }

        public static decimal ReadDecimal(string message)
        {
            decimal value;

            while (true)
            {
                Console.Write(message);

                if (decimal.TryParse(Console.ReadLine(), out value))
                    return value;

                Error("Please enter a valid amount.");
            }
        }

        public static double ReadDouble(string message)
        {
            double value;

            while (true)
            {
                Console.Write(message);

                if (double.TryParse(Console.ReadLine(), out value))
                    return value;

                Error("Please enter a valid value.");
            }
        }

        public static string ReadString(string message)
        {
            Console.Write(message);
            return Console.ReadLine();
        }
    }
}