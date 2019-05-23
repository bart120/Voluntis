using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Voluntis.Models
{
    public class Book
    {
        public int ID { get; set; }

        [Display(Name = "Titre")]
        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Display(Name = "Auteur")]
        [Required]
        [StringLength(50)]
        public string Author { get; set; }

        [Display(Name = "Numéro ISBN")]
        [Required]
        [StringLength(10)]
        public string ISBN { get; set; }

        [Display(Name = "Date de publication")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dddd dd MMMM yyyy}")]
        public DateTime? PublishDate { get; set; }

        [Display(Name = "Prix")]
        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        public int CategoryID { get; set; }

        [ForeignKey("CategoryID")]
        public Category Category { get; set; }
    }
}
