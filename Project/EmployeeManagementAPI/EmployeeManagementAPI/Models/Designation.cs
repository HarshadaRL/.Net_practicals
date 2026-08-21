using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EmployeeManagementAPI.Models
{
    public class Designation
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Designation Title is required.")]
        [StringLength(60, MinimumLength = 2, ErrorMessage = "Designation Title must be between 2 and 60 characters.")]
        public string Name { get; set; } = string.Empty;

        [StringLength(250, ErrorMessage = "Description cannot exceed 250 characters.")]
        public string Description { get; set; } = string.Empty;

        [JsonIgnore]
        public ICollection<Employee>? Employees { get; set; }
    }
}