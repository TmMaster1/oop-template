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
    public partial class FormaZaPostavljanjeBrodova : Form
    {
        private int velicinaTable;
        private List<Brod> brodovi;
        private List<Brod> postavljeniBrodovi;
        private Button[,] poljaTable;
        private Brod trenutniBrod;
        private Smer postavljanjeSmer;

        private enum Smer
        {
            Gore,
            Dole,
            Levo,
            Desno
        }

        public List<Brod> PostavljeniBrodovi
        {
            get { return postavljeniBrodovi; }
        }

        public FormaZaPostavljanjeBrodova(int velicinaTable, List<Brod> brodovi)
        {
            this.velicinaTable = velicinaTable;
            this.brodovi = new List<Brod>(brodovi); // Napravimo kopiju liste brodova
            this.postavljeniBrodovi = new List<Brod>();
            CustomInitializeComponent();
        }

        private void CustomInitializeComponent()
        {
            this.SuspendLayout();

            // Dinamičko kreiranje dugmadi za polja table
            poljaTable = new Button[velicinaTable, velicinaTable];
            for (int i = 0; i < velicinaTable; i++)
            {
                for (int j = 0; j < velicinaTable; j++)
                {
                    poljaTable[i, j] = new Button();
                    poljaTable[i, j].Size = new Size(40, 40); // Povećana veličina
                    poljaTable[i, j].Location = new Point(40 * i, 40 * j); // Povećan razmak
                    poljaTable[i, j].Click += new EventHandler(PoljaTable_Click);
                    this.Controls.Add(poljaTable[i, j]);
                }
            }

            // Labela za prikaz trenutnog broda
            this.trenutniBrodLabel = new Label();
            this.trenutniBrodLabel.Location = new Point(40 * velicinaTable, 30);
            this.trenutniBrodLabel.AutoSize = true;
            this.Controls.Add(this.trenutniBrodLabel);

            // Dugme za potvrdu
            this.potvrdiButton = new Button();
            this.potvrdiButton.Text = "Potvrdi";
            this.potvrdiButton.Location = new Point(40 * velicinaTable, 60);
            this.potvrdiButton.Click += new EventHandler(PotvrdiButton_Click);
            this.potvrdiButton.Enabled = false; // Disabled until all ships are placed
            this.Controls.Add(this.potvrdiButton);

            // ComboBox za izbor smera postavljanja broda
            this.smerComboBox = new ComboBox();
            this.smerComboBox.Location = new Point(40 * velicinaTable, 90);
            this.smerComboBox.Items.AddRange(new string[] { "Gore", "Dole", "Levo", "Desno" });
            this.smerComboBox.SelectedIndex = 0;
            this.smerComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.smerComboBox.SelectedIndexChanged += new EventHandler(SmerComboBox_SelectedIndexChanged);
            this.Controls.Add(this.smerComboBox);

            // ComboBox za izbor broda za postavljanje
            this.brodComboBox = new ComboBox();
            this.brodComboBox.Location = new Point(40 * velicinaTable, 120);
            foreach (var brod in brodovi)
            {
                this.brodComboBox.Items.Add($"Brod veličine {brod.Velicina}");
            }
            this.brodComboBox.SelectedIndex = 0;
            this.brodComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.brodComboBox.SelectedIndexChanged += new EventHandler(BrodComboBox_SelectedIndexChanged);
            this.Controls.Add(this.brodComboBox);

            // ComboBox za izbor akcije (Postavi ili Obriši)
            this.akcijaComboBox = new ComboBox();
            this.akcijaComboBox.Location = new Point(40 * velicinaTable, 150);
            this.akcijaComboBox.Items.AddRange(new string[] { "Postavi", "Obriši" });
            this.akcijaComboBox.SelectedIndex = 0;
            this.akcijaComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.akcijaComboBox.SelectedIndexChanged += new EventHandler(AkcijaComboBox_SelectedIndexChanged);
            this.Controls.Add(this.akcijaComboBox);

            // Postavljanje početnih vrednosti
            PostaviTrenutniBrod();

            // 
            // FormaZaPostavljanjeBrodova
            // 
            this.ClientSize = new System.Drawing.Size(40 * (velicinaTable + 5), 40 * velicinaTable);
            this.Name = "FormaZaPostavljanjeBrodova";
            this.Text = "Postavljanje brodova";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void FormaZaPostavljanjeBrodova_Load(object sender, EventArgs e)
        {
            // Kod koji želite da izvršite kada se forma učita
        }

        private void PoljaTable_Click(object sender, EventArgs e)
        {
            Button pritisnutoDugme = sender as Button;
            if (pritisnutoDugme == null)
                return;

            int x = pritisnutoDugme.Location.X / 40;
            int y = pritisnutoDugme.Location.Y / 40;

            if (akcijaComboBox.SelectedIndex == 0) // Postavi
            {
                if (MozetePostavitiBrod(x, y))
                {
                    PostaviBrodNaPolje(x, y);
                }
                else
                {
                    MessageBox.Show("Ne možete postaviti brod na ovu poziciju. Pokušajte ponovo.");
                }
            }
            else if (akcijaComboBox.SelectedIndex == 1) // Obriši
            {
                if (poljaTable[x, y].BackColor == Color.Gray)
                {
                    Brod brodZaBrisanje = null;

                    foreach (var brod in postavljeniBrodovi)
                    {
                        if (brod.Pozicije.Contains(new Point(x, y)))
                        {
                            brodZaBrisanje = brod;
                            break;
                        }
                    }

                    if (brodZaBrisanje != null)
                    {
                        ObrisiBrod(brodZaBrisanje);
                        brodComboBox.Items.Insert(0, $"Brod veličine {brodZaBrisanje.Velicina}");
                        brodovi.Insert(0, brodZaBrisanje);
                    }
                }
                else
                {
                    MessageBox.Show("Nema broda na ovoj poziciji. Pokušajte ponovo.");
                }
            }
        }

        private void PotvrdiButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void PostaviTrenutniBrod()
        {
            if (brodovi.Count > 0)
            {
                trenutniBrod = brodovi[brodComboBox.SelectedIndex];
                trenutniBrod.Pozicije.Clear();
                trenutniBrodLabel.Text = $"Postavite brod veličine {trenutniBrod.Velicina}";
            }
            else
            {
                trenutniBrod = null;
                trenutniBrodLabel.Text = "Svi brodovi su postavljeni.";
                potvrdiButton.Enabled = true;
            }
        }

        private bool MozetePostavitiBrod(int x, int y)
        {
            if (trenutniBrod == null)
                return false;

            List<Point> pozicijeZaPostavljanje = new List<Point>();

            for (int i = 0; i < trenutniBrod.Velicina; i++)
            {
                int nx = x;
                int ny = y;

                switch (postavljanjeSmer)
                {
                    case Smer.Gore:
                        ny = y - i;
                        break;
                    case Smer.Dole:
                        ny = y + i;
                        break;
                    case Smer.Levo:
                        nx = x - i;
                        break;
                    case Smer.Desno:
                        nx = x + i;
                        break;
                }

                if (nx < 0 || ny < 0 || nx >= velicinaTable || ny >= velicinaTable)
                    return false; // Prelazi granice table

                if (poljaTable[nx, ny].BackColor == Color.Gray)
                    return false; // Polje je već zauzeto

                pozicijeZaPostavljanje.Add(new Point(nx, ny));
            }

            // Provera susednih polja
            foreach (var pozicija in pozicijeZaPostavljanje)
            {
                if (!JePoljeSlobodno(pozicija.X, pozicija.Y))
                    return false;
            }

            return true;
        }

        private bool JePoljeSlobodno(int x, int y)
        {
            int[] dx = { -1, 0, 1 };
            int[] dy = { -1, 0, 1 };

            foreach (var i in dx)
            {
                foreach (var j in dy)
                {
                    int nx = x + i;
                    int ny = y + j;

                    if (nx >= 0 && ny >= 0 && nx < velicinaTable && ny < velicinaTable)
                    {
                        if (poljaTable[nx, ny].BackColor == Color.Gray)
                            return false;
                    }
                }
            }

            return true;
        }

        private void PostaviBrodNaPolje(int x, int y)
        {
            for (int i = 0; i < trenutniBrod.Velicina; i++)
            {
                int nx = x;
                int ny = y;

                switch (postavljanjeSmer)
                {
                    case Smer.Gore:
                        ny = y - i;
                        break;
                    case Smer.Dole:
                        ny = y + i;
                        break;
                    case Smer.Levo:
                        nx = x - i;
                        break;
                    case Smer.Desno:
                        nx = x + i;
                        break;
                }

                poljaTable[nx, ny].BackColor = Color.Gray;
                trenutniBrod.Pozicije.Add(new Point(nx, ny));
            }

            postavljeniBrodovi.Add(trenutniBrod);
            brodovi.Remove(trenutniBrod);
            brodComboBox.Items.RemoveAt(brodComboBox.SelectedIndex);

            if (brodovi.Count > 0)
            {
                brodComboBox.SelectedIndex = 0;
                PostaviTrenutniBrod();
            }
            else
            {
                trenutniBrodLabel.Text = "Svi brodovi su postavljeni.";
                trenutniBrod = null;
                potvrdiButton.Enabled = true;
            }
        }

        private void ObrisiBrod(Brod brod)
        {
            foreach (var pozicija in brod.Pozicije)
            {
                poljaTable[pozicija.X, pozicija.Y].BackColor = Color.White;
            }
            postavljeniBrodovi.Remove(brod);
        }

        private void SmerComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (smerComboBox.SelectedIndex)
            {
                case 0:
                    postavljanjeSmer = Smer.Gore;
                    break;
                case 1:
                    postavljanjeSmer = Smer.Dole;
                    break;
                case 2:
                    postavljanjeSmer = Smer.Levo;
                    break;
                case 3:
                    postavljanjeSmer = Smer.Desno;
                    break;
            }
        }

        private void BrodComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            PostaviTrenutniBrod();
        }

        private void AkcijaComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateControlsState();
        }

        private void UpdateControlsState()
        {
            if (akcijaComboBox.SelectedIndex == 0) // Postavi
            {
                brodComboBox.Enabled = true;
                smerComboBox.Enabled = true;
            }
            else if (akcijaComboBox.SelectedIndex == 1) // Obriši
            {
                brodComboBox.Enabled = false;
                smerComboBox.Enabled = false;
            }
        }

        private Button potvrdiButton;
        private Label trenutniBrodLabel;
        private ComboBox brodComboBox;
        private ComboBox smerComboBox;
        private ComboBox akcijaComboBox;
    }
}

// REWORKAN SISTEM