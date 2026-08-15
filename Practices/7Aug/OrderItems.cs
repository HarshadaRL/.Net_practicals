namespace _7_Aug.Models
{
    public class OrderItems
    {
        public int Id { get; set; }

        // Foreign key referencing Product table
        public int ProductId { get; set; }

        // Allows access to product details
        public Product? Product { get; set; }

        // Foreign key referencing Order table
        public int OrderId { get; set; }

        // Allows access to order details
        public Orders? Order { get; set; }

        // Number of units ordered
        public int Quantity { get; set; }
    }
}
// One Order -------- One To Many -------- OrderItem
// One Order contains many OrderItems

// OrderItem -------- Many to One -------- Product
// One Product can appear in many OrderItems

// OrderItems acts as bridge between Order & Product