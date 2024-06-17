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
        public HashSet<Point> pozicije1 { get; private set; }
        public HashSet<Point> pozicije2 { get; private set; }

        public Engine(Igrac igrac1, Igrac igrac2, FormaZaIgru table, int velicinaTable)
        {
            Igrac1 = igrac1;
            Igrac2 = igrac2;
            Table = table;
            VelicinaTable = velicinaTable;
            Igrac1NaPotezu = true;
            pozicije1 = new HashSet<Point>();
            pozicije2 = new HashSet<Point>();
            foreach (Brod brod in Igrac1.Brodovi)
            {
                foreach (Point pozicija in brod.Pozicije)
                {
                    pozicije1.Add(pozicija);
                }
            }

            foreach (Brod brod in Igrac2.Brodovi)
            {
                foreach (Point pozicija in brod.Pozicije)
                {
                    pozicije2.Add(pozicija);
                }
            }
        }
        public void Flip(bool vrednost)
        {
            vrednost = !vrednost;
        }
        public void NapraviPotez(int x, int y)
        {
            //igrac koji je na redu pravi svoj potez i u zavisnosti od ishoda se radi logika
            Point meta = new Point(x, y);
            if (Igrac1NaPotezu)
            {
                if (pozicije2.Contains(meta))
                {
                    pozicije2.Remove(meta);
                    if (susedniBrod(meta, pozicije2)) 
                    {
                        NaPogodak(meta);
                        return;
                    }
                    NaPotapanje(meta);
                }
                NaPromasaj(meta);
            }
            else 
            {
                if (pozicije1.Contains(meta))
                {
                    pozicije1.Remove(meta);
                    if (susedniBrod(meta, pozicije1))
                    {
                        NaPogodak(meta);
                        return;
                    }
                    NaPotapanje(meta);
                }
                NaPromasaj(meta);
            }
            Flip(Igrac1NaPotezu);
        }

        private bool susedniBrod(Point trenutni, HashSet<Point> pozicije)
        {
            int[] redSmerovi = { -1, 1, 0, 0 };
            int[] kolSmerovi = { 0, 0, -1, 1 };

            for (int i = 0; i < 4; i++)
            {
                int noviRed = trenutni.X + redSmerovi[i];
                int novaKol = trenutni.Y + kolSmerovi[i];
                Point susedni = new Point(noviRed, novaKol);

                if (pozicije.Contains(susedni))
                {
                    return true;
                }
            }
            return false;
        }
        public event Engine_NaPotezDelegate NaPogodak;
        public event Engine_NaPotezDelegate NaPotapanje;
        public event Engine_NaPotezDelegate NaPromasaj;
        public event Engine_NaPromenuPotezaDelegate NaPromenuPoteza;
    }
}
