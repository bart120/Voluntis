using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Voluntis.Models
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name ="Login", Prompt = "email")]
        public string Login { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Mot de passe")]
        public string Password { get; set; }
    }
}
