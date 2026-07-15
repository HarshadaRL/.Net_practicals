using System;

public class Truck : Vehicle
{
    public Truck(int id, string name, string type, string brand, double price, int year)
        : base(id, name, type, brand, price, year)
    {
    }

    public override double CalculateDiscount()
    {
        return Price * 0.12;
    }

    public override void Display()
    {
        base.Display();
        Console.WriteLine("Discount : " + CalculateDiscount());
    }
}
