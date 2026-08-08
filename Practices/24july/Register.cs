using System.ComponentModel.DataAnnotations;

namespace _24_July.Models
{
    
        




        public class Register
        {
            [Required(ErrorMessage = "Student name is mandatory to submit form")]
            [StringLength(20, MinimumLength = 3, ErrorMessage = "Invalid name please enetr correctly")]
            public string name { get; set; }

            [Required(ErrorMessage = "Student age is mandatory to submit form")]
            [Range(18, 25, ErrorMessage = "Student Age must be between 18 and 25")]
            public int age { get; set; }

            [Required(ErrorMessage = "Student age is mandatory to submit form")]
            public string email { get; set; }
            [Required(ErrorMessage = "Must enetr the course")]

            public string course { get; set; }














        }
    }



