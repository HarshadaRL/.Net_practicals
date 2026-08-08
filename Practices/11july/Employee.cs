using System;

public class Employee
{
    public int Id { get; set; }
    public string EmpName { get; set; }
    public double MonthlySalary { get; set; }

    public Employee(int i, string e, double s)
    {
        Id = i;
        EmpName = e;
        MonthlySalary = s;
    }

    double CalculateAnnualSalary()
    {
        return MonthlySalary * 12;
    }

    public void Display()
    {
        Console.WriteLine("Id : " + Id);
        Console.WriteLine("Name : " + EmpName);
        Console.WriteLine("Monthly : " + MonthlySalary);
        Console.WriteLine("Annual : " + CalculateAnnualSalary());
        Console.WriteLine("-------------------------");
    }
}