using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace oop_template
{
    public partial class FormaZaIgru : Form
    {
        private int velicinaTable;
        private Engine engine;
        private Button[,] poljaIgrac1;
        private Button[,] poljaIgrac2;

        public FormaZaIgru(Igrac igrac1, Igrac igrac2, int velicinaTable, bool jeDvaIgraca)
        {
            InitializeComponent();
            this.velicinaTable = velicinaTable;
            engine = new Engine(igrac1, igrac2, this, velicinaTable);
            Engine_NaPogodakDelegate pogodakHandler = Engine_NaPogodak;
            Engine_NaPromasajDelegate promasajHandler = Engine_NaPromasaj;
            Engine_NaPromenuPotezaDelegate promenaHandler = Engine_NaPromenuPoteza;
            engine.NaPogodak += pogodakHandler;
            engine.NaPromasaj += promasajHandler;
            engine.NaPromenuPoteza += promenaHandler;
            CustomInitializeComponent();
        }

        private void FormaZaIgru_Load(object sender, EventArgs e) { }
        private void CustomInitializeComponent()
        {
            this.SuspendLayout();

            poljaIgrac1 = new Button[velicinaTable, velicinaTable]; // kreiranje table za igraca1
            for (int i = 0; i < velicinaTable; i++)
            {
                for (int j = 0; j < velicinaTable; j++)
                {
                    poljaIgrac1[i, j] = new Button();
                    poljaIgrac1[i, j].Size = new Size(30, 30);
                    poljaIgrac1[i, j].Location = new Point(30 * i, 30 * j);
                    poljaIgrac1[i, j].Click += new EventHandler(PoljaIgrac1_Click);
                    this.Controls.Add(poljaIgrac1[i, j]);
                }
            }

            poljaIgrac2 = new Button[velicinaTable, velicinaTable]; // kreiranje table za igraca2 
            for (int i = 0; i < velicinaTable; i++)
            {
                for (int j = 0; j < velicinaTable; j++)
                {
                    poljaIgrac2[i, j] = new Button();
                    poljaIgrac2[i, j].Size = new Size(30, 30);
                    poljaIgrac2[i, j].Location = new Point(30 * i + 40 * velicinaTable, 30 * j);
                    poljaIgrac2[i, j].Click += new EventHandler(PoljaIgrac2_Click);
                    this.Controls.Add(poljaIgrac2[i, j]);
                }
            }

            // Prikaz imena igrača
            Label imeIgraca1Label = new Label();
            imeIgraca1Label.Text = engine.Igrac1.Ime;
            imeIgraca1Label.Location = new Point(30 * velicinaTable / 2, 30 * velicinaTable + 10);
            imeIgraca1Label.AutoSize = true;
            this.Controls.Add(imeIgraca1Label);

            Label imeIgraca2Label = new Label();
            imeIgraca2Label.Text = engine.Igrac2.Ime;
            imeIgraca2Label.Location = new Point(30 * velicinaTable / 2 + 40 * velicinaTable, 30 * velicinaTable + 10);
            imeIgraca2Label.AutoSize = true;
            this.Controls.Add(imeIgraca2Label);

            InicijalizujPolja(poljaIgrac1, engine.Igrac1.Brodovi);
            InicijalizujPolja(poljaIgrac2, engine.Igrac2.Brodovi);

            // 
            // FormaZaIgru
            // 
            this.ClientSize = new System.Drawing.Size(40 * velicinaTable * 2, 40 * velicinaTable + 50);
            this.Name = "FormaZaIgru";
            this.Text = "Igra";
            this.ResumeLayout(false);
            this.PerformLayout();
        }


        private void InicijalizujPolja(Button[,] polja, List<Brod> brodovi)
        {
            foreach (var brod in brodovi)
            {
                foreach (var pozicija in brod.Pozicije)
                {
                    polja[pozicija.X, pozicija.Y].BackColor = Color.Gray;
                }
            }
        }

        private void PoljaIgrac1_Click(object sender, EventArgs e)
        {
            Button pritisnutoDugme = sender as Button;
            if (pritisnutoDugme == null)
            {
                return;
            }

            int x = pritisnutoDugme.Location.X / 30;
            int y = pritisnutoDugme.Location.Y / 30;

            engine.NapraviPotez(x, y);
        }

        private void PoljaIgrac2_Click(object sender, EventArgs e)
        {
            Button pritisnutoDugme = sender as Button;
            if (pritisnutoDugme == null)
                return;

            int x = pritisnutoDugme.Location.X / 30;
            int y = pritisnutoDugme.Location.Y / 30;

            engine.NapraviPotez(x, y);
        }

        private void Engine_NaPogodak(Point pozicija, bool igrac1NaPotezu)
        {
            var polja = igrac1NaPotezu ? poljaIgrac2 : poljaIgrac1;
            polja[pozicija.X, pozicija.Y].BackColor = Color.Red;
            MessageBox.Show("Pogodak!");
        }

        private void Engine_NaPromasaj(Point pozicija)
        {
            var polja = engine.Igrac1NaPotezu ? poljaIgrac2 : poljaIgrac1;
            polja[pozicija.X, pozicija.Y].BackColor = Color.Blue;
            MessageBox.Show("Promašaj!");
        }

        private void Engine_NaPromenuPoteza(string imeIgracaNaPotezu)
        {
            MessageBox.Show($"Na potezu je: {imeIgracaNaPotezu}");
        }

        public delegate void Engine_NaPogodakDelegate(Point pozicija, bool igrac1NaPotezu);
        public delegate void Engine_NaPromasajDelegate(Point pozicija);
        public delegate void Engine_NaPromenuPotezaDelegate(string imeIgracaNaPotezu);
    }
}
