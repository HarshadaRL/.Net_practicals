using System.ComponentModel.DataAnnotations;

namespace _03Aug2026_Ass.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Student Name is required")]
        [StringLength(20, MinimumLength = 3,
            ErrorMessage = "Student Name must be between 3 and 20 characters")]
        public string Name { get; set; } = string.Empty;

        [Range(18, 80, ErrorMessage = "Student Age must be between 18 and 80")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Student Course is required")]
        [StringLength(20, MinimumLength = 4,
            ErrorMessage = "Student Course must be between 4 and 20 characters")]
        public string Course { get; set; } = string.Empty;

        [Required(ErrorMessage = "Student Mail id is required")]
        [EmailAddress(ErrorMessage = "Student mail is incorrect")]
        public string Email { get; set; } = string.Empty;
    }
}