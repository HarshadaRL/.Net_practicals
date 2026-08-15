using System.ComponentModel.DataAnnotations;

namespace _03Aug2026_Ass.Models
{
    public class Batch
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Batch Name is required")]
        [StringLength(10, MinimumLength = 3,
            ErrorMessage = "Batch Name must be between 3 and 10 characters")]
        public string BatchName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Student Name is required")]
        [StringLength(20, MinimumLength = 3,
            ErrorMessage = "Student Name must be between 3 and 20 characters")]
        public string StudentName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Start Date is required")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "End Date is required")]
        public DateTime EndDate { get; set; }

        [Range(1000, 10000,
            ErrorMessage = "Fees must be between 1000 and 100000")]
        public decimal Fees { get; set; }
    }
}