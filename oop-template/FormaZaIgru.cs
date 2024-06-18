using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.Windows.Forms;

namespace oop_template
{
    public partial class FormaZaIgru : Form
    {
        private int velicinaTable;
        private Engine engine;
        private Button[,] poljaIgrac1;
        private Button[,] poljaIgrac2;
        public System.Media.SoundPlayer potapanjeZvuk;
        public System.Media.SoundPlayer promasajZvuk;
        public System.Media.SoundPlayer pobedaZvuk;
        public System.Media.SoundPlayer pogodakZvuk;

        public FormaZaIgru(Igrac igrac1, Igrac igrac2, int velicinaTable, bool jeDvaIgraca)
        {
            InitializeComponent();
            this.velicinaTable = velicinaTable;
            engine = new Engine(igrac1, igrac2, this, velicinaTable);
            potapanjeZvuk = new SoundPlayer("..\\..\\..\\sound\\potapanje.wav");
            potapanjeZvuk.Load();
            promasajZvuk = new SoundPlayer("..\\..\\..\\sound\\promasaj.wav");
            promasajZvuk.Load();
            pobedaZvuk = new SoundPlayer("..\\..\\..\\sound\\pobeda.wav");
            pobedaZvuk.Load();
            pogodakZvuk = new SoundPlayer("..\\..\\..\\sound\\pogodak.wav");
            pogodakZvuk.Load();
            engine.NaPogodak += Engine_NaPogodak;
            engine.NaPotapanje += Engine_NaPotapanje;
            engine.NaPromasaj += Engine_NaPromasaj;
            engine.NaPromenuPoteza += Engine_NaPromenuPoteza;
            engine.NaKrajIgre += Engine_NaKrajIgre;
            CustomInitializeComponent();
        }

        private void CustomInitializeComponent()
        {
            this.SuspendLayout();

            poljaIgrac1 = new Button[velicinaTable, velicinaTable];
            for (int i = 0; i < velicinaTable; i++)
            {
                for (int j = 0; j < velicinaTable; j++)
                {
                    poljaIgrac1[i, j] = new Button();
                    poljaIgrac1[i, j].Size = new Size(30, 30);
                    poljaIgrac1[i, j].Location = new Point(30 * i, 30 * j);
                    poljaIgrac1[i, j].Click += PoljaIgrac1_Click;
                    this.Controls.Add(poljaIgrac1[i, j]);
                }
            }

            poljaIgrac2 = new Button[velicinaTable, velicinaTable];
            for (int i = 0; i < velicinaTable; i++)
            {
                for (int j = 0; j < velicinaTable; j++)
                {
                    poljaIgrac2[i, j] = new Button();
                    poljaIgrac2[i, j].Size = new Size(30, 30);
                    poljaIgrac2[i, j].Location = new Point(30 * i + 40 * velicinaTable, 30 * j);
                    poljaIgrac2[i, j].Click += PoljaIgrac2_Click;
                    this.Controls.Add(poljaIgrac2[i, j]);
                }
            }

            Label imeIgraca1Label = new Label
            {
                Text = engine.Igrac1.Ime,
                Location = new Point(30 * velicinaTable / 2, 30 * velicinaTable + 10),
                AutoSize = true
            };
            this.Controls.Add(imeIgraca1Label);

            Label imeIgraca2Label = new Label
            {
                Text = engine.Igrac2.Ime,
                Location = new Point(30 * velicinaTable / 2 + 40 * velicinaTable, 30 * velicinaTable + 10),
                AutoSize = true
            };
            this.Controls.Add(imeIgraca2Label);

            InicijalizujPolja(poljaIgrac1, engine.Igrac1.Brodovi);
            InicijalizujPolja(poljaIgrac2, engine.Igrac2.Brodovi);

            this.ClientSize = new Size(40 * velicinaTable * 2, 40 * velicinaTable + 50);
            this.Name = "FormaZaIgru";
            this.Text = "Igra";
            this.Load += FormaZaIgru_Load;
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
            if (pritisnutoDugme == null) return;

            int x = pritisnutoDugme.Location.X / 30;
            int y = pritisnutoDugme.Location.Y / 30;

            engine.NapraviPotez(x, y);
        }

        private void PoljaIgrac2_Click(object sender, EventArgs e)
        {
            Button pritisnutoDugme = sender as Button;
            if (pritisnutoDugme == null) return;

            int x = (pritisnutoDugme.Location.X - 40 * velicinaTable) / 30;
            int y = pritisnutoDugme.Location.Y / 30;

            engine.NapraviPotez(x, y);
        }

        private void Engine_NaPogodak(Point pozicija)
        {
            var polja = engine.Igrac1NaPotezu ? poljaIgrac2 : poljaIgrac1;
            polja[pozicija.X, pozicija.Y].BackColor = Color.Red;
            pogodakZvuk.Play();
            MessageBox.Show("Pogodak!");
        }

        private void Engine_NaPotapanje(Point pozicija)
        {
            var polja = engine.Igrac1NaPotezu ? poljaIgrac2 : poljaIgrac1;
            polja[pozicija.X, pozicija.Y].BackColor = Color.DarkRed;
            potapanjeZvuk.Play();
            MessageBox.Show("Potopljen!");
        }

        private void Engine_NaPromasaj(Point pozicija)
        {
            var polja = engine.Igrac1NaPotezu ? poljaIgrac2 : poljaIgrac1;
            polja[pozicija.X, pozicija.Y].BackColor = Color.Gray;
            promasajZvuk.Play();
            MessageBox.Show("Promašaj!");
        }

        private void Engine_NaPromenuPoteza(string imeIgracaNaPotezu)
        {
            MessageBox.Show($"Na potezu je: {imeIgracaNaPotezu}");

            bool igrac1NaPotezu = engine.Igrac1NaPotezu;
            for (int i = 0; i < velicinaTable; i++)
            {
                for (int j = 0; j < velicinaTable; j++)
                {
                    poljaIgrac1[i, j].Enabled = !igrac1NaPotezu;
                    poljaIgrac2[i, j].Enabled = igrac1NaPotezu;
                }
            }
        }

        private void Engine_NaKrajIgre(string imePobednika)
        {
            pobedaZvuk.Play();
            MessageBox.Show($"Igra je završena! Pobednik je: {imePobednika}");

            DialogResult rezultat = MessageBox.Show("Želite li da započnete novu igru?", "Kraj igre", MessageBoxButtons.YesNo);
            if (rezultat == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.Retry;
            }
            else
            {
                this.DialogResult = DialogResult.OK;
            }

            this.Close();
        }

        private void FormaZaIgru_Load(object sender, EventArgs e)
        {
            Engine_NaPromenuPoteza(engine.Igrac1NaPotezu ? engine.Igrac1.Ime : engine.Igrac2.Ime);
        }
    }
}
