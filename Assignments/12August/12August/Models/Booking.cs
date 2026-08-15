using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _12Aug.Models
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int CustomerId { get; set; }

        [Required]
        public DateTime Checkin { get; set; }

        [Required]
        public DateTime Checkout { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal TotalAmt { get; set; }

        [Required]
        public string Status { get; set; } = "Confirmed";

        public Customer? Customer { get; set; }

        public ICollection<BookingRoom> BookingRooms { get; set; }
            = new List<BookingRoom>();
    }
}