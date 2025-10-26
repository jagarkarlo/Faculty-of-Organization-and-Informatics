using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweeper.Models
{
    public class Zahtjev
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public DateTime VrijemeKreiranja { get; set; }
        public string PotrebnoVrijemeIzvodenja { get; set; }
        public DateTime TerminObavljanja { get; set; }
        public Zaposlenik IdZaposlenika { get; set; }
        public Kategorija IdKategorije { get; set; }
        public Podkategorija IdPodkategorije { get; set; }
    }
}
