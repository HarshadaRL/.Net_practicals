using System;

public class Student
{
    public string? Name { get; set; }
    public int RollNumber { get; set; }
    public char Gender { get; set; }
    public string? DOB { get; set; }
    public double Height { get; set; }
    public string? College { get; set; }

    public void DisplayDetails()
    {
        Console.WriteLine("Student Details :");
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Roll Number : {RollNumber}");
        Console.WriteLine($"Gender: {Gender}");
        Console.WriteLine($"DOB: {DOB}");
        Console.WriteLine($"Height: {Height}");
        Console.WriteLine($"College: {College}");
    }
}