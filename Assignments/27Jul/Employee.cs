using System.ComponentModel.DataAnnotations;

namespace _27Jul.Model
{
    public class Employee
    {
        [Required(ErrorMessage = "Emp id is required")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Emp name is required")]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "Name must be at least 3 letters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Emp last name is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Emp dept is required")]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "Dept cannot be more than 25 letters")]
        public string Dept { get; set; }

        [Required(ErrorMessage = "Emp phone number is required")]
        public long PhoneNum { get; set; }

        [Required(ErrorMessage = "Emp location is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Location must be between 2 and 50 characters")]
        public string Location { get; set; }  // New property

        [Required(ErrorMessage = "Emp profile is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Profile must be between 2 and 50 characters")]
        public string Profile { get; set; }   // New property
    }
}
