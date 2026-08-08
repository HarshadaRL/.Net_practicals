using System.ComponentModel.DataAnnotations;

namespace _28july.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Product name is required")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Product name must be between 5 and 100 characters")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Product price is required")]
        [Range(10, 100000, ErrorMessage = "Product price must be between 10 to 100000")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Product quantity is required")]
        [Range(10, 100, ErrorMessage = "Product quantity must be between 10 to 100")]
        public int Quantity { get; set; }
    }
}