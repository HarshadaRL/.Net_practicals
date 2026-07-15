using System;

public class Bike : Vehicle
{
    public Bike(int id, string name, string type, string brand, double price, int year)
        : base(id, name, type, brand, price, year)
    {
    }

    public override double CalculateDiscount()
    {
        return Price * 0.05;
    }

    public override void Display()
    {
        base.Display();
        Console.WriteLine("Discount : " + CalculateDiscount());
    }
}
