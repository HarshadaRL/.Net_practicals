using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        int attempts = 3;

        while (attempts > 0)
        {
            Console.Write("Enter Username : ");
            string username = Console.ReadLine();

            Console.Write("Enter Password : ");
            string password = Console.ReadLine();

            if (username == "admin" && password == "admin123")
            {
                Console.WriteLine("\nLogin Successful");
                break;
            }

            attempts--;

            Console.WriteLine("Invalid Login");

            if (attempts > 0)
            {
                Console.WriteLine("Attempts Left : " + attempts);
            }
        }

        if (attempts == 0)
        {
            throw new LoginFailedException("Login Failed 3 Times");
        }

        List<StationeryItem> items = new List<StationeryItem>();

        while (true)
        {
            Console.WriteLine("\n------------------------------------");
            Console.WriteLine("Stationery Store Management System");
            Console.WriteLine("------------------------------------");
            Console.WriteLine("1. Add Stationery Item");
            Console.WriteLine("2. Display All Items");
            Console.WriteLine("3. Search Item");
            Console.WriteLine("4. Update Item");
            Console.WriteLine("5. Delete Item");
            Console.WriteLine("6. Purchase Item");
            Console.WriteLine("7. View Low Stock Items");
            Console.WriteLine("8. Sort Items");
            Console.WriteLine("9. Exit");

            Console.Write("Enter Choice : ");

            try
            {
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:

    Console.Write("Enter Item ID : ");
    int itemId = Convert.ToInt32(Console.ReadLine());

    bool exists = false;

    foreach (StationeryItem item in items)
    {
        if (item.ItemId == itemId)
        {
            exists = true;
            break;
        }
    }

    if (exists)
    {
        throw new DuplicateItemException("Item ID already exists");
    }

    Console.Write("Enter Item Name : ");
    string itemName = Console.ReadLine();

    Console.Write("Enter Category : ");
    string category = Console.ReadLine();

    Console.Write("Enter Brand : ");
    string brand = Console.ReadLine();

    Console.Write("Enter Price : ");
    double price = Convert.ToDouble(Console.ReadLine());

    if (price <= 0)
    {
        throw new InvalidPriceException("Price must be greater than 0");
    }

    Console.Write("Enter Quantity : ");
    int quantity = Convert.ToInt32(Console.ReadLine());

    if (quantity <= 0)
    {
        throw new InvalidQuantityException("Quantity must be greater than 0");
    }

    Console.WriteLine("Select Item Type");
    Console.WriteLine("1. Notebook");
    Console.WriteLine("2. Pen");
    Console.WriteLine("3. Marker");

    int type = Convert.ToInt32(Console.ReadLine());

    StationeryItem newItem;

    if (type == 1)
    {
        Console.Write("Enter Pages : ");
        int pages = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter Paper Type : ");
        string paperType = Console.ReadLine();

        newItem = new Notebook(itemId, itemName, category, price, quantity, brand, pages, paperType);
    }
    else if (type == 2)
    {
        Console.Write("Enter Ink Color : ");
        string inkColor = Console.ReadLine();

        Console.Write("Enter Pen Type : ");
        string penType = Console.ReadLine();

        newItem = new Pen(itemId, itemName, category, price, quantity, brand, inkColor, penType);
    }
    else if (type == 3)
    {
        Console.Write("Is Permanent (true/false) : ");
        bool permanent = Convert.ToBoolean(Console.ReadLine());

        newItem = new Marker(itemId, itemName, category, price, quantity, brand, permanent);
    }
    else
    {
        Console.WriteLine("Invalid Item Type");
        break;
    }

    items.Add(newItem);

    Console.WriteLine("Item Added Successfully");

    break;

                    case 2:

    if (items.Count == 0)
    {
        Console.WriteLine("No Items Available");
    }
    else
    {
        Console.WriteLine("\n----------- Stationery Items -----------");

        foreach (StationeryItem item in items)
        {
            item.DisplayDetails();
            Console.WriteLine("--------------------------------");
        }
    }

    break;

                    case 3:

    Console.WriteLine("Search By");
    Console.WriteLine("1. Item ID");
    Console.WriteLine("2. Item Name");
    Console.Write("Enter Choice : ");

    int searchChoice = Convert.ToInt32(Console.ReadLine());

    bool found = false;

    if (searchChoice == 1)
    {
        Console.Write("Enter Item ID : ");
        int searchId = Convert.ToInt32(Console.ReadLine());

        foreach (StationeryItem item in items)
        {
            if (item.ItemId == searchId)
            {
                item.DisplayDetails();
                found = true;
                break;
            }
        }
    }
    else if (searchChoice == 2)
    {
        Console.Write("Enter Item Name : ");
        string searchName = Console.ReadLine();

        foreach (StationeryItem item in items)
        {
            if (item.ItemName.ToLower() == searchName.ToLower())
            {
                item.DisplayDetails();
                found = true;
                break;
            }
        }
    }
    else
    {
        Console.WriteLine("Invalid Choice");
        break;
    }

    if (!found)
    {
        throw new ItemNotFoundException("Item Not Found");
    }

    break;

                   case 4:

    Console.Write("Enter Item ID : ");
    int updateId = Convert.ToInt32(Console.ReadLine());

    StationeryItem updateItem = null;

    foreach (StationeryItem item in items)
    {
        if (item.ItemId == updateId)
        {
            updateItem = item;
            break;
        }
    }

    if (updateItem == null)
    {
        throw new ItemNotFoundException("Item Not Found");
    }

    Console.Write("Enter New Price : ");
    double newPrice = Convert.ToDouble(Console.ReadLine());

    if (newPrice <= 0)
    {
        throw new InvalidPriceException("Price must be greater than 0");
    }

    Console.Write("Enter New Quantity : ");
    int newQuantity = Convert.ToInt32(Console.ReadLine());

    if (newQuantity <= 0)
    {
        throw new InvalidQuantityException("Quantity must be greater than 0");
    }

    Console.Write("Enter New Brand : ");
    string newBrand = Console.ReadLine();

    updateItem.Price = newPrice;
    updateItem.Quantity = newQuantity;
    updateItem.Brand = newBrand;

    Console.WriteLine("Item Updated Successfully");

    break;

                   case 5:

    Console.Write("Enter Item ID : ");
    int deleteId = Convert.ToInt32(Console.ReadLine());

    StationeryItem deleteItem = null;

    foreach (StationeryItem item in items)
    {
        if (item.ItemId == deleteId)
        {
            deleteItem = item;
            break;
        }
    }

    if (deleteItem == null)
    {
        throw new ItemNotFoundException("Item Not Found");
    }

    Console.Write("Delete Item? (Y/N) : ");
    char choiceDelete = Convert.ToChar(Console.ReadLine().ToUpper());

    if (choiceDelete == 'Y')
    {
        items.Remove(deleteItem);
        Console.WriteLine("Item Deleted Successfully");
    }
    else if (choiceDelete == 'N')
    {
        Console.WriteLine("Delete Cancelled");
    }
    else
    {
        Console.WriteLine("Invalid Choice");
    }

    break;

                   case 6:

    Console.Write("Enter Item ID : ");
    int purchaseId = Convert.ToInt32(Console.ReadLine());

    StationeryItem purchaseItem = null;

    foreach (StationeryItem item in items)
    {
        if (item.ItemId == purchaseId)
        {
            purchaseItem = item;
            break;
        }
    }

    if (purchaseItem == null)
    {
        throw new ItemNotFoundException("Item Not Found");
    }

    Console.Write("Enter Quantity : ");
    int purchaseQty = Convert.ToInt32(Console.ReadLine());

    if (purchaseQty > purchaseItem.Quantity)
    {
        throw new InsufficientStockException("Insufficient Stock");
    }

    purchaseItem.Quantity -= purchaseQty;

    double amount = purchaseItem.Price * purchaseQty;
    double discount = amount * 0.10;      // 10% Discount
    double gst = (amount - discount) * 0.18; // 18% GST
    double total = amount - discount + gst;

    Console.WriteLine("--------------------------------");
    Console.WriteLine("             BILL              ");
    Console.WriteLine("--------------------------------");
    Console.WriteLine("Item      : " + purchaseItem.ItemName);
    Console.WriteLine("Price     : " + purchaseItem.Price);
    Console.WriteLine("Quantity  : " + purchaseQty);
    Console.WriteLine("Amount    : " + amount);
    Console.WriteLine("Discount  : " + discount);
    Console.WriteLine("GST (18%) : " + gst);
    Console.WriteLine("Total     : " + total);
    Console.WriteLine("--------------------------------");

    Console.WriteLine("Purchase Successful");

    break;

                    case 7:

    bool lowStock = false;

    Console.WriteLine("\nLow Stock Items");
    Console.WriteLine("--------------------------");

    foreach (StationeryItem item in items)
    {
        if (item.Quantity < 5)
        {
            item.DisplayDetails();
            Console.WriteLine("--------------------------");
            lowStock = true;
        }
    }

    if (!lowStock)
    {
        Console.WriteLine("No Low Stock Items");
    }

    break;

                   case 8:

    Console.WriteLine("Sort By");
    Console.WriteLine("1. Price");
    Console.WriteLine("2. Name");
    Console.WriteLine("3. Quantity");

    Console.Write("Enter Choice : ");
    int sortChoice = Convert.ToInt32(Console.ReadLine());

    if (sortChoice == 1)
    {
        items = items.OrderBy(i => i.Price).ToList();
    }
    else if (sortChoice == 2)
    {
        items = items.OrderBy(i => i.ItemName).ToList();
    }
    else if (sortChoice == 3)
    {
        items = items.OrderBy(i => i.Quantity).ToList();
    }
    else
    {
        Console.WriteLine("Invalid Choice");
        break;
    }

    Console.WriteLine("\nItems Sorted Successfully\n");

    foreach (StationeryItem item in items)
    {
        item.DisplayDetails();
        Console.WriteLine("------------------------");
    }

    break;

                    case 9:
                        Console.WriteLine("Thank You...");
                        return;

                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
