using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementMVC.Models
{
    public class Designation
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Designation Title is required.")]
        [StringLength(60, MinimumLength = 2, ErrorMessage = "Designation Title must be between 2 and 60 characters.")]
        [Display(Name = "Designation Title")]
        public string Name { get; set; } = string.Empty;

        [StringLength(250, ErrorMessage = "Description cannot exceed 250 characters.")]
        [Display(Name = "Description")]
        public string Description { get; set; } = string.Empty;
    }
}