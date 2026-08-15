using System.ComponentModel.DataAnnotations;

namespace _12Aug.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        public ICollection<Booking> Bookings { get; set; }
            = new List<Booking>();
    }
}