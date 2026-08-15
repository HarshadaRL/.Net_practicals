using System.ComponentModel.DataAnnotations;

namespace _06Aug_2026.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        [Required(ErrorMessage = "Customer Name is required")]
        [StringLength(100, MinimumLength = 2)]
        public string CustomerName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Product Name is required")]
        [StringLength(100, MinimumLength = 2)]
        public string ProductName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Quantity is required")]
        [Range(1, 100)]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Total Amount is required")]
        [Range(1, 100000)]
        public decimal TotalAmount { get; set; }
    }
}
