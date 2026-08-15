using System;

class Program
{
    static void Main(string[] args)
    {

        Console.WriteLine("1. Run Task 1: Package Processor");
        Console.WriteLine("2. Run Task 2: Power Analyzer");
        Console.Write("Enter your choice 1 or 2 ");

        string? choice = Console.ReadLine();

        Console.WriteLine();

        if (choice == "1")
        {
            Problem_1 processor = new Problem_1();
            processor.Run();
        }
        else if (choice == "2")
        {
            Problem_2 analyzer = new Problem_2();
            analyzer.Run();
        }
        else
        {
            Console.WriteLine("Invalid choice. Exiting...");
        }
    }
}
