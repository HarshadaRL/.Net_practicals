using System.ComponentModel.DataAnnotations;

namespace _29July.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Employee id is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Employee Name is required")]
        public long PhoneN {  get; set; }
        [Required(ErrorMessage = "Employee Phone no is required")]
        public string Email {  get; set; }
        [Required(ErrorMessage = "Employee email is required")]
        public int DeptId {  get; set; }
    }
}
