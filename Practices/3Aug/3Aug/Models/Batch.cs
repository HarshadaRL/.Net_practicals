using System.ComponentModel.DataAnnotations;

namespace _3Aug.Models
{
    public class Batch
    {
        [Required(ErrorMessage ="ID is required")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name{ get; set; }
        [Required(ErrorMessage = "No of students in batch is required")]
        public int NoOfStudents {  get; set; }
    }
}
