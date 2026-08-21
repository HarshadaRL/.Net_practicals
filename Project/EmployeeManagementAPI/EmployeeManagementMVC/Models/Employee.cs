using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementMVC.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Full Name is required.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 100 characters.")]
        [Display(Name = "Full Name")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email Address is required.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        [Display(Name = "Email Address")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Phone Number is required.")]
        [Phone(ErrorMessage = "Please enter a valid phone number.")]
        [Display(Name = "Phone Number")]
        public string Phone { get; set; } = string.Empty;

        [Required(ErrorMessage = "Salary is required.")]
        [Range(1000, 10000000, ErrorMessage = "Salary must be between $1,000 and $10,000,000.")]
        [Display(Name = "Salary ($)")]
        public decimal Salary { get; set; }

        [Required(ErrorMessage = "Status is required.")]
        public string Status { get; set; } = "Active";

        [Required(ErrorMessage = "Joining Date is required.")]
        [DataType(DataType.Date)]
        [Display(Name = "Joining Date")]
        public DateTime JoiningDate { get; set; } = DateTime.Today;

        [Display(Name = "Department")]
        public int? DepartmentId { get; set; }
        public string DepartmentName { get; set; } = "Unassigned";

        [Display(Name = "Designation")]
        public int? DesignationId { get; set; }
        public string DesignationName { get; set; } = "Unassigned";
    }
}