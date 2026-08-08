using System.ComponentModel.DataAnnotations;

namespace _28July.Models
{
    public class Product
    {

        public int Id { get; set; }
        [Required(ErrorMessage ="Product Name is required")]
        [StringLength(100, MinimumLength =5, ErrorMessage ="Product Name must be between 5 to 100 letters")]
        public string  Name { get; set; }
        [Required(ErrorMessage = "Product Price is required")]
        [Range(10,100000, ErrorMessage ="Product price must be 10 to 100000")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Product Quantity is required")]
        [Range(10,100,ErrorMessage ="Product quantity must be 10 to 100")]
        public int Quantity {  get; set; }
    }
}
