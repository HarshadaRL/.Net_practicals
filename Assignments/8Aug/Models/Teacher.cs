using System.ComponentModel.DataAnnotations;

namespace StudentManagementAPI.Models
{
    public class Teacher
    {
        public int TeacherId { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Range(1, 40)]
        public int Experience { get; set; }

        // One teacher -> many courses
        public ICollection<Course> Courses { get; set; }
            = new List<Course>();
    }
}