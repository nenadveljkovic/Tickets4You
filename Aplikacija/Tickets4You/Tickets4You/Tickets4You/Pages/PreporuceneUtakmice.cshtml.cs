using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Cassandra;
using Tickets4You.Models;

namespace Tickets4You.Pages
{
    public class PreporuceneUtakmiceModel : PageModel
    {
        public string username;
        public Korisnik LogovaniKorisnik;
        public List<string> sportovi;
        public List<Utakmica> utakmice;
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

        public async Task<IActionResult> Utakmice()
        {
            sportovi = new List<string>();
            utakmice = new List<Utakmica>();

            var cluster = Cluster.Builder()
                .AddContactPoint("127.0.0.1")
                .Build();

            var session = cluster.Connect("tickets4you");

            string command = "SELECT * FROM utakmica WHERE broj_slobodnih_mesta_jug < 10 AND broj_slobodnih_mesta_istok < 10 AND broj_slobodnih_mesta_sever < 10 AND broj_slobodnih_mesta_zapad < 10 ALLOW FILTERING;";

            var results = session.Execute(command);

            foreach (var result in results)
            {
                char[] letters = result.GetValue<String>("sport").ToCharArray();
                letters[0] = char.ToUpper(letters[0]);
                LocalDate ld = result.GetValue<LocalDate>("datum");
                DateTime dt = new DateTime(ld.Year, ld.Month, ld.Day);
                Utakmica u = new Utakmica(new string(letters), result.GetValue<String>("domacin"),
                    result.GetValue<String>("gost"), dt,
                    result.GetValue<int>("broj_slobodnih_mesta_sever"), result.GetValue<int>("broj_slobodnih_mesta_jug"),
                    result.GetValue<int>("broj_slobodnih_mesta_istok"), result.GetValue<int>("broj_slobodnih_mesta_zapad"),
                    result.GetValue<int>("cena_sever"), result.GetValue<int>("cena_jug"),
                    result.GetValue<int>("cena_istok"), result.GetValue<int>("cena_zapad"),
                    result.GetValue<String>("vreme"));
                if (!sportovi.Contains(u.sport))
                {
                    sportovi.Add(u.sport);
                }
                utakmice.Add(u);
            }

            return new OkResult();
        }
    }
}
