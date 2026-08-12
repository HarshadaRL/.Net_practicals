using System.ComponentModel.DataAnnotations;

namespace _10Aug.Models
{
    public class State
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "StateName is required")]
        [StringLength(50)]
        public string StateName { get; set; } = string.Empty;

    }
}
