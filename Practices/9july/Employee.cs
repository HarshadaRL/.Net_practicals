using System;

class Employee
{
    private string? _empName;
 

    public String empName
    {
        get { return _empName; }
        set{ return _empName = value; }
    }
    private double _empSalary;
    public double empSalary
    {
        get { return _empSalary; }
        set
        {
            if (value >= 100)
                _empSalary = value;
        }
    }
}