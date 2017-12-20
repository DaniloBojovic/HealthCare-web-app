using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HealthCare.Models
{
    public class Pacijent
    {
        public int ID { get; set; } //PK
        [Required]
        [StringLength(50)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Samo slova su dozvoljena.")]
        public string Prezime { get; set; }
        [Required]
        [StringLength(50)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Samo slova su dozvoljena.")]
        public string Ime { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)] //Stavljen u ovaj format zbog edit dela!
        [Display(Name = "Datum Registracije")]
        public DateTime DatumRegistracije { get; set; }
        [Required]
        [Display(Name = "Naziv firme")]
        public string Firma { get; set; }

        [Display(Name = "Prezime i ime")]
        public string PunoIme { get { return Prezime + ", " + Ime; } }

        public virtual ICollection<Karton> Kartoni { get; set; } //Navigation property - sadrzace sva zakaz. za odredjen PacijentID
        public virtual ICollection<File> Files { get; set; } //1 Pacijent vise Fajlova
    }
}