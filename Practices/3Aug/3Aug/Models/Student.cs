using System.ComponentModel.DataAnnotations;

namespace _3Aug.Models
{
    public class Student
    {
        public int Id {  get; set; }
        [Required(ErrorMessage ="Student Name is required")]
        [StringLength(30,ErrorMessage ="Student name must not be more than 30 letters")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Student Name is required")]
        public int Age { get; set; }
        [Required(ErrorMessage = "Student Age is required")]
        public string Course {  get; set; }
        [Required(ErrorMessage = "Student Name is required")]
        [EmailAddress(ErrorMessage ="Student mail is incorrect")]
        public string Email {  get; set; }
    }
}
