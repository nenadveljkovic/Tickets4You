using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tickets4You.Models
{
    public class Korisnik
    {
        public string username { get; set; }
        public string password { get; set; }
        public string gmail { get; set; }

        public Korisnik(string user, string pass, string mail)
        {
            this.username = user;
            this.password = pass;
            this.gmail = mail;
        }
    }
}
