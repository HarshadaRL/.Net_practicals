using System.ComponentModel.DataAnnotations;

namespace CollegeApi.Models
{
    public class Course
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Title must be between 3 and 100 characters")]
        public string Title { get; set; } = string.Empty;

        [Range(1, 10, ErrorMessage = "Credits must be between 1 and 10")]
        public int Credits { get; set; }

        [Range(1, 52, ErrorMessage = "Duration must be between 1 and 52 weeks")]
        public int Duration { get; set; }
    }
}