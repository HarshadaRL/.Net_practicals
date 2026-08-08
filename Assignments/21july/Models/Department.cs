using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.Models
{
    public class Department
    {
        [Required(ErrorMessage = "Department Name is required")]
        public string DepartmentName { get; set; }

        [Required(ErrorMessage = "Department Head is required")]
        public string DepartmentHead { get; set; }

        [Required(ErrorMessage = "Contact Number is required")]
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Enter Valid Contact Number")]
        public string HeadContactNumber { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string HeadEmail { get; set; }
    }
}