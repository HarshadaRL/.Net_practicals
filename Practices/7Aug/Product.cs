using System.ComponentModel.DataAnnotations;

namespace _7_Aug.Models
{
    

public class Product
    {
        // Primary Key
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [Range(15, 1000000)]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [Range(0, 1000)]
        public int Stock { get; set; }

        // One product can appear in many order items
        // EF uses this property to load related OrderItems records
        public ICollection<OrderItems>? OrderItems { get; set; }
    }
}

