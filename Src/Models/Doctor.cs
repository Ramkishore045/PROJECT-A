using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ClinikMangementSystem.Models
{
    public class Doctor
    {
        public int DoctorId { get; set; }
        [Required (ErrorMessage= " Please enter FirstName")]
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "special characters not allowed")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = " Please enter LastName")]
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "special characters not allowed")]
        public string LastName { get; set; }
        [Required(ErrorMessage = " Choose Gender ")]
        public string Sex { get; set; }
        [Required(ErrorMessage = "  Choose Specialization")]
        public string Specialization { get; set; }
        [Required(ErrorMessage = " Choose VisitingHours ")]
        public string VisitingHours { get; set; }

    }
}
