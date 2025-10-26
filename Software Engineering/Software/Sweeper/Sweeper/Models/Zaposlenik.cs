using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweeper.Models
{
    public class Zaposlenik
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public int IdUloga { get; set; }

        public override string ToString()
        {
            return Ime + " " + Prezime;
        }
    }
}
