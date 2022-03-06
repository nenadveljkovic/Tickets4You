using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cassandra;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Tickets4You.Models;

namespace Tickets4You.Pages
{
    public class IzmenaRezervacijeModel : PageModel
    {
        public string username;
        public string serial_number;
        public string sport;
        public string home;
        public string away;
        public DateTime date;
        public Korisnik LogovaniKorisnik;
        public Utakmica utakmica;
        public Karta karta;
        public bool[] tribina = new bool[4];

        [BindProperty]
        public string tribina_cena { get; set; }

        [BindProperty]
        public string racun { get; set; }
        public void OnGet(string username,string serial_number,string sport,string domacin,string gost,DateTime datum)
        {
            this.username = username;
            this.serial_number = serial_number;
            this.sport = sport;
            this.home = domacin;
            this.away = gost;
            this.date = datum;
        }

        public async Task<IActionResult> Korisnik()
        {
            var cluster = Cluster.Builder()
                .AddContactPoint("127.0.0.1")
                .Build();

            var session = cluster.Connect("tickets4you");

            string command = "SELECT * FROM korisnik WHERE username = '" + username + "';";

            var results = session.Execute(command);

            foreach (var result in results)
            {
                LogovaniKorisnik = new Korisnik(result.GetValue<String>("username"), result.GetValue<String>("password"), result.GetValue<String>("gmail"));
            }

            return new OkResult();
        }

        public async Task<IActionResult> Karta()
        {
            var cluster = Cluster.Builder()
                .AddContactPoint("127.0.0.1")
                .Build();

            var session = cluster.Connect("tickets4you");

            string command = "SELECT * FROM karta WHERE username='" + username +"' AND serial_number = '" + serial_number + "';";

            var results = session.Execute(command);

            foreach (var result in results)
            {
                LocalDate ld = result.GetValue<LocalDate>("datum");
                DateTime dt = new DateTime(ld.Year, ld.Month, ld.Day);
                karta = new Karta(result.GetValue<String>("username"), result.GetValue<String>("serial_number")
                    , result.GetValue<String>("sport"), result.GetValue<String>("domacin")
                    , result.GetValue<String>("gost"),dt, result.GetValue<int>("cena")
                    , result.GetValue<String>("racun"), result.GetValue<String>("tribina"));
                this.racun = result.GetValue<String>("racun");
                for (int i = 0; i < 4; i++)
                    this.tribina[i] = false;
                switch(result.GetValue<String>("tribina"))
                {
                    case "sever":
                        tribina[0] = true;

                        break;
                    case "jug":
                        tribina[1] = true;
                        break;
                    case "istok":
                        tribina[2] = true;
                        break;
                    case "zapad":
                        tribina[3] = true;
                        break;
                    default:
                        break;
                }
            }

            return new OkResult();
        }
        public async Task<IActionResult> Utakmica()
        {
            var cluster = Cluster.Builder()
                .AddContactPoint("127.0.0.1")
                .Build();

            var session = cluster.Connect("tickets4you");

            string command = "SELECT * FROM utakmica WHERE sport = '" + sport + "' AND domacin = '" + home + "' AND gost = '" + away + "' AND datum = '" + new LocalDate(date.Year, date.Month, date.Day) + "';";

            var results = session.Execute(command);

            foreach (var result in results)
            {
                LocalDate ld = result.GetValue<LocalDate>("datum");
                DateTime dt = new DateTime(ld.Year, ld.Month, ld.Day);
                utakmica = new Utakmica(result.GetValue<String>("sport"), result.GetValue<String>("domacin"),
                   result.GetValue<String>("gost"), dt,
                   result.GetValue<int>("broj_slobodnih_mesta_sever"), result.GetValue<int>("broj_slobodnih_mesta_jug"),
                   result.GetValue<int>("broj_slobodnih_mesta_istok"), result.GetValue<int>("broj_slobodnih_mesta_zapad"),
                   result.GetValue<int>("cena_sever"), result.GetValue<int>("cena_jug"),
                   result.GetValue<int>("cena_istok"), result.GetValue<int>("cena_zapad"),
                   result.GetValue<String>("vreme"));
            }
            
            return new OkResult();
        }
        

