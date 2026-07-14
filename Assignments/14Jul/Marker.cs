using System;

public class Marker : StationeryItem
{
    public bool Permanent { get; set; }

    public Marker(int id, string name, string category, double price,
                  int quantity, string brand, bool permanent)
        : base(id, name, category, price, quantity, brand)
    {
        Permanent = permanent;
    }

    public override void DisplayDetails()
    {
        base.DisplayDetails();
        Console.WriteLine("Permanent : " + Permanent);
    }

    public override double CalculateDiscount(double amount)
    {
        return amount * 0.08;
    }
}
