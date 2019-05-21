using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Voluntis.Models
{
    public class RegisterViewModel
    {
        [Display(Name = "Nom", Prompt = "votre nom")]
        [Required(ErrorMessage = "{0} obligatoire")]
        [StringLength(30, ErrorMessage = "Le champ {0} ne doit pas dépasser {1} caractères.")]
        public string Lastname { get; set; }

        [Display(Name = "Prénom", Prompt = "votre prénom")]
        public string Firstname { get; set; }

        [Display(Name = "Mail", Prompt = "votre mail")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "{0} obligatoire")]
        [EmailAddress(ErrorMessage = "Format incorrect.")]
        public string Email { get; set; }

        [Display(Name = "Mot de passe", Prompt = "votre mot de passe")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "{0} obligatoire")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{6,}$", ErrorMessage = "Mot de passe invalide.")]
        public string Password { get; set; }

        [Display(Name = "Confirmation", Prompt = "confirmation de votre mot de passe")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "La confirmation n'est pas identique.")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Date de naissance", Prompt = "votre date de naissance")]
        [Required(ErrorMessage = "{0} obligatoire")]
        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }
    }
}
