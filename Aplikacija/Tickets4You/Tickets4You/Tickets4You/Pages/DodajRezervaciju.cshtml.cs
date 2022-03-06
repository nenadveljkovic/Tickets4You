using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Tickets4You.Models;
using Cassandra;

namespace Tickets4You.Pages
{
    public class DodajRezervacijuModel : PageModel
    {
        public string username;
        public string sport;
        public string home;
        public string away;
        public DateTime date;
        public Korisnik LogovaniKorisnik;
        public Utakmica utakmica;

        [BindProperty]
        public string tribina_cena { get; set; }

        [BindProperty]
        public string racun { get; set; }
        public void OnGet(string sport, string home, string away, DateTime date, string username)
        {
            char[] letters = sport.ToCharArray();
            letters[0] = char.ToLower(letters[0]);
            this.sport = new string(letters);
            this.home = home;
            this.away = away;
            this.date = date;
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

        public async Task<IActionResult> Utakmica()
        {
            var cluster = Cluster.Builder()
                .AddContactPoint("127.0.0.1")
                .Build();

            var session = cluster.Connect("tickets4you");

            string command = "SELECT * FROM utakmica WHERE sport = '" + sport + "' AND domacin = '" + home + "' AND gost = '" + away + "' AND datum = '" + new LocalDate(date.Year, date.Month, date.Day) + "';";

            var results = session.Execute(command);

            foreach(var result in results)
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

        public async Task<IActionResult> OnPostAsync(string sport, string home, string away, DateTime date, string username)
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

            string command4 = "SELECT * FROM utakmica WHERE sport = '" + sport + "' AND domacin = '" + home + "' AND gost = '" + away + "' AND datum = '" + new LocalDate(date.Year, date.Month, date.Day) + "';";

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

            string serial_number = CalculateSerial();
            object[] values = tribina_cena.Split('-');

            LocalDate locd = new LocalDate(utakmica.datum.Year, utakmica.datum.Month, utakmica.datum.Day);

            string command = "INSERT INTO karta(username, serial_number, sport, domacin, gost, datum, cena, racun, tribina) " +
                "VALUES ('" + LogovaniKorisnik.username + "', '" + serial_number + "', '" + utakmica.sport + "', '"
                + utakmica.domacin + "', '" + utakmica.gost + "', '" + locd + "', " + Convert.ToInt32(values[1]) + ", '"
                + racun + "', '" + values[0].ToString() + "');";

            session.Execute(command);

            string command2 = "";

            switch(values[0].ToString())
            {
                case "sever":
                    command2 = "UPDATE utakmica SET broj_slobodnih_mesta_sever = " + (utakmica.bsm_sever-1) + "" +
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

            return RedirectToPage("/PocetnaZaKorisnika", new { username = LogovaniKorisnik.username });
        }

        public string CalculateSerial()
        {
            string s = "";
            char[] user_let = LogovaniKorisnik.username.ToCharArray();
            s += (DateTime.Today.Hour * DateTime.Today.Minute + DateTime.Today.Second);
            s += DateTime.Today.ToString("yyyy_MM_dd");
            for (int i = 0; i < user_let.Length / 2; i++)
                s += (user_let[i] + "" + user_let[user_let.Length - 1 - i]);
            return s;
        }
    }
}
