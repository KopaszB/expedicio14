using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace expedicio
{
    internal class Adas
    {
        public Adas(int nap, int radioAmator, string uzenet)
        {
            Nap = nap;
            RadioAmator = radioAmator;
            Uzenet = uzenet;
        }

        public int Nap { get; set; }
        public int RadioAmator { get; set; }
        public string Uzenet { get; set; }

    }
}
