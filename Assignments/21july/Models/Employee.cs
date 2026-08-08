using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.Models
{
    public class Employee
    {
        [Required(ErrorMessage = "Employee ID is required")]
        public int EmployeeID { get; set; }

        [Required(ErrorMessage = "Employee Name is required")]
        [StringLength(50)]
        public string EmployeeName { get; set; }

        [Required(ErrorMessage = "Department is required")]
        public string Department { get; set; }

        [Required(ErrorMessage = "Salary is required")]
        [Range(1000, 1000000)]
        public decimal Salary { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string Email { get; set; }
    }
}