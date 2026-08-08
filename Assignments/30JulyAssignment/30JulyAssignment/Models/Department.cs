using System.ComponentModel.DataAnnotations;

namespace _30JulyAssignment.Models
{
    public class Department
    {
        [Required(ErrorMessage ="Department Name is mandatory")]
        [StringLength(50)]
        
        public string DeptName {  get; set; }
        [Required]
       
        public int DeptId { get; set; }
        [Required(ErrorMessage="Status is mandatory")]
        [AllowedValues("Active","Inactive", ErrorMessage ="Only Active or Inactive status is permitted")]
        public string DeptStatus {  get; set; }

    }
}
