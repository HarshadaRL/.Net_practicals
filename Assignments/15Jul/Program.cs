using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.Write("Enter Employee Name : ");
        string empName = Console.ReadLine();

        Console.Write("Enter Employee ID : ");
        int empId = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("\nWelcome " + empName);

        List<Vehicle> vehicles = new List<Vehicle>();

        while (true)
        {
            Console.WriteLine("\n==============================");
            Console.WriteLine("ABC MOTORS");
            Console.WriteLine("Vehicle Management System");
            Console.WriteLine("==============================");

            Console.WriteLine("1. Add Vehicle");
            Console.WriteLine("2. View All Vehicles");
            Console.WriteLine("3. Search Vehicle");
            Console.WriteLine("4. Update Vehicle Price");
            Console.WriteLine("5. Delete Vehicle");
            Console.WriteLine("6. Calculate Discount");
            Console.WriteLine("7. Show Vehicle Details");
            Console.WriteLine("8. Exit");

            Console.Write("Enter your choice : ");

            try
            {
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {case 1:

    Console.Write("Enter Vehicle ID : ");
    int id = Convert.ToInt32(Console.ReadLine());

    bool exists = false;

    foreach (Vehicle v in vehicles)
    {
        if (v.VehicleId == id)
        {
            exists = true;
            break;
        }
    }

    if (exists)
    {
        Console.WriteLine("Vehicle ID already exists");
        break;
    }

    Console.Write("Enter Vehicle Name : ");
    string name = Console.ReadLine();

    Console.Write("Enter Vehicle Type (Car/Bike/Truck) : ");
    string type = Console.ReadLine();

    Console.Write("Enter Brand : ");
    string brand = Console.ReadLine();

    Console.Write("Enter Price : ");
    double price = Convert.ToDouble(Console.ReadLine());

    Console.Write("Enter Manufacturing Year : ");
    int year = Convert.ToInt32(Console.ReadLine());

    Vehicle vehicle;

    if (type.Equals("Car", StringComparison.OrdinalIgnoreCase))
    {
        vehicle = new Car(id, name, type, brand, price, year);
    }
    else if (type.Equals("Bike", StringComparison.OrdinalIgnoreCase))
    {
        vehicle = new Bike(id, name, type, brand, price, year);
    }
    else if (type.Equals("Truck", StringComparison.OrdinalIgnoreCase))
    {
        vehicle = new Truck(id, name, type, brand, price, year);
    }
    else
    {
        Console.WriteLine("Invalid Vehicle Type");
        break;
    }

    vehicles.Add(vehicle);

    Console.WriteLine("Vehicle Added Successfully");

    break;
case 2:

    if (vehicles.Count == 0)
    {
        Console.WriteLine("No Vehicles Available");
    }
    else
    {
        Console.WriteLine("---------------------------------------------------------------");
        Console.WriteLine("ID\tName\tBrand\tType\tPrice");
        Console.WriteLine("---------------------------------------------------------------");

        foreach (Vehicle v in vehicles)
        {
            Console.WriteLine(v.VehicleId + "\t" +
                              v.VehicleName + "\t" +
                              v.Brand + "\t" +
                              v.VehicleType + "\t" +
                              v.Price);
        }
    }

    break;
case 3:

    Console.Write("Enter Vehicle ID : ");
    int searchId = Convert.ToInt32(Console.ReadLine());

    bool found = false;

    foreach (Vehicle v in vehicles)
    {
        if (v.VehicleId == searchId)
        {
            Console.WriteLine("\nVehicle Found");
            v.Display();
            found = true;
            break;
        }
    }

    if (!found)
    {
        Console.WriteLine("Vehicle Not Found");
    }

    break;
case 4:

    Console.Write("Enter Vehicle ID : ");
    int updateId = Convert.ToInt32(Console.ReadLine());

    bool updated = false;

    foreach (Vehicle v in vehicles)
    {
        if (v.VehicleId == updateId)
        {
            Console.Write("Enter New Price : ");
            double newPrice = Convert.ToDouble(Console.ReadLine());

            v.Price = newPrice;

            Console.WriteLine("Vehicle Price Updated Successfully");
            updated = true;
            break;
        }
    }

    if (!updated)
    {
        Console.WriteLine("Vehicle ID does not exist");
    }

    break;
case 5:

    Console.Write("Enter Vehicle ID : ");
    int deleteId = Convert.ToInt32(Console.ReadLine());

    bool deleted = false;

    foreach (Vehicle v in vehicles)
    {
        if (v.VehicleId == deleteId)
        {
            Console.Write("Delete Vehicle? (Y/N) : ");
            string choiceDelete = Console.ReadLine();

            if (choiceDelete.Equals("Y", StringComparison.OrdinalIgnoreCase))
            {
                vehicles.Remove(v);
                Console.WriteLine("Vehicle Deleted Successfully");
            }
            else
            {
                Console.WriteLine("Delete Cancelled");
            }

            deleted = true;
            break;
        }
    }

    if (!deleted)
    {
        Console.WriteLine("Vehicle not available");
    }

    break;
case 6:

    Console.Write("Enter Vehicle ID : ");
    int discountId = Convert.ToInt32(Console.ReadLine());

    bool foundDiscount = false;

    foreach (Vehicle v in vehicles)
    {
        if (v.VehicleId == discountId)
        {
            double discount = v.CalculateDiscount();
            double finalPrice = v.Price - discount;

            Console.WriteLine("\nVehicle Price : " + v.Price);
            Console.WriteLine("Discount : " + discount);
            Console.WriteLine("Final Price : " + finalPrice);

            foundDiscount = true;
            break;
        }
    }

    if (!foundDiscount)
    {
        Console.WriteLine("Vehicle Not Found");
    }

    break;
case 7:

    Console.Write("Enter Vehicle Type (Car/Bike/Truck) : ");
    string vehicleType = Console.ReadLine();

    switch (vehicleType.ToLower())
    {
        case "car":
            Console.WriteLine("Car is a four wheeler.");
            Console.WriteLine("Suitable for family.");
            break;

        case "bike":
            Console.WriteLine("Bike is fuel efficient.");
            Console.WriteLine("Suitable for city rides.");
            break;

        case "truck":
            Console.WriteLine("Truck is used for transportation.");
            Console.WriteLine("Heavy load vehicle.");
            break;

        default:
            Console.WriteLine("Invalid Vehicle Type");
            break;
    }

    break;
case 8:

    Console.WriteLine("Thank you for using ABC Motors System.");
    return;
default:
    Console.WriteLine("Invalid Choice");
    break;
}
}
catch (FormatException)
{
    Console.WriteLine("Please enter numbers only.");
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}
}
}
}
