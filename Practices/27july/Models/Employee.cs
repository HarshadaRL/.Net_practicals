using System.ComponentModel.DataAnnotations;

namespace _27july.Models
{
    public class Employee
    {
        [Required(ErrorMessage = "Emp id is required")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Emp name is required")]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "Name must be at least 3 letters and maximum 25 letters")]
        public string Name { get; set; }

        public string LastName { get; set; }

        [Required(ErrorMessage = "Emp dep is required")]
        [StringLength(25, ErrorMessage = "Dept cannot be more than 25 letters")]
        public string Dept { get; set; }

        [Required(ErrorMessage = "Emp phone num is required")]
        public long PhoneNum { get; set; }

        [Required(ErrorMessage = "Emp phone num is required")]
        public string Loc { get; set; }
        [Required(ErrorMessage = "Emp phone num is required")]
        public string Prof { get; set; }
    }
}