using System.ComponentModel.DataAnnotations;

namespace StudentManagementAPI.Models
{
    public class Course
    {
        public int CourseId { get; set; }

        [Required]
        public string CourseName { get; set; } = string.Empty;

        [Range(1, 24)]
        public int Duration { get; set; }

        [Required]
        public int TeacherId { get; set; }

        public Teacher? Teacher { get; set; }

        public ICollection<StudentCourse> StudentCourses { get; set; }
            = new List<StudentCourse>();
    }
}