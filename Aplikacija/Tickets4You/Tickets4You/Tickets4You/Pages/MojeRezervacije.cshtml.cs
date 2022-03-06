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
    public class MojeRezervacijeModel : PageModel
    {
        public string username;
        public Korisnik LogovaniKorisnik;
        public List<Karta> karte;
        public Utakmica utakmica;
        public Karta karta;
        public void OnGet(string username)
        {
            this.username = username;
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

        public async Task<IActionResult> Rezervacije()
        {
            karte = new List<Karta>();
            var cluster = Cluster.Builder()
                .AddContactPoint("127.0.0.1")
                .Build();

            var session = cluster.Connect("tickets4you");

            string command = "SELECT * FROM karta WHERE username = '" + username + "';";

            var results = session.Execute(command);
            foreach (var result in results)
            {
                LocalDate ld = result.GetValue<LocalDate>("datum");
                DateTime dt = new DateTime(ld.Year, ld.Month, ld.Day);
                karte.Add(new Karta(result.GetValue<String>("username"), result.GetValue<String>("serial_number"),
                    result.GetValue<String>("sport"), result.GetValue<String>("domacin"),
                    result.GetValue<String>("gost"), dt,
                    result.GetValue<int>("cena"), result.GetValue<String>("racun"),
                    result.GetValue<String>("tribina")));
            }

            return new OkResult();
        }

        public async Task<IActionResult> OnGetOtkaziAsync(string serial_number, string username, string sport, string domacin, string gost, DateTime datum)
        {
            var cluster = Cluster.Builder()
                .AddContactPoint("127.0.0.1")
                .Build();

            var session = cluster.Connect("tickets4you");

            string command3 = "SELECT * FROM karta WHERE serial_number = '" + serial_number + "' AND username = '" + username + "';";

            var results = session.Execute(command3);
            string tribina = "";
            
            foreach(var result in results)
            {
                LocalDate ld = result.GetValue<LocalDate>("datum");
                DateTime dt = new DateTime(ld.Year, ld.Month, ld.Day);
                karta = new Karta(result.GetValue<String>("username"), result.GetValue<String>("serial_number"), result.GetValue<String>("sport"),
                    result.GetValue<String>("domacin"), result.GetValue<String>("gost"), dt,
                    result.GetValue<Int32>("cena"), result.GetValue<String>("racun"), result.GetValue<String>("tribina"));
                tribina = result.GetValue<String>("tribina");
            }

            string command4 = "SELECT * FROM utakmica WHERE sport = '" + karta.sport + "' AND domacin = '" + karta.domacin + "' AND gost = '" + karta.gost + "' AND datum = '" + new LocalDate(karta.datum.Year, karta.datum.Month, karta.datum.Day) + "';";

            results = session.Execute(command4);

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

            string command2 = "";
            LocalDate locd = new LocalDate(utakmica.datum.Year, utakmica.datum.Month, utakmica.datum.Day);

            switch (tribina)
            {
                case "sever":
                    command2 = "UPDATE utakmica SET broj_slobodnih_mesta_sever = " + (utakmica.bsm_sever + 1) + "" +
                        " WHERE sport = '" + utakmica.sport + "' AND domacin = '" + utakmica.domacin
                        + "' AND gost = '" + utakmica.gost + "' AND datum = '" + locd + "';";
                    break;
                case "jug":
                    command2 = "UPDATE utakmica SET broj_slobodnih_mesta_jug = " + (utakmica.bsm_jug + 1) + "" +
                        " WHERE sport = '" + utakmica.sport + "' AND domacin = '" + utakmica.domacin
                        + "' AND gost = '" + utakmica.gost + "' AND datum = '" + locd + "';";
                    break;
                case "istok":
                    command2 = "UPDATE utakmica SET broj_slobodnih_mesta_istok = " + (utakmica.bsm_istok + 1) + "" +
                        " WHERE sport = '" + utakmica.sport + "' AND domacin = '" + utakmica.domacin
                        + "' AND gost = '" + utakmica.gost + "' AND datum = '" + locd + "';";
                    break;
                case "zapad":
                    command2 = "UPDATE utakmica SET broj_slobodnih_mesta_zapad = " + (utakmica.bsm_zapad + 1) + "" +
                        " WHERE sport = '" + utakmica.sport + "' AND domacin = '" + utakmica.domacin
                        + "' AND gost = '" + utakmica.gost + "' AND datum = '" + locd + "';";
                    break;
                default:
                    break;
            }

            session.Execute(command2);

            LocalDate dld = new LocalDate(datum.Year, datum.Month, datum.Day);
            string command = "DELETE FROM karta WHERE serial_number = '" + serial_number + "' AND username = '" + username + "' AND sport = '" + sport + "' AND domacin = '" + domacin + "' AND gost = '" + gost + "' AND datum = '" + dld + "' IF EXISTS; ";

            session.Execute(command);
            return base.RedirectToPage(new { username = username });
        }
    }
}