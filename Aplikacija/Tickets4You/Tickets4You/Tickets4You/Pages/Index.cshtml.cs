using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tickets4You.Models;
using Cassandra;

namespace Tickets4You.Pages
{
    public class IndexModel : PageModel
    {

        public Korisnik korisnik;

        [BindProperty]
        public string KorisnickoIme { get; set; }

        [BindProperty]
        public string Sifra { get; set; }

        public bool Greska = false;

        public void OnGet()
        {
            
        }
        public async Task<IActionResult> OnPostAsync()
        {
            var cluster = Cluster.Builder()
                .AddContactPoint("127.0.0.1")
                .Build();

            var session = cluster.Connect("tickets4you");

            string command = "SELECT * FROM korisnik WHERE username = '" + KorisnickoIme +"';";

            var results = session.Execute(command);

            if (results == null)
            {
                Greska = true;
                return Page();
            }
            else
            {

                foreach (var result in results)
                {
                    korisnik = new Korisnik(result.GetValue<String>("username"), result.GetValue<String>("password"), result.GetValue<String>("gmail"));
                }

                if (korisnik.password == Sifra)
                    return RedirectToPage("/PocetnaZaKorisnika", new { username = korisnik.username });
                else
                {
                    Greska = true;
                    return Page();
                }
            }
        }
    }
}
