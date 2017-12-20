using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HealthCare.Models
{
    public enum Participacija
    {
        Da, Ne
    }
    public class LekarPregled
    {
        public int LekarPregledID { get; set; }
        public int LekarID { get; set; }
        public int PregledID { get; set; }
        public Participacija? Participacija { get; set; }

        public virtual Pregled Pregled { get; set; } //nav prop
        public virtual Lekar Lekar { get; set; } //nav prop
    }
}