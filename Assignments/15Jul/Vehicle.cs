using System;

public class Vehicle
{
    public int VehicleId { get; set; }
    public string VehicleName { get; set; } = "";
    public string VehicleType { get; set; } = "";
    public string Brand { get; set; } = "";
    public double Price { get; set; }
    public int ManufacturingYear { get; set; }

    public Vehicle(int id, string name, string type, string brand, double price, int year)
    {
        VehicleId = id;
        VehicleName = name;
        VehicleType = type;
        Brand = brand;
        Price = price;
        ManufacturingYear = year;
    }

    public virtual void Display()
    {
        Console.WriteLine("Vehicle ID : " + VehicleId);
        Console.WriteLine("Vehicle Name : " + VehicleName);
        Console.WriteLine("Vehicle Type : " + VehicleType);
        Console.WriteLine("Brand : " + Brand);
        Console.WriteLine("Price : " + Price);
        Console.WriteLine("Manufacturing Year : " + ManufacturingYear);
    }

    public virtual double CalculateDiscount()
    {
        return 0;
    }
}
