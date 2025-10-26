
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweeper.Models
{
    public class Podkategorija
    {
        public int IdPodkategorija { get; set; }
        public string NazivPodkategorije { get; set; }
        public int IdKategorije { get; set; }
        public override string ToString()
        {
            return NazivPodkategorije;
        }
    }
}
