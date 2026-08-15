using _5_Aug.Models;
using System.ComponentModel.DataAnnotations;

namespace _5_Aug.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Product name is mandatory")]
        [StringLength(50, ErrorMessage = "Maximum length for product must be below 50")]
        public string PName { get; set; }

        [Required(ErrorMessage = "Product price is mandatory")]
        [Range(5, 1000000, ErrorMessage = "Price can be between 5 to 1000000")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Product quantity is mandatory")]
        [Range(1, 1000, ErrorMessage = "Quantity cannot be below 1 & above 1000")]
        public int Quantity { get; set; }
    }
}