using System;

class OOP
{
    static void Main()
    {
        // Employee emp = new Employee();

        // emp.empName = "Gitesh";
        // emp.empSalary = 2000;

        // Console.WriteLine("Employee Name: " + emp.empName);
        // Console.WriteLine("Employee Salary: " + emp.empSalary);

        ComplieTimePoly ctp = new ComplieTimePoly();
        ctp.salary(2000);
        ctp.salary(2000.50);
        ctp.salary("Gitesh", 2000.50);

        RuntimePoly rp = new RuntimePoly();
        rp.checkout(new UPIPayment(), 2000);
        rp.checkout(new NetBanking(), 5000);
    }
}