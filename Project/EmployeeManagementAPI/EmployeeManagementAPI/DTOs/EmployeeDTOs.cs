using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementAPI.DTOs
{
    // 1. REQUEST DTO: Used when creating a new employee (POST)
    // Does NOT include 'Id' (since SQL Server generates it) or navigation objects
    public class EmployeeCreateDto
    {
        [Required(ErrorMessage = "Full Name is required.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 100 characters.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email Address is required.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Phone Number is required.")]
        [Phone(ErrorMessage = "Please enter a valid phone number.")]
        public string Phone { get; set; } = string.Empty;

        [Required(ErrorMessage = "Salary is required.")]
        [Range(1000, 10000000, ErrorMessage = "Salary must be between $1,000 and $10,000,000.")]
        public decimal Salary { get; set; }

        [Required]
        public string Status { get; set; } = "Active";

        [Required]
        public DateTime JoiningDate { get; set; } = DateTime.Today;

        public int? DepartmentId { get; set; }
        public int? DesignationId { get; set; }
    }

    // 2. REQUEST DTO: Used when updating an existing employee (PUT)
    public class EmployeeUpdateDto
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Full Name is required.")]
        [StringLength(100, MinimumLength = 2)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email Address is required.")]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Phone Number is required.")]
        public string Phone { get; set; } = string.Empty;

        [Required]
        [Range(1000, 10000000)]
        public decimal Salary { get; set; }

        [Required]
        public string Status { get; set; } = "Active";

        [Required]
        public DateTime JoiningDate { get; set; }

        public int? DepartmentId { get; set; }
        public int? DesignationId { get; set; }
    }

    // 3. RESPONSE DTO: Sent back to the client (GET)
    // Contains flattened names (DepartmentName, DesignationName) to prevent JSON cycles
    public class EmployeeReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public decimal Salary { get; set; }
        public string Status { get; set; } = "Active";
        public DateTime JoiningDate { get; set; }

        public int? DepartmentId { get; set; }
        public string DepartmentName { get; set; } = "Unassigned";

        public int? DesignationId { get; set; }
        public string DesignationName { get; set; } = "Unassigned";
    }
}