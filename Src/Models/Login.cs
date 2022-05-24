using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ClinikMangementSystem.Models
{
    public class Login
    {
        [Required(ErrorMessage ="Please Enter Your UserName ")]
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "special characters not allowed")]
        public String UserName { get; set; }
        [Required(ErrorMessage = "Please Enter Your Password ")]
        public string Password { get; set; }
    }
}
