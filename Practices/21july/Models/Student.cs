using System.ComponentModel.DataAnnotations;

namespace _21july.Models
{
    public class Student
    {
        [Required(ErrorMessage = "Student name is mandatory")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Student Name must be at least of 3 letters & max to 20 letters")]
        public string name { get; set; }

        [Required(ErrorMessage = "Student age is mandatory")]
        [Range(18, 25, ErrorMessage = "Student Age must be between 18 and 25")]
        public int age { get; set; }

        [Required(ErrorMessage = "Student mail id is mandatory")]
        [EmailAddress(ErrorMessage = "Email is incorrect, Enter a valid mail id")]
        public string email { get; set; }

        [Required(ErrorMessage = "Student enrolled course name is mandatory")]
        public string course { get; set; }
    }
}
