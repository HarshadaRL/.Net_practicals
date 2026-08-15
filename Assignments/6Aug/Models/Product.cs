using System.ComponentModel.DataAnnotations;

namespace _06Aug_2026.Models
{
    public class Product
    {
        [Key]
        public int PId { get; set; }

        [Required(ErrorMessage = "Product Name is required")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Product Name must be between 2 and 20 characters")]
        public string PName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Price is required")]
        [Range(15, 100000, ErrorMessage = "Price must be between 15 and 100000")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Quantity is required")]
        [Range(1, 100, ErrorMessage = "Quantity must be between 1 and 100")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Product Stock Availability is required")]
        [StringLength(3, ErrorMessage = "Product stock can be max 3 letters")]
        public string Availability { get; set; } = string.Empty;
    }
}
