using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ClinikMangementSystem.Models
{
    public class Patient
    {
        public int PatientId { get; set; }
        [Required(ErrorMessage = " Please enter FirstName")]
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "special characters not allowed")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = " Please enter LastName")]
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "special characters not allowed")]
        public string LastName { get; set; }
        [Required(ErrorMessage = " Choose Gender ")]
        public string Sex { get; set; }
        [Required]
        [Range(0,120, ErrorMessage = " *age must be less than or equal to 120  ")]
       
        public int Age { get; set; }

        [Required(ErrorMessage = " Please enter DOB")]
        public string  Date_of_birth { get; set; }

    }
}
