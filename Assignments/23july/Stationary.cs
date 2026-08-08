using System.ComponentModel.DataAnnotations;

namespace _23_July.Models
{
    public class Stationary
    {



       
            [Required(ErrorMessage = "Name is mandatory")]
            public string Name { get; set; }

            [Required(ErrorMessage = "Price is mandatory")]
            [Range(10, 100000)]
            public int Price { get; set; }

            [Required(ErrorMessage = "Brand is mandatory")]
            public string Brand { get; set; }

            [Required(ErrorMessage = "Stock is mandatory")]
            public int stock { get; set; }

  

}
}
