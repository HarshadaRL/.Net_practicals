using System.ComponentModel.DataAnnotations;

namespace _7_Aug.Models
{
    public class Orders
    {
        // Primary Key
        public int Id { get; set; }

        [Required(ErrorMessage = "Customer Name is required")]
        public string CustomerName { get; set; }

        // Stores order creation date, default to current date & time
        public DateTime OrderDate { get; set; } = DateTime.Now;

        // One order can contain multiple order items
        public ICollection<OrderItems> OrderItems { get; set; }
    }
}
