using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_template
{
    public class Igrac
    {
        public string Ime { get; set; }
        public List<Brod> Brodovi { get; set; }

        public Igrac(string ime, List<Brod> brodovi)
        {
            Ime = ime;
            Brodovi = brodovi;
        }   
    }
}
