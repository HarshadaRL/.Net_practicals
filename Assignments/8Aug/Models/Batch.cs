using System.ComponentModel.DataAnnotations;

namespace StudentManagementAPI.Models
{
    public class Batch
    {
        public int BatchId { get; set; }

        [Required]
        public string BatchName { get; set; } = string.Empty;

        [Required]
        public DateTime StartDate { get; set; }

        public ICollection<Student> Students { get; set; }
            = new List<Student>();
    }
}