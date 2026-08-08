using System;
using System.Collections.Generic;
using System.Net.Http.Headers;


class Program
{
    static void Main()
    {

        Genericseg<int> intObj = new Genericseg<int>();
        intObj.Print(10);

        Genericseg<string> stringObj = new Genericseg<string>();
        stringObj.Print("Gitesh");

        Genericseg<double> doubleObj = new Genericseg<double>();
        doubleObj.Print(25.5);

        List<Employee> employees = new List<Employee>();
        List<Manager> managers = new List<Manager>();

        while (true)
        {
            Console.WriteLine("Welcome to Employee and Manager System");
            Console.WriteLine("1. Add Employee");
            Console.WriteLine("2. Add Manager");
            Console.WriteLine("3. View Employee");
            Console.WriteLine("4. View Manager");
            Console.WriteLine("5. Search Employee");
            Console.WriteLine("6. Exit");

            Console.WriteLine("Enter Choice 1-6");

            try
            {
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter id : ");
                        int id = Convert.ToInt32(Console.ReadLine());

                        bool exists = false;

                        foreach (Employee emp in employees)
                        {
                            if (emp.Id == id)
                            {
                                exists = true;
                                break;
                            }
                        }

                        if (exists)
                        {
                            Console.WriteLine("Employee id already exists");
                            break;
                        }

                        Console.Write("Enter name : ");
                        string? name = Console.ReadLine();

                        Console.Write("Enter salary : ");
                        double salary = Convert.ToDouble(Console.ReadLine());

                        Employee employee = new Employee(id, name, salary);

                        employees.Add(employee);

                        Console.WriteLine("Employee Added Successfully");
                        break;

                    case 2:
                        Console.WriteLine("Enter Manager ID");
                        int mid = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter Name");
                        String? mname = Console.ReadLine();
                        Console.WriteLine("Enter Salary");
                        double msalary = Convert.ToDouble(Console.ReadLine());
                        Console.Write("Enter Department");
                        String? mdept = Console.ReadLine();

                        Manager manager = new Manager(mid, mname, msalary, mdept);
                        managers.Add(manager);

                        Console.WriteLine("Manager Added Successfully");
                        break;

                    case 3:
                        if (employees.Count == 0)
                        {
                            Console.WriteLine("No Employees in system");
                        }
                        else
                        {
                            foreach (Employee emp in employees)
                            {
                                emp.Display();
                            }
                        }
                        break;
                    case 4:
                        if (managers.Count == 0)
                        {
                            Console.WriteLine("No Manager in system");
                        }
                        else
                        {
                            foreach (Manager man in managers)
                            {
                                man.Display();
                            }
                        }
                        break;
                    case 5:
                        Console.Write("Enter Employee Id: ");
                        int searchId = Convert.ToInt32(Console.ReadLine());

                        bool found = false;

                        foreach (Employee emp in employees)
                        {
                            if (emp.Id == searchId)
                            {
                                emp.Display();
                                found = true;
                                break;
                            }
                        }

                        if (!found)
                        {
                            Console.WriteLine("Employee not found");
                        }
                        break;

                    case 6:
                        return;

                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Please Enter Number Only");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Occured" + ex.Message);
            }
        }
    }
}