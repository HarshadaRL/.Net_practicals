using System.ComponentModel.DataAnnotations;
using _30JulyAssignment.Models;

namespace _30JulyAssignment.Models
{
    public class Employee
    {

        public int EmployeeId { get; set; }
        [Required(ErrorMessage = "First Name is mandatory")]public string FirstName { get; set; }
        [Required(ErrorMessage = "First Name is mandatory")] public string LastName { get; set; }
        [Required(ErrorMessage = "First Name is mandatory")] public string Email {  get; set; }
        public long Phone{  get; set; }
        public string DOB {  get; set; }
        public string Gender {  get; set; }
        public int Salary {  get; set; }
        [Required(ErrorMessage = "First DateOfJoining  is mandatory")] public string DateOfJoining {  get; set; }
        [Required(ErrorMessage = "First Department is mandatory")] public string Department {  get; set; }
        [Required(ErrorMessage = "First Department is mandatory")] public int DepartmentID{ get; set; }

        public string Designation {  get; set; }
        [Required(ErrorMessage = "First Status is mandatory")]
        [AllowedValues("Active", "Inactive", ErrorMessage = "Only Active or Inactive status is permitted")]
        public string Status {  get; set; }

    }
}
