namespace HealthCare.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using HealthCare.Models;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<HealthCare.DAL.HContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(HealthCare.DAL.HContext context)
        {
            var pacijenti = new List<Pacijent>
            {
                new Pacijent{Ime="Danilo",Prezime="Bojovic",DatumRegistracije=DateTime.Parse("2011-09-05"), Firma="Jomla doo"},
                new Pacijent{Ime="Biljana",Prezime="Lukic",DatumRegistracije=DateTime.Parse("2014-04-05"), Firma="Dynamic doo"},
                new Pacijent{Ime="Milos",Prezime="Tisma",DatumRegistracije=DateTime.Parse("2005-09-11"), Firma="Mega doo "},
                new Pacijent{Ime="Jovan",Prezime="Kokic",DatumRegistracije=DateTime.Parse("2015-02-08"), Firma="Prom doo"},
                new Pacijent{Ime="Baja",Prezime="Bajic",DatumRegistracije=DateTime.Parse("2015-02-18"), Firma="Genius doo"},
                new Pacijent{Ime="Marina",Prezime="Govedarica",DatumRegistracije=DateTime.Parse("2015-05-28"), Firma="Elektromehanika doo"},
                new Pacijent{Ime="Robert",Prezime="Sabo",DatumRegistracije=DateTime.Parse("2010-02-08"), Firma="Uni doo"},
                new Pacijent{Ime="Marija",Prezime="Papic",DatumRegistracije=DateTime.Parse("2017-09-20"), Firma="Svilar doo"},
                new Pacijent{Ime="Ana",Prezime="Tot",DatumRegistracije=DateTime.Parse("2015-05-28"), Firma="Elektromehanika doo"},
                new Pacijent{Ime="Jon",Prezime="Moldovan",DatumRegistracije=DateTime.Parse("2017-09-20"), Firma="Svilar doo"}
            };
            foreach (Pacijent p in pacijenti)
            {
                var pacInDB = context.Pacijenti.Where
                    (x => x.Ime == p.Ime &&
                    x.Prezime == p.Prezime &&
                    x.DatumRegistracije == p.DatumRegistracije &&
                    x.Firma == p.Firma).SingleOrDefault();
                if (pacInDB == null)
                {
                    context.Pacijenti.Add(p);
                }
            }
            //pacijenti.ForEach(p => context.Pacijenti.AddOrUpdate(x => x.Prezime, p));
            context.SaveChanges();

            var lekari = new List<Lekar>
            {
                new Lekar {Ime= "Marija", Prezime="Radosevic", DatumZaposlenja = DateTime.Parse("1990-03-11"), Email = "radosevic@gmail.com" },
                new Lekar {Ime= "Vladimir", Prezime="Tomic", DatumZaposlenja = DateTime.Parse("1999-08-08"), Email = "tomic@gmail.com"  },
                new Lekar {Ime= "Zlatko", Prezime="Sobot", DatumZaposlenja = DateTime.Parse("2009-01-05"), Email = "sobot@gmail.com"  },
                new Lekar {Ime= "Ozren", Prezime="Milosevic", DatumZaposlenja = DateTime.Parse("2001-09-11"), Email = "milosevic@gmail.com"  },
                new Lekar {Ime= "Dragana", Prezime="Mijatov", DatumZaposlenja = DateTime.Parse("2005-05-12"), Email = "mijatov@gmail.com"  },
                new Lekar {Ime= "Slobodan", Prezime="Bajcetic", DatumZaposlenja = DateTime.Parse("2002-05-12"), Email = "bajcetic@gmail.com"  }
            };
            foreach(Lekar l in lekari)
            {
                var lekarInDB = context.Lekari.Where
                    (x => x.Ime == l.Ime &&
                    x.Prezime == l.Prezime &&
                    x.DatumZaposlenja == l.DatumZaposlenja &&
                    x.Email == l.Email).SingleOrDefault();
                if(lekarInDB == null)
                {
                    context.Lekari.AddOrUpdate(l);
                }
            }
            //lekari.ForEach(p => context.Lekari.AddOrUpdate(x => x.Prezime, p));
            context.SaveChanges();

            var pregledi = new List<Pregled>
            {
                new Pregled {PregledID=1000,Naziv="Opsti lekarski pregled",Opis="Pregled obuhvata izdavanje lekarskog izvestaja o zdravstvenoj i radnoj sposobnosti."},
                new Pregled {PregledID=1001,Naziv="Prethodni lekarski pregled",Opis="Pregled obuhvata izdavanje izveštaja o radnoj sposobnosti za rad."},
                new Pregled {PregledID=1002,Naziv="Periodicni lekarski pregled",Opis="Pregled obuhvata izdavanje izveštaja o radnoj sposobnosti za rad."},
                new Pregled {PregledID=1003,Naziv="Prethodni lekarski pregled za mesta sa povisenim rizikom",Opis="Pregled obuhvata izdavanje izveštaja o radnoj sposobnosti za rad na radnom mestu sa povisenim rizikom."},
                new Pregled {PregledID=1004,Naziv="Periodicni lekarski pregled za mesta sa povisenim rizikom",Opis="Pregled obuhvata izdavanje izveštaja o radnoj sposobnosti za rad na radnom mestu sa povisenim rizikom."},
                new Pregled {PregledID=1005,Naziv="Kontrolni periodicni pregled",Opis="Pregled obuhvata izdavanje izvestaja o daljem lecenju po potrebi i izdavanje izveštaja o radnoj sposobnosti"},
                new Pregled {PregledID=1006,Naziv="Ciljani pregled",Opis="Pregled obuhvata ciljano upucivanje na dalji tok lecenja, po odluci lekara specijaliste medicine rada i izdavanjem izvestaja o radnoj sposobnosti zaposlenog na tom radnom mestu" }
            };
            pregledi.ForEach(p => context.Pregledi.AddOrUpdate(x => x.Naziv, p));
            context.SaveChanges();

            var kartoni = new List<Karton>
            {
                //new Karton {PacijentID = pacijenti.Single(p => p.Prezime == "Bojovic").ID, PregledID = pregledi.Single(x => x.Naziv == "Opsti lekarski pregled").PregledID, Izvestaj = Izvestaj.Sposoban },
                //new Karton {PacijentID = pacijenti.Single(p => p.Prezime == "Bojovic").ID, PregledID = pregledi.Single(x => x.Naziv == "Prethodni lekarski pregled").PregledID, Izvestaj = Izvestaj.Sposoban },
                //new Karton {PacijentID = pacijenti.Single(p => p.Prezime == "Bojovic").ID, PregledID = pregledi.Single(x => x.Naziv == "Periodicni lekarski pregled").PregledID, Izvestaj = Izvestaj.Sposoban },
                //new Karton {PacijentID = pacijenti.Single(p => p.Prezime == "Lukic").ID, PregledID = pregledi.Single(x => x.Naziv == "Opsti lekarski pregled").PregledID, Izvestaj = Izvestaj.Sposoban },
                //new Karton {PacijentID = pacijenti.Single(p => p.Prezime == "Lukic").ID, PregledID = pregledi.Single(x => x.Naziv == "Kontrolni periodicni pregled").PregledID, Izvestaj = Izvestaj.Sposoban },
                //new Karton {PacijentID = pacijenti.Single(p => p.Prezime == "Lukic").ID, PregledID = pregledi.Single(x => x.Naziv == "Ciljani pregled").PregledID, Izvestaj = Izvestaj.Sposoban },
                //new Karton {PacijentID = pacijenti.Single(p => p.Prezime == "Tisma").ID, PregledID = pregledi.Single(x => x.Naziv == "Periodicni lekarski pregled").PregledID, Izvestaj = Izvestaj.Sposoban },
                //new Karton {PacijentID = pacijenti.Single(p => p.Prezime == "Tisma").ID, PregledID = pregledi.Single(x => x.Naziv == "Periodicni lekarski pregled za mesta sa povisenim rizikom").PregledID, Izvestaj = Izvestaj.Nesposoban },
                //new Karton {PacijentID = pacijenti.Single(p => p.Prezime == "Kokic").ID, PregledID = pregledi.Single(x => x.Naziv == "Periodicni lekarski pregled").PregledID, Izvestaj = Izvestaj.Sposoban },
                //new Karton {PacijentID = pacijenti.Single(p => p.Prezime == "Bajic").ID, PregledID = pregledi.Single(x => x.Naziv == "Prethodni lekarski pregled").PregledID, Izvestaj = Izvestaj.Nesposoban },
                //new Karton {PacijentID = pacijenti.Single(p => p.Prezime == "Govedarica").ID, PregledID = pregledi.Single(x => x.Naziv == "Ciljani pregled").PregledID, Izvestaj = Izvestaj.Sposoban },
                //new Karton {PacijentID = pacijenti.Single(p => p.Prezime == "Sabo").ID, PregledID = pregledi.Single(x => x.Naziv == "Opsti lekarski pregled").PregledID, Izvestaj = Izvestaj.Sposoban },
                //new Karton {PacijentID = pacijenti.Single(p => p.Prezime == "Papic").ID, PregledID = pregledi.Single(x => x.Naziv == "Prethodni lekarski pregled").PregledID, Izvestaj = Izvestaj.Sposoban },
                //new Karton {PacijentID = pacijenti.Single(p => p.Prezime == "Moldovan").ID, PregledID = pregledi.Single(x => x.Naziv == "Periodicni lekarski pregled").PregledID, Izvestaj = Izvestaj.Sposoban }
                //
                new Karton {PacijentID=1,PregledID=1000,Izvestaj=Izvestaj.Sposoban },
                new Karton {PacijentID=1,PregledID=1001,Izvestaj=Izvestaj.Sposoban },
                new Karton {PacijentID=1,PregledID=1002,Izvestaj=Izvestaj.Sposoban },
                new Karton {PacijentID=2,PregledID=1001,Izvestaj=Izvestaj.Nesposoban },
                new Karton {PacijentID=2,PregledID=1005,Izvestaj=Izvestaj.Nesposoban },
                new Karton {PacijentID=2,PregledID=1006,Izvestaj=Izvestaj.Nesposoban },
                new Karton {PacijentID=3,PregledID=1000,Izvestaj=Izvestaj.Sposoban },
                new Karton {PacijentID=4,PregledID=1000,Izvestaj=Izvestaj.Sposoban },
                new Karton {PacijentID=4,PregledID=1003,Izvestaj=Izvestaj.Nesposoban },
                new Karton {PacijentID=5,PregledID=1005,Izvestaj=Izvestaj.Sposoban },
                new Karton {PacijentID=6,PregledID=1002,Izvestaj=Izvestaj.Sposoban },
                new Karton {PacijentID=7,PregledID=1004,Izvestaj=Izvestaj.Nesposoban }
            };
            foreach (Karton k in kartoni)
            {
                var kartonUBazi = context.Kartoni.Where(
                    p => p.PacijentID == k.PacijentID && p.Pregled.PregledID == k.PregledID).SingleOrDefault();
                if (kartonUBazi == null)
                {
                    context.Kartoni.Add(k);
                }
            }
            context.SaveChanges();

            var lekaripregledi = new List<LekarPregled>
            {
                //new LekarPregled {LekarID = lekari.Single(p => p.Prezime == "Radosevic").ID, PregledID = pregledi.Single(x => x.Naziv == "Opsti lekarski pregled").PregledID, Participacija = Participacija.Ne },
                //new LekarPregled {LekarID = lekari.Single(p => p.Prezime == "Tomic").ID, PregledID = pregledi.Single(x => x.Naziv == "Opsti lekarski pregled").PregledID, Participacija = Participacija.Ne },
                //new LekarPregled {LekarID = lekari.Single(p => p.Prezime == "Sobot").ID, PregledID = pregledi.Single(x => x.Naziv == "Prethodni lekarski pregled").PregledID, Participacija = Participacija.Da },
                //new LekarPregled {LekarID = lekari.Single(p => p.Prezime == "Sobot").ID, PregledID = pregledi.Single(x => x.Naziv == "Periodicni lekarski pregled").PregledID, Participacija = Participacija.Da },
                //new LekarPregled {LekarID = lekari.Single(p => p.Prezime == "Milosevic").ID, PregledID = pregledi.Single(x => x.Naziv == "Prethodni lekarski pregled za mesta sa povisenim rizikom").PregledID, Participacija = Participacija.Da },
                //new LekarPregled {LekarID = lekari.Single(p => p.Prezime == "Milosevic").ID, PregledID = pregledi.Single(x => x.Naziv == "Periodicni lekarski pregled za mesta sa povisenim rizikom").PregledID, Participacija = Participacija.Da },
                //new LekarPregled {LekarID = lekari.Single(p => p.Prezime == "Mijatov").ID, PregledID = pregledi.Single(x => x.Naziv == "Kontrolni periodicni pregled").PregledID, Participacija = Participacija.Da },
                //new LekarPregled {LekarID = lekari.Single(p => p.Prezime == "Bajcetic").ID, PregledID = pregledi.Single(x => x.Naziv == "Ciljani pregled").PregledID, Participacija = Participacija.Da }
                //
               new LekarPregled {LekarID =1, PregledID=1000, Participacija=Participacija.Da },
                new LekarPregled {LekarID =1, PregledID=1001, Participacija=Participacija.Da },
                new LekarPregled {LekarID =2, PregledID=1001, Participacija=Participacija.Da },
                new LekarPregled {LekarID =3, PregledID=1002, Participacija=Participacija.Da },
                new LekarPregled {LekarID =3, PregledID=1003, Participacija=Participacija.Da },
                new LekarPregled {LekarID =4, PregledID=1004, Participacija=Participacija.Da },
                new LekarPregled {LekarID =4, PregledID=1005, Participacija=Participacija.Da },
                new LekarPregled {LekarID =5, PregledID=1006, Participacija=Participacija.Da },
                new LekarPregled {LekarID =5, PregledID=1006, Participacija=Participacija.Da }
            };
            foreach(LekarPregled lk in lekaripregledi)
            {
                var lkUBazi = context.LekariPregledi.Where(
                    p => p.LekarID == lk.LekarID && p.Pregled.PregledID == lk.PregledID).SingleOrDefault();
                if (lkUBazi == null)
                {
                    context.LekariPregledi.Add(lk);
                }
            }
            context.SaveChanges();
        }
    }
}
