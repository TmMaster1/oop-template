using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static oop_template.FormaZaIgru;

namespace oop_template
{
    internal class Engine
    {
        public Igrac Igrac1 { get; private set; }
        public Igrac Igrac2 { get; private set; }
        public int VelicinaTable { get; private set; }
        public FormaZaIgru Table { get; set; }
        public bool Igrac1NaPotezu { get; set; }

        public Engine(Igrac igrac1, Igrac igrac2, FormaZaIgru table, int velicinaTable)
        {
            Igrac1 = igrac1;
            Igrac2 = igrac2;
            Table = table;
            VelicinaTable = velicinaTable;
            Igrac1NaPotezu = true;
        }
        public void Flip(bool vrednost)
        {
            vrednost = !vrednost;
        }
        public void NapraviPotez(int x, int y)
        {
            Igrac trenutniIgrac = Igrac1NaPotezu ? Igrac1 : Igrac2;
            Igrac protivnik = Igrac1NaPotezu ? Igrac2 : Igrac1;
            Flip(Igrac1NaPotezu);

            foreach (Brod brod in protivnik.Brodovi)
            {
                foreach (Point pozicija in brod.Pozicije)
                {
                    if (pozicija.X == x && pozicija.Y == y)
                    {

                    }
                }
            }
        }

        public event Engine_NaPogodakDelegate NaPogodak;
        public event Engine_NaPromasajDelegate NaPromasaj;
        public event Engine_NaPromenuPotezaDelegate NaPromenuPoteza;
    }
}
