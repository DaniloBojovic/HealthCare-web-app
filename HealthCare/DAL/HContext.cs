using HealthCare.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace HealthCare.DAL
{
    public class HContext : DbContext
    {
        public HContext() : base("HContext") // Connection string
        {
        }
        public DbSet<Pacijent> Pacijenti { get; set; }
        public DbSet<Karton> Kartoni { get; set; }
        public DbSet<Pregled> Pregledi { get; set; }
        public DbSet<Lekar> Lekari { get; set; }
        public DbSet<LekarPregled> LekariPregledi { get; set; }
        public DbSet<File> Files { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}