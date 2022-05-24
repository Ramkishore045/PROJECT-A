using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ClinikMangementSystem.Models
{
    public class Schedules
    {
        
        //public int AppointmentId { get; set; }
        public int PatientId { get; set; }
        [Required(ErrorMessage = "  Choose Specialization")]
        public string Specialization { get; set; }
        [Required(ErrorMessage = " Please enter DoctorName")]
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "special characters not allowed")]
        public string DoctorName { get; set; }
        [Required(ErrorMessage = " Choose VisitDate ")]
        public string VisitDate { get; set; }
        [Required(ErrorMessage = " Choose AppointmentTime ")]
        public string AppointmentTime { get; set; }

    }
}
