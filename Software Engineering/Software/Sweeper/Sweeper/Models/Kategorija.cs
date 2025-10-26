
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweeper.Models
{
    public class Kategorija
    {
        public int IdKategorija { get; set; }
        public string NazivKategorije { get; set; }

        public override string ToString()
        {
            return NazivKategorije;
        }
    }
}
