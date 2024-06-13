using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_template
{
    public class Brod
    {
        public int Velicina { get; private set; }
        public List<Point> Pozicije { get; set; }
        public bool HorizontalnoPostavljen { get; set; }

        public Brod(int velicina)
        {
            Velicina = velicina;
            Pozicije = new List<Point>();
        }
    }

}
