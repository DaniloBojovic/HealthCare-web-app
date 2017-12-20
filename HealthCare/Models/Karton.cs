using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HealthCare.Models
{
    public enum Izvestaj
    {
        Sposoban, Nesposoban, Delimicno_Sposoban
    }

    public class Karton
    {
        public int KartonID { get; set; } //PK
        public int PregledID { get; set; } //FK
        public int PacijentID { get; set; } //FK
        [DisplayFormat(NullDisplayText = "Nema izvestaja")]
        public Izvestaj? Izvestaj { get; set; }

        public virtual Pregled Pregled { get; set; } //nav prop
        public virtual Pacijent Pacijent { get; set; } //nav prop
    }
}