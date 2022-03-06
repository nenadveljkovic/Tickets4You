using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tickets4You.Models
{
    public class Karta
    {
        public string username { get; set; }
        public string serial_number { get; set; }
        public string sport { get; set; }
        public string domacin { get; set; }
        public string gost { get; set; }
        public DateTime datum { get; set; }
        public int cena { get; set; }
        public string racun { get; set; }
        public string tribina { get; set; }

        public Karta(string user, string serial, string sp, string dom, string go, DateTime da, int ce, string ra, string tri)
        {
            this.username = user;
            this.serial_number = serial;
            this.sport = sp;
            this.domacin = dom;
            this.gost = go;
            this.datum = da;
            this.cena = ce;
            this.racun = ra;
            this.tribina = tri;
        }
    }
}