        public async Task<IActionResult> OnPostAsync(string sport, string home, string away, DateTime date, string username,string serial_number)
        {
            var cluster = Cluster.Builder()
                .AddContactPoint("127.0.0.1")
                .Build();

            var session = cluster.Connect("tickets4you");

            string command3 = "SELECT * FROM korisnik WHERE username = '" + username + "';";

            var results = session.Execute(command3);

            foreach (var result in results)
            {
                LogovaniKorisnik = new Korisnik(result.GetValue<String>("username"), result.GetValue<String>("password"), result.GetValue<String>("gmail"));
            }
            string command4 = "SELECT * FROM karta WHERE username='" + username + "' AND serial_number = '" + serial_number + "';";

             results = session.Execute(command4);

            foreach (var result in results)
            {
                LocalDate ld = result.GetValue<LocalDate>("datum");
                DateTime dt = new DateTime(ld.Year, ld.Month, ld.Day);
                karta = new Karta(result.GetValue<String>("username"), result.GetValue<String>("serial_number")
                    , result.GetValue<String>("sport"), result.GetValue<String>("domacin")
                    , result.GetValue<String>("gost"), dt, result.GetValue<int>("cena")
                    , result.GetValue<String>("racun"), result.GetValue<String>("tribina"));
                this.racun = result.GetValue<String>("racun");
                for (int i = 0; i < 4; i++)
                    this.tribina[i] = false;
                switch (result.GetValue<String>("tribina"))
                {
                    case "sever":
                        tribina[0] = true;

                        break;
                    case "jug":
                        tribina[1] = true;
                        break;
                    case "istok":
                        tribina[2] = true;
                        break;
                    case "zapad":
                        tribina[3] = true;
                        break;
                    default:
                        break;
                }
            }
            string command5 = "SELECT * FROM utakmica WHERE sport = '" + sport + "' AND domacin = '" + home + "' AND gost = '" + away + "' AND datum = '" + new LocalDate(date.Year, date.Month, date.Day) + "';";

            results = session.Execute(command5);

            foreach (var result in results)
            {
                LocalDate ld = result.GetValue<LocalDate>("datum");
                DateTime dt = new DateTime(ld.Year, ld.Month, ld.Day);
                utakmica = new Utakmica(result.GetValue<String>("sport"), result.GetValue<String>("domacin"),
                   result.GetValue<String>("gost"), dt,
                   result.GetValue<int>("broj_slobodnih_mesta_sever"), result.GetValue<int>("broj_slobodnih_mesta_jug"),
                   result.GetValue<int>("broj_slobodnih_mesta_istok"), result.GetValue<int>("broj_slobodnih_mesta_zapad"),
                   result.GetValue<int>("cena_sever"), result.GetValue<int>("cena_jug"),
                   result.GetValue<int>("cena_istok"), result.GetValue<int>("cena_zapad"),
                   result.GetValue<String>("vreme"));
            }

            string command6 = "";
            LocalDate locd = new LocalDate(utakmica.datum.Year, utakmica.datum.Month, utakmica.datum.Day);
            switch (karta.tribina)
            {
                case "sever":
                    command6 = "UPDATE utakmica SET broj_slobodnih_mesta_sever = " + (utakmica.bsm_sever + 1) + "" +
                        " WHERE sport = '" + utakmica.sport + "' AND domacin = '" + utakmica.domacin
                        + "' AND gost = '" + utakmica.gost + "' AND datum = '" + locd + "';";
                    break;
                case "jug":
                    command6 = "UPDATE utakmica SET broj_slobodnih_mesta_jug = " + (utakmica.bsm_jug + 1) + "" +
                        " WHERE sport = '" + utakmica.sport + "' AND domacin = '" + utakmica.domacin
                        + "' AND gost = '" + utakmica.gost + "' AND datum = '" + locd + "';";
                    break;
                case "istok":
                    command6 = "UPDATE utakmica SET broj_slobodnih_mesta_istok = " + (utakmica.bsm_istok + 1) + "" +
                        " WHERE sport = '" + utakmica.sport + "' AND domacin = '" + utakmica.domacin
                        + "' AND gost = '" + utakmica.gost + "' AND datum = '" + locd + "';";
                    break;
                case "zapad":
                    command6 = "UPDATE utakmica SET broj_slobodnih_mesta_zapad = " + (utakmica.bsm_zapad + 1) + "" +
                        " WHERE sport = '" + utakmica.sport + "' AND domacin = '" + utakmica.domacin
                        + "' AND gost = '" + utakmica.gost + "' AND datum = '" + locd + "';";
                    break;
                default:
                    break;
            }
            session.Execute(command6);

            object[] values = tribina_cena.Split('-');

            
            LocalDate lcd2 = new LocalDate(karta.datum.Year, karta.datum.Month, karta.datum.Day);
            string command = "UPDATE karta SET cena =" + Convert.ToInt32(values[1]) + ", tribina = '" + values[0].ToString() + 
                "' WHERE username='" + karta.username + "' AND serial_number='" + karta.serial_number + 
                "' AND sport='" + karta.sport + "' AND domacin='" + karta.domacin +
                "' AND gost='" + karta.gost + "' AND datum='" + lcd2  + "';";

            session.Execute(command);

            string command2 = "";

            switch (values[0].ToString())
            {
                case "sever":
                    command2 = "UPDATE utakmica SET broj_slobodnih_mesta_sever = " + (utakmica.bsm_sever - 1) + "" +
                        " WHERE sport = '" + utakmica.sport + "' AND domacin = '" + utakmica.domacin
                        + "' AND gost = '" + utakmica.gost + "' AND datum = '" + locd + "';";
                    break;
                case "jug":
                    command2 = "UPDATE utakmica SET broj_slobodnih_mesta_jug = " + (utakmica.bsm_jug - 1) + "" +
                        " WHERE sport = '" + utakmica.sport + "' AND domacin = '" + utakmica.domacin
                        + "' AND gost = '" + utakmica.gost + "' AND datum = '" + locd + "';";
                    break;
                case "istok":
                    command2 = "UPDATE utakmica SET broj_slobodnih_mesta_istok = " + (utakmica.bsm_istok - 1) + "" +
                        " WHERE sport = '" + utakmica.sport + "' AND domacin = '" + utakmica.domacin
                        + "' AND gost = '" + utakmica.gost + "' AND datum = '" + locd + "';";
                    break;
                case "zapad":
                    command2 = "UPDATE utakmica SET broj_slobodnih_mesta_zapad = " + (utakmica.bsm_zapad - 1) + "" +
                        " WHERE sport = '" + utakmica.sport + "' AND domacin = '" + utakmica.domacin
                        + "' AND gost = '" + utakmica.gost + "' AND datum = '" + locd + "';";
                    break;
                default:
                    break;
            }

            session.Execute(command2);

            return RedirectToPage("/MojeRezervacije", new { username = LogovaniKorisnik.username });
        }
    }
}