using System;

class ComplieTimePoly
{
    public void salary(int salary)
    {
        Console.WriteLine("Employee Salary: " + salary);
    }

    public void salary(double salary)
    {
        Console.WriteLine("Employee Salary: " + salary);
    }

    public void salary(string name, double salary)
    {
        Console.WriteLine("Employee Name: " + name);
        Console.WriteLine("Employee Salary: " + salary);
    }
}