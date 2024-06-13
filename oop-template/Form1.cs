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

                    if (jeDvaIgraca)
                    {
                        // Postavljanje brodova za prvog igrača
                        using (FormaZaPostavljanjeBrodova formaZaPostavljanjeBrodova = new FormaZaPostavljanjeBrodova(velicinaTable, brodovi))
                        {
                            if (formaZaPostavljanjeBrodova.ShowDialog() == DialogResult.OK)
                            {
                                var brodoviIgrac1 = formaZaPostavljanjeBrodova.PostavljeniBrodovi;

                                // Postavljanje brodova za drugog igrača
                                using (FormaZaPostavljanjeBrodova formaZaPostavljanjeBrodova2 = new FormaZaPostavljanjeBrodova(velicinaTable, brodovi))
                                {
                                    if (formaZaPostavljanjeBrodova2.ShowDialog() == DialogResult.OK)
                                    {
                                        var brodoviIgrac2 = formaZaPostavljanjeBrodova2.PostavljeniBrodovi;

                                        ZapocniIgru(brodoviIgrac1, brodoviIgrac2, velicinaTable, jeDvaIgraca);
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        // Postavljanje brodova za jednog igrača i kompjuter
                        using (FormaZaPostavljanjeBrodova formaZaPostavljanjeBrodova = new FormaZaPostavljanjeBrodova(velicinaTable, brodovi))
                        {
                            if (formaZaPostavljanjeBrodova.ShowDialog() == DialogResult.OK)
                            {
                                var brodoviIgrac = formaZaPostavljanjeBrodova.PostavljeniBrodovi;
                                var brodoviKompjuter = GenerisiNasumicneBrodove(velicinaTable, brodovi);

                                ZapocniIgru(brodoviIgrac, brodoviKompjuter, velicinaTable, jeDvaIgraca);
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
                case 8: // Ako je u pitanju tabla 4x4, ponudjeni su brodovi velicina : 5, 4, 3, 3
                    brodovi.Add(new Brod(5));
                    brodovi.Add(new Brod(4));
                    brodovi.Add(new Brod(3));
                    brodovi.Add(new Brod(3));
                    break;
                case 10: // Ako je u pitanju tabla 4x4, ponudjeni su brodovi velicina : 2, 2, 2, 2, 3, 3, 3, 4, 4, 6
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

        private List<Brod> GenerisiNasumicneBrodove(int velicinaTable, List<Brod> brodovi) // mora ovo da se proveri
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

                    if (MozetePostavitiBrodKompjuter(x, y, brod.Velicina, poljaTable))
                    {
                        PostaviBrodKompjuter(x, y, brod.Velicina, poljaTable);
                        postavljeniBrodovi.Add(new Brod(brod.Velicina) { Pozicije = DobijPozicije(x, y, brod.Velicina) });
                        brodPostavljen = true;
                    }
                }
            }

            return postavljeniBrodovi;
        }

        private bool MozetePostavitiBrodKompjuter(int x, int y, int velicina, bool[,] poljaTable)
        {
            if (x + velicina > poljaTable.GetLength(0)) return false;

            for (int i = 0; i < velicina; i++)
            {
                if (poljaTable[x + i, y])
                    return false;

                // Provera okolnih polja
                if (!PoljeJeSlobodnoKompjuter(x + i - 1, y - 1, poljaTable) || !PoljeJeSlobodnoKompjuter(x + i, y - 1, poljaTable) || !PoljeJeSlobodnoKompjuter(x + i + 1, y - 1, poljaTable) ||
                    !PoljeJeSlobodnoKompjuter(x + i - 1, y, poljaTable) || !PoljeJeSlobodnoKompjuter(x + i + 1, y, poljaTable) ||
                    !PoljeJeSlobodnoKompjuter(x + i - 1, y + 1, poljaTable) || !PoljeJeSlobodnoKompjuter(x + i, y + 1, poljaTable) || !PoljeJeSlobodnoKompjuter(x + i + 1, y + 1, poljaTable))
                    return false;
            }

            return true;
        }

        private bool PoljeJeSlobodnoKompjuter(int x, int y, bool[,] poljaTable)
        {
            if (x < 0 || y < 0 || x >= poljaTable.GetLength(0) || y >= poljaTable.GetLength(1))
                return true;
            return !poljaTable[x, y];
        }

        private void PostaviBrodKompjuter(int x, int y, int velicina, bool[,] poljaTable)
        {
            for (int i = 0; i < velicina; i++)
            {
                poljaTable[x + i, y] = true;
            }
        }

        private List<Point> DobijPozicije(int x, int y, int velicina)
        {
            List<Point> pozicije = new List<Point>();
            for (int i = 0; i < velicina; i++)
            {
                pozicije.Add(new Point(x + i, y));
            }
            return pozicije;
        }

        private void ZapocniIgru(List<Brod> brodoviIgrac1, List<Brod> brodoviIgrac2, int velicinaTable, bool jeDvaIgraca)
        {
            // Ovde treba da se uradi implementacijal logike za pocetak igre
        }
    }
}
