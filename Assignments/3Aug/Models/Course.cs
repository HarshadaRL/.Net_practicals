using System.ComponentModel.DataAnnotations;

namespace _03Aug2026_Ass.Models
{
    public class Course
    {
        public int CourseId { get; set; }

        [Required(ErrorMessage = "Student Name is required")]
        [StringLength(20, MinimumLength = 3,
            ErrorMessage = "Student Name must be between 3 and 20 characters")]
        public string StudentName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Course Name is required")]
        [StringLength(20, MinimumLength = 3,
            ErrorMessage = "Course Name must be between 3 and 20 characters")]
        public string CourseName { get; set; } = string.Empty;
    }
}