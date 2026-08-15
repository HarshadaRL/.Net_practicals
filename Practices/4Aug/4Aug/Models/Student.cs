using System.ComponentModel.DataAnnotations;

namespace _4_Aug.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(25, ErrorMessage = "Name max length is 25 letters only", MinimumLength = 3)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Age is required")]
        [Range(18, 25, ErrorMessage = "Age must be 18 to 25 only")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Email id not correct")]
        public string Email { get; set; }
    }
}