using System.ComponentModel.DataAnnotations;

namespace _12Aug.DTOs
{
    public class BookingRequest
    {
        [Required]
        public int CustomerId { get; set; }

        [Required]
        public DateTime Checkin { get; set; }

        [Required]
        public DateTime Checkout { get; set; }

        [Required]
        public List<int> RoomIds { get; set; } = new List<int>();
    }
}