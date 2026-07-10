using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Task 1
        List<Employee> employees = new List<Employee>();

        PermanentEmployee e1 = new PermanentEmployee()
        {
            EmployeeId = 101,
            Name = "Harshada",
            Department = "IT"
        };
        e1.SetLeaveBalance();

        PermanentEmployee e2 = new PermanentEmployee()
        {
            EmployeeId = 102,
            Name = "Priya",
            Department = "HR"
        };
        e2.SetLeaveBalance();

        ContractEmployee e3 = new ContractEmployee()
        {
            EmployeeId = 103,
            Name = "Rahul",
            Department = "Sales"
        };
        e3.SetLeaveBalance();

        ContractEmployee e4 = new ContractEmployee()
        {
            EmployeeId = 104,
            Name = "Sneha",
            Department = "Finance"
        };
        e4.SetLeaveBalance();

        employees.Add(e1);
        employees.Add(e2);
        employees.Add(e3);
        employees.Add(e4);

        // Task 2
        Console.WriteLine("Employee Details");
        foreach (Employee e in employees)
        {
            e.DisplayDetails();
        }

        // Task 3
        List<LeaveRequest> leaves = new List<LeaveRequest>();

        leaves.Add(new LeaveRequest()
        {
            LeaveId = 1,
            EmployeeId = 101,
            NumberOfDays = 2,
            Reason = "Medical"
        });

        leaves.Add(new LeaveRequest()
        {
            LeaveId = 2,
            EmployeeId = 103,
            NumberOfDays = 5,
            Reason = "Family Function"
        });

        // Task 4
        Console.WriteLine("Leave Requests");
        foreach (LeaveRequest l in leaves)
        {
            l.DisplayLeave();
        }

        // Task 5
        Console.WriteLine("Permanent Employees");
        foreach (Employee e in employees)
        {
            if (e is PermanentEmployee)
            {
                e.DisplayDetails();
            }
        }

        // Task 6
        Console.WriteLine("Employee with ID 103");
        foreach (Employee e in employees)
        {
            if (e.EmployeeId == 103)
            {
                e.DisplayDetails();
            }
        }

        // Task 7
        Console.WriteLine("Total Employees: " + employees.Count);

        // Task 8
        Console.WriteLine("Total Leave Requests: " + leaves.Count);
    }
}
