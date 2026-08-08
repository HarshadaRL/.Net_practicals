namespace ShopEaseConsoleApp.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        public string Name { get; set; }

        public string Category { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public string Brand { get; set; }

        public double Discount { get; set; }

        public double Rating { get; set; }

        public Product()
        {
        }

        public Product(
            int productId,
            string name,
            string category,
            string description,
            decimal price,
            int quantity,
            string brand,
            double discount,
            double rating)
        {
            ProductId = productId;
            Name = name;
            Category = category;
            Description = description;
            Price = price;
            Quantity = quantity;
            Brand = brand;
            Discount = discount;
            Rating = rating;
        }
    }
}