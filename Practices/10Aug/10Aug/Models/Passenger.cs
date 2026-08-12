using System.ComponentModel.DataAnnotations;

namespace _10Aug.Models
{
    public class Passenger
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Phone No is required")]
        [Phone(ErrorMessage = "Number is not correct")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Email Id is required")]
        [Phone(ErrorMessage = "Email Id is not correct")]
        public string Email { get; set; }

    }
}
