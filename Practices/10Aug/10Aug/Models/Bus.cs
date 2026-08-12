using System.ComponentModel.DataAnnotations;

namespace _10Aug.Models
{
    public class Bus
    {

        public int Id { get; set; }

        [Required(ErrorMessage ="BusNumber is required")]

        public string BusNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Total Seats is required")]

        public int TotalSeats { get; set; }

        [Required(ErrorMessage = "BusType is required")]

        public string BusType { get; set; } = string.Empty;
    }
}
