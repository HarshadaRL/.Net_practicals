using System;
using System.IO;

class Program
{
    public static void FileOperation()
    {
        string filePath = "student.txt";

        Console.Write("Enter Student ID: ");
        int id = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter Student Name: ");
        string? name = Console.ReadLine();

        Console.Write("Enter Student Marks: ");
        double marks = Convert.ToDouble(Console.ReadLine());

        StreamWriter writer = new StreamWriter(filePath);
        writer.WriteLine("Student ID: " + id);
        writer.WriteLine("Student Name: " + name);
        writer.WriteLine("Student Marks: " + marks);
        writer.Close();

        Console.WriteLine("\nData stored successfully.");

        Console.WriteLine("\nStored Data:");
        StreamReader reader = new StreamReader(filePath);

        while (!reader.EndOfStream)
        {
            Console.WriteLine(reader.ReadLine());
        }

        reader.Close();
    }
}