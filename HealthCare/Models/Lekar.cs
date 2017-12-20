using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HealthCare.Models
{
    public class Lekar
    {
        public int ID { get; set; }
        [Required]
        [StringLength(50)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Samo slova su dozvoljena.")]
        public string Prezime { get; set; }
        [Required]
        [StringLength(50)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Samo slova su dozvoljena.")]
        public string Ime { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Zaposlen od")]
        public DateTime DatumZaposlenja { get; set; }
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email adresa")]
        public string Email { get; set; }

        [Display(Name = "Prezime i ime")]
        public string PunoIme { get { return "Dr " + Ime + " " + Prezime + ", lekar spec."; } }
        
        public virtual ICollection<LekarPregled> LekariPregledi { get; set; } //navigation prop
        public virtual ICollection<File> Files { get; set; }
    }
}