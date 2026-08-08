using System;

public class Manager : Employee
{
    public string dept;

    public Manager(int i, string e, double s, string d)
        : base(i, e, s)
    {
        dept = d;
    }

    public void DisplayManager()
    {
        Display();
        Console.WriteLine("Dept : " + dept);
        Console.WriteLine("------------------------------");
    }
}