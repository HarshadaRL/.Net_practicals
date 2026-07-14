using System;

public class Purchase : IBill
{
    public StationeryItem Item { get; set; }
    public int Quantity { get; set; }

    public Purchase(StationeryItem item, int quantity)
    {
        Item = item;
        Quantity = quantity;
    }

    public void GenerateBill()
    {
        double amount = Item.Price * Quantity;

        double discount = Item.CalculateDiscount(amount);

        double gst = (amount - discount) * 0.18;

        double total = amount - discount + gst;

        Console.WriteLine("--------------------------------");
        Console.WriteLine("              BILL              ");
        Console.WriteLine("--------------------------------");
        Console.WriteLine("Item Name : " + Item.ItemName);
        Console.WriteLine("Price     : " + Item.Price);
        Console.WriteLine("Quantity  : " + Quantity);
        Console.WriteLine("Amount    : " + amount);
        Console.WriteLine("Discount  : " + discount);
        Console.WriteLine("GST (18%) : " + gst);
        Console.WriteLine("Total     : " + total);
        Console.WriteLine("--------------------------------");
    }
}
