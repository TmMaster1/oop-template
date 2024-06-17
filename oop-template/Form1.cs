using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace oop_template
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void naslovLabel_Click(object sender, EventArgs e)
        {

        }

        private void dvaIgracaButton_Click(object sender, EventArgs e)
        {
            PrikaziDijalogZaIzborTable(true);
        }

        private void protivKompjuteraButton_Click(object sender, EventArgs e)
        {
            PrikaziDijalogZaIzborTable(false);
        }
            
        private void PrikaziDijalogZaIzborTable(bool jeDvaIgraca)
        {
            using (FormaZaIzborTable formaZaIzborTable = new FormaZaIzborTable())
            {
                if (formaZaIzborTable.ShowDialog() == DialogResult.OK)
                {
                    int velicinaTable = formaZaIzborTable.IzabranaVelicinaTable;
                    List<Brod> brodovi = DobijBrodoveZaVelicinuTable(velicinaTable);

                    using (FormaZaUnosImena formaZaUnosImena = new FormaZaUnosImena(jeDvaIgraca))
                    {
                        if (formaZaUnosImena.ShowDialog() == DialogResult.OK)
                        {
                            string imeIgraca1 = formaZaUnosImena.ImeIgraca1;
                            string imeIgraca2 = jeDvaIgraca ? formaZaUnosImena.ImeIgraca2 : "Kompjuter";

                            if (jeDvaIgraca)
                            {
                                // Postavljanje brodova za prvog igrača
                                using (FormaZaPostavljanjeBrodova formaZaPostavljanjeBrodova = new FormaZaPostavljanjeBrodova(velicinaTable, brodovi,  imeIgraca1))
                                {
                                    if (formaZaPostavljanjeBrodova.ShowDialog() == DialogResult.OK)
                                    {
                                        var brodoviIgrac1 = formaZaPostavljanjeBrodova.PostavljeniBrodovi;

                                        // Postavljanje brodova za drugog igrača
                                        using (FormaZaPostavljanjeBrodova formaZaPostavljanjeBrodova2 = new FormaZaPostavljanjeBrodova(velicinaTable, brodovi, imeIgraca2))
                                        {
                                            if (formaZaPostavljanjeBrodova2.ShowDialog() == DialogResult.OK)
                                            {
                                                var brodoviIgrac2 = formaZaPostavljanjeBrodova2.PostavljeniBrodovi;

                                                ZapocniIgru(brodoviIgrac1, brodoviIgrac2, velicinaTable, jeDvaIgraca, imeIgraca1, imeIgraca2);
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                // Postavljanje brodova za jednog igrača i kompjuter
                                using (FormaZaPostavljanjeBrodova formaZaPostavljanjeBrodova = new FormaZaPostavljanjeBrodova(velicinaTable, brodovi, imeIgraca1))
                                {
                                    if (formaZaPostavljanjeBrodova.ShowDialog() == DialogResult.OK)
                                    {
                                        var brodoviIgrac = formaZaPostavljanjeBrodova.PostavljeniBrodovi;
                                        var brodoviKompjuter = GenerisiNasumicneBrodove(velicinaTable, brodovi);

                                        ZapocniIgru(brodoviIgrac, brodoviKompjuter, velicinaTable, jeDvaIgraca, imeIgraca1, imeIgraca2);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private List<Brod> DobijBrodoveZaVelicinuTable(int velicinaTable)
        {
            var brodovi = new List<Brod>();
            switch (velicinaTable)
            {
                case 4: // Ako je u pitanju tabla 4x4, ponudjeni su brodovi velicina : 1, 2, 2
                    brodovi.Add(new Brod(1));
                    brodovi.Add(new Brod(2));
                    brodovi.Add(new Brod(2));
                    break;
                case 8: // Ako je u pitanju tabla 8x8, ponudjeni su brodovi velicina : 5, 4, 3, 3
                    brodovi.Add(new Brod(5));
                    brodovi.Add(new Brod(4));
                    brodovi.Add(new Brod(3));
                    brodovi.Add(new Brod(3));
                    break;
                case 10: // Ako je u pitanju tabla 10x10, ponudjeni su brodovi velicina : 2, 2, 2, 2, 3, 3, 3, 4, 4, 6
                    brodovi.Add(new Brod(2));
                    brodovi.Add(new Brod(2));
                    brodovi.Add(new Brod(2));
                    brodovi.Add(new Brod(2));
                    brodovi.Add(new Brod(3));
                    brodovi.Add(new Brod(3));
                    brodovi.Add(new Brod(3));
                    brodovi.Add(new Brod(4));
                    brodovi.Add(new Brod(4));
                    brodovi.Add(new Brod(6));
                    break;
            }
            return brodovi;
        }

        private List<Brod> GenerisiNasumicneBrodove(int velicinaTable, List<Brod> brodovi)
        {
            var random = new Random();
            var postavljeniBrodovi = new List<Brod>();
            var poljaTable = new bool[velicinaTable, velicinaTable];

            foreach (var brod in brodovi)
            {
                bool brodPostavljen = false;

                while (!brodPostavljen)
                {
                    int x = random.Next(velicinaTable);
                    int y = random.Next(velicinaTable);
                    bool horizontalno = random.Next(2) == 0;

                    if (MozetePostavitiBrodKompjuter(x, y, brod.Velicina, poljaTable, horizontalno))
                    {
                        PostaviBrodKompjuter(x, y, brod.Velicina, poljaTable, horizontalno);
                        postavljeniBrodovi.Add(new Brod(brod.Velicina) { Pozicije = DobijPozicije(x, y, brod.Velicina, horizontalno) });
                        brodPostavljen = true;
                    }
                }
            }

            return postavljeniBrodovi;
        }

        private bool MozetePostavitiBrodKompjuter(int x, int y, int velicina, bool[,] poljaTable, bool horizontalno)
        {
            if (horizontalno)
            {
                if (x + velicina > poljaTable.GetLength(0)) return false;

                for (int i = 0; i < velicina; i++)
                {
                    if (poljaTable[x + i, y] || !PoljeJeSlobodnoKompjuter(x + i, y, poljaTable))
                        return false;
                }
            }
            else
            {
                if (y + velicina > poljaTable.GetLength(1)) return false;

                for (int i = 0; i < velicina; i++)
                {
                    if (poljaTable[x, y + i] || !PoljeJeSlobodnoKompjuter(x, y + i, poljaTable))
                        return false;
                }
            }

            return true;
        }

        private bool PoljeJeSlobodnoKompjuter(int x, int y, bool[,] poljaTable)
        {
            int[] dx = { -1, 0, 1 };
            int[] dy = { -1, 0, 1 };

            foreach (var i in dx)
            {
                foreach (var j in dy)
                {
                    int nx = x + i;
                    int ny = y + j;

                    if (nx >= 0 && ny >= 0 && nx < poljaTable.GetLength(0) && ny < poljaTable.GetLength(1))
                    {
                        if (poljaTable[nx, ny])
                            return false;
                    }
                }
            }

            return true;
        }

        private void PostaviBrodKompjuter(int x, int y, int velicina, bool[,] poljaTable, bool horizontalno)
        {
            if (horizontalno)
            {
                for (int i = 0; i < velicina; i++)
                {
                    poljaTable[x + i, y] = true;
                }
            }
            else
            {
                for (int i = 0; i < velicina; i++)
                {
                    poljaTable[x, y + i] = true;
                }
            }
        }

        private List<Point> DobijPozicije(int x, int y, int velicina, bool horizontalno)
        {
            List<Point> pozicije = new List<Point>();
            if (horizontalno)
            {
                for (int i = 0; i < velicina; i++)
                {
                    pozicije.Add(new Point(x + i, y));
                }
            }
            else
            {
                for (int i = 0; i < velicina; i++)
                {
                    pozicije.Add(new Point(x, y + i));
                }
            }
            return pozicije;
        }

        private void ZapocniIgru(List<Brod> brodoviIgrac1, List<Brod> brodoviIgrac2, int velicinaTable, bool jeDvaIgraca, string imeIgraca1, string imeIgraca2)
        {
            // Ovde treba da se uradi implementacija logike za pocetak igre, uz koriscenja imena igraca
        }
    }
}

// bugfix uradjen za nasucmicno postavljanje brodova od strane kompjutera, proveriti da li radi nekim logovanjem brodova koje kompjuter napravi
// dodato unosenje imena kao nova forma