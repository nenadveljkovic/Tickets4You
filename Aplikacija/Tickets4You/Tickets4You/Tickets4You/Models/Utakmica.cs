using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cassandra;

namespace Tickets4You.Models
{
    public class Utakmica
    {
        public string sport { get; set; }
        public string domacin { get; set; }
        public string gost { get; set; }
        public DateTime datum { get; set; }
        public int bsm_sever { get; set; }
        public int bsm_jug { get; set; }
        public int bsm_istok { get; set; }
        public int bsm_zapad { get; set; }
        public int cena_sever { get; set; }
        public int cena_jug { get; set; }
        public int cena_istok { get; set; }
        public int cena_zapad { get; set; }
        public string vreme { get; set; }

        public Utakmica(string sp, string dom, string go, DateTime da, int bs, int bj, int bi, int bz, int cs, int cj, int ci, int cz, string vre)
        {
            this.sport = sp;
            this.domacin = dom;
            this.gost = go;
            this.datum = da;
            this.bsm_sever = bs;
            this.bsm_jug = bj;
            this.bsm_istok = bi;
            this.bsm_zapad = bz;
            this.cena_sever = cs;
            this.cena_jug = cj;
            this.cena_istok = ci;
            this.cena_zapad = cz;
            this.vreme = vre;
        }
    }
}
