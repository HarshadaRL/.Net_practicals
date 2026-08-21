using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagementAPI.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Full Name is required.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 100 characters.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email Address is required.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        [StringLength(150, ErrorMessage = "Email cannot exceed 150 characters.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Phone Number is required.")]
        [Phone(ErrorMessage = "Please enter a valid phone number.")]
        [StringLength(20, MinimumLength = 7, ErrorMessage = "Phone number must be between 7 and 20 digits.")]
        public string Phone { get; set; } = string.Empty;

        [Required(ErrorMessage = "Salary is required.")]
        [Range(1000, 10000000, ErrorMessage = "Salary must be between $1,000 and $10,000,000.")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Salary { get; set; }

        [Required(ErrorMessage = "Status is required.")]
        public string Status { get; set; } = "Active";

        [Required(ErrorMessage = "Joining Date is required.")]
        public DateTime JoiningDate { get; set; } = DateTime.Today;

        public int? DepartmentId { get; set; }
        public Department? Department { get; set; }

        public int? DesignationId { get; set; }
        public Designation? Designation { get; set; }
    }
}