using System.ComponentModel.DataAnnotations;

namespace _22july.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is mandatory")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Price is mandatory")]
        [Range(10, 10000, ErrorMessage = "Price must be between 10 and 10000")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Category is mandatory")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Stock is mandatory")]
        public int Stock { get; set; }
    }
}