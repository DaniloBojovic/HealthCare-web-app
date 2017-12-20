using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HealthCare.Models
{
    public class Pregled
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)] //Kljuc se unosi u kodu
        [Range(1, int.MaxValue, ErrorMessage = "Unesite ispravne vrednosti.")]
        [Display(Name = "Šifra Pregleda")]
        public int PregledID { get; set; }

        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Samo slova su dozvoljena.")]
        [Display(Name = "Vrsta Pregleda")]
        public string Naziv { get; set; }

        public string Opis { get; set; }
        
        public virtual ICollection<LekarPregled> LekariPregledi { get; set; } //Veza 1 na vise
        public virtual ICollection<Karton> Kartoni { get; set; } //Veza 1 na vise Nav. prop
    }
}