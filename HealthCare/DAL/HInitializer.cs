using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HealthCare.Models;

namespace HealthCare.DAL
{
    public class HInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<HContext>
    {
        protected override void Seed(HContext context)
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
                new Pacijent{Ime="Marija",Prezime="Pap",DatumRegistracije=DateTime.Parse("2017-09-20"), Firma="Svilar doo"}
            };
            pacijenti.ForEach(p => context.Pacijenti.Add(p));
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
            lekari.ForEach(p => context.Lekari.Add(p));
            context.SaveChanges();

            var pregledi = new List<Pregled>
            {
                new Pregled {PregledID=1000,Naziv="Opsti lekarski pregled",Opis="Izdavanje lekarskog izvestaja o zdravstvenoj i radnoj sposobnosti.",},
                new Pregled {PregledID=1001,Naziv="Prethodni lekarski pregled",Opis="Pregled obuhvata pregled koze i sluzokoze celog tela i koznih dodataka: noktiju i kose.",},
                new Pregled {PregledID=1002,Naziv="Periodicni lekarski pregled",Opis="Pregled ukljucuje EKG, ultrazvuk srca, test opterecenja",},
                new Pregled {PregledID=1003,Naziv="Prethodni lekarski pregled za mesta sa povisenim rizikom",Opis="Pregled ukljucuje inspekciju, tj. posmatranje drzanja pacijenta, i dela tela u kome pacijent oseca tegobe",},
                new Pregled {PregledID=1004,Naziv="Periodicni lekarski pregled za mesta sa povisenim rizikom",Opis="Pregled obuhvata preglede uva, nosa i grla",},
                new Pregled {PregledID=1005,Naziv="Kontrolni periodicni pregledi",Opis="Izdavanje izvestaja o daljem lecenju po potrebi i izdavanje izveštaja o radnoj sposobnosti",},
                new Pregled {PregledID=1006,Naziv="Ciljani pregledi",Opis="Ciljano upucivanje na dalji tok lecenja, po odluci lekara specijaliste medicine rada i izdavanjem izvestaja o radnoj sposobnosti zaposlenog na tom radnom mestu",}
            };
            pregledi.ForEach(p => context.Pregledi.Add(p));
            context.SaveChanges();

            var kartoni = new List<Karton>
            {
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
            kartoni.ForEach(p => context.Kartoni.Add(p));
            context.SaveChanges();

            var lekaripregledi = new List<LekarPregled>
            {
                new LekarPregled {LekarID =1, PregledID=1000, Participacija=Participacija.Da },
                new LekarPregled {LekarID =1, PregledID=1001, Participacija=Participacija.Da },
                new LekarPregled {LekarID =2, PregledID=1001, Participacija=Participacija.Da },
                new LekarPregled {LekarID =3, PregledID=1002, Participacija=Participacija.Da },
                new LekarPregled {LekarID =4, PregledID=1003, Participacija=Participacija.Da },
                new LekarPregled {LekarID =5, PregledID=1004, Participacija=Participacija.Da },
                new LekarPregled {LekarID =5, PregledID=1005, Participacija=Participacija.Da },
                new LekarPregled {LekarID =6, PregledID=1005, Participacija=Participacija.Da },
                new LekarPregled {LekarID =6, PregledID=1006, Participacija=Participacija.Da }
            };
            lekaripregledi.ForEach(p => context.LekariPregledi.Add(p));
            context.SaveChanges();
        }
    }
}