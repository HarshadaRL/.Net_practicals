using System;

public class Notebook : StationeryItem
{
    public int Pages { get; set; }
    public string PaperType { get; set; }

    public Notebook(int id, string name, string category, double price,
                    int quantity, string brand, int pages, string paperType)
        : base(id, name, category, price, quantity, brand)
    {
        Pages = pages;
        PaperType = paperType;
    }

    public override void DisplayDetails()
    {
        base.DisplayDetails();
        Console.WriteLine("Pages : " + Pages);
        Console.WriteLine("Paper Type : " + PaperType);
    }

    public override double CalculateDiscount(double amount)
    {
        return amount * 0.10;
    }
}
