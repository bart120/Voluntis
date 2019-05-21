using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Voluntis.Models
{
    public class Category
    {
        //[Key]
        //public Guid MaCle { get; set; }

        public int ID { get; set; }

        [Display(Name ="Nom de la catégorie", Prompt = "nom")]
        [Required(ErrorMessage = "champ obligatoire")]
        [StringLength(50)]
        public string Name { get; set; }
    }
}
