using System.ComponentModel.DataAnnotations;

namespace _22Jul.Models
{
    public class Automobile
    {
        [Required]
        public int VehicleId { get; set; }

        [Required]
        [StringLength(30)]
        public string VehicleName { get; set; } = "";

        [Required]
        public string Brand { get; set; } = "";

        [Required]
        [Range(2000, 2035)]
        public int ModelYear { get; set; }

        [Required]
        [Range(100000, 10000000)]
        public decimal Price { get; set; }

        [Required]
        public string FuelType { get; set; } = "";
    }
}
