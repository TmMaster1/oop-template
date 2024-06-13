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
        private int trenutniBrodIndex;
        private Brod trenutniBrod;
        private bool postavljanjeHorizontalno;

        public List<Brod> PostavljeniBrodovi
        {
            get { return postavljeniBrodovi; }
        }

        public FormaZaPostavljanjeBrodova(int velicinaTable, List<Brod> brodovi)
        {
            this.velicinaTable = velicinaTable;
            this.brodovi = brodovi;
            this.postavljeniBrodovi = new List<Brod>();
            CustomInitializeComponent();

            // Inicijalizacija postavljanja prvog broda
            this.trenutniBrodIndex = 0;
            PostaviTrenutniBrod();
            obrisiButton.Enabled = false; // Onemogućavamo brisanje broda odmah na početku
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
                    poljaTable[i, j].Size = new Size(30, 30);
                    poljaTable[i, j].Location = new Point(30 * i, 30 * j);
                    poljaTable[i, j].Click += new EventHandler(PoljaTable_Click);
                    this.Controls.Add(poljaTable[i, j]);
                }
            }

            // Labela za prikaz trenutnog broda
            this.trenutniBrodLabel = new Label();
            this.trenutniBrodLabel.Location = new Point(30 * velicinaTable, 30);
            this.trenutniBrodLabel.AutoSize = true;
            this.Controls.Add(this.trenutniBrodLabel);

            // Dugme za potvrdu
            this.potvrdiButton = new Button();
            this.potvrdiButton.Text = "Potvrdi";
            this.potvrdiButton.Location = new Point(30 * velicinaTable, 60);
            this.potvrdiButton.Click += new EventHandler(PotvrdiButton_Click);
            this.potvrdiButton.Enabled = false; // Disabled until all ships are placed
            this.Controls.Add(this.potvrdiButton);

            // Dugme za brisanje broda
            this.obrisiButton = new Button();
            this.obrisiButton.Text = "Obriši brod";
            this.obrisiButton.Location = new Point(30 * velicinaTable, 90);
            this.obrisiButton.Click += new EventHandler(ObrisiButton_Click);
            this.obrisiButton.Enabled = false; // Disabled until at least one ship is placed
            this.Controls.Add(this.obrisiButton);

            // 
            // FormaZaPostavljanjeBrodova
            // 
            this.ClientSize = new System.Drawing.Size(30 * (velicinaTable + 2), 30 * velicinaTable);
            this.Name = "FormaZaPostavljanjeBrodova";
            this.Text = "Postavljanje brodova";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void FormaZaPostavljanjeBrodova_Load(object sender, EventArgs e)
        {
            // Kod koji želite da izvršite kada se forma učita
        }

        private void PostaviBrod(int x, int y)
        {
            poljaTable[x, y].BackColor = Color.Gray; // Postavlja boju polja na sivu kako bi označilo deo broda
        }

        // Metoda za postavljanje dela broda na kliknuto polje
        private void PoljaTable_Click(object sender, EventArgs e)
        {
            Button pritisnutoDugme = sender as Button;
            if (pritisnutoDugme == null)
                return;

            int x = pritisnutoDugme.Location.X / 30;
            int y = pritisnutoDugme.Location.Y / 30;

            if (MozetePostavitiDeoBrod(x, y))
            {
                PostaviDeoBrod(x, y);
            }
            else
            {
                MessageBox.Show("Ne možete postaviti deo broda na ovu poziciju. Pokušajte ponovo.");
            }
        }

        private void ObrisiButton_Click(object sender, EventArgs e)
        {
            trenutniBrodLabel.Text = "Kliknite na bilo koji deo broda koji želite da obrišete.";
            foreach (var brod in postavljeniBrodovi)
            {
                foreach (var pozicija in brod.Pozicije)
                {
                    poljaTable[pozicija.X, pozicija.Y].Click += ObrisiBrodClick;
                }
            }
        }

        private void ObrisiBrodClick(object sender, EventArgs e)
        {
            Button pritisnutoDugme = sender as Button;
            if (pritisnutoDugme == null)
                return;

            int x = pritisnutoDugme.Location.X / 30;
            int y = pritisnutoDugme.Location.Y / 30;

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
                trenutniBrodLabel.Text = $"Postavite brod veličine {brodZaBrisanje.Velicina}";
                trenutniBrod = brodZaBrisanje;
                trenutniBrodIndex = brodovi.IndexOf(brodZaBrisanje);

                foreach (var pozicija in brodZaBrisanje.Pozicije)
                {
                    poljaTable[pozicija.X, pozicija.Y].Click -= ObrisiBrodClick;
                }
            }

            obrisiButton.Enabled = postavljeniBrodovi.Count > 0;
        }

        private void ObrisiBrod(Brod brod)
        {
            foreach (var pozicija in brod.Pozicije)
            {
                poljaTable[pozicija.X, pozicija.Y].BackColor = default(Color);
                poljaTable[pozicija.X, pozicija.Y].Enabled = true;
            }
            postavljeniBrodovi.Remove(brod);
            brodovi.Insert(trenutniBrodIndex, brod); // Vraćamo brod u listu za ponovno postavljanje
        }

        private void PotvrdiButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void PostaviTrenutniBrod()
        {
            trenutniBrod = brodovi[trenutniBrodIndex];
            trenutniBrod.Pozicije.Clear();
            trenutniBrodLabel.Text = $"Postavite brod veličine {trenutniBrod.Velicina}";
            obrisiButton.Enabled = postavljeniBrodovi.Count > 0;
        }

        private bool MozetePostavitiDeoBrod(int x, int y)
        {
            if (poljaTable[x, y].BackColor == Color.Gray)
                return false; // Polje je već zauzeto

            // Provera kontinuiteta postavljanja broda
            if (trenutniBrod.Pozicije.Count > 0)
            {
                var zadnjaPozicija = trenutniBrod.Pozicije[trenutniBrod.Pozicije.Count - 1];

                if (trenutniBrod.Pozicije.Count == 1)
                {
                    // Prvi deo broda je postavljen, čekamo drugi deo da odredimo orijentaciju
                    bool validPosHorizontalno = (x == zadnjaPozicija.X && Math.Abs(y - zadnjaPozicija.Y) == 1);
                    bool validPosVertikalno = (y == zadnjaPozicija.Y && Math.Abs(x - zadnjaPozicija.X) == 1);
                    return validPosHorizontalno || validPosVertikalno;
                }
                else
                {
                    // Nakon što smo postavili dva dela broda, odredili smo orijentaciju
                    if (postavljanjeHorizontalno)
                    {
                        if (x != zadnjaPozicija.X || Math.Abs(y - zadnjaPozicija.Y) != 1)
                            return false; // Horizontalna orijentacija, ali nije kontinuitet
                    }
                    else
                    {
                        if (y != zadnjaPozicija.Y || Math.Abs(x - zadnjaPozicija.X) != 1)
                            return false; // Vertikalna orijentacija, ali nije kontinuitet
                    }
                }
            }

            // Provera da li su susedna polja slobodna (uključujući dijagonalno)
            for (int dx = -1; dx <= 1; dx++)
            {
                for (int dy = -1; dy <= 1; dy++)
                {
                    int nx = x + dx;
                    int ny = y + dy;

                    if (nx >= 0 && nx < velicinaTable && ny >= 0 && ny < velicinaTable)
                    {
                        if (poljaTable[nx, ny].BackColor == Color.Gray)
                            return false; // Susedno polje je zauzeto
                    }
                }
            }

            return true;
        }

        private void PostaviDeoBrod(int x, int y)
        {
            poljaTable[x, y].BackColor = Color.Gray; // Oboji polje u sivo
            poljaTable[x, y].Enabled = false; // Onemogućava ponovni klik na isto polje
            trenutniBrod.Pozicije.Add(new Point(x, y));

            if (trenutniBrod.Pozicije.Count == 2)
            {
                // Određujemo orijentaciju broda na osnovu prve dve pozicije
                postavljanjeHorizontalno = trenutniBrod.Pozicije[0].Y == trenutniBrod.Pozicije[1].Y;
            }

            // Proveravamo da li je brod kompletiran
            if (trenutniBrod.Pozicije.Count == trenutniBrod.Velicina)
            {
                postavljeniBrodovi.Add(trenutniBrod);
                trenutniBrodIndex++;

                if (trenutniBrodIndex < brodovi.Count)
                {
                    PostaviTrenutniBrod();
                }
                else
                {
                    trenutniBrodLabel.Text = "Svi brodovi su postavljeni.";
                    potvrdiButton.Enabled = true;
                    obrisiButton.Enabled = true;
                }
            }
        }


        private Label trenutniBrodLabel;
        private Button potvrdiButton;
        private Button obrisiButton;
    }
}

// ovde ima bugova, mora da se fixa ili da se reworkuje ceo sistem za ovo (npr. da se ubace slike i tako da se postavlja na matricu ili da se odjednom postavi ceo brod, bira se smer pre toga)
// mora da se resi bug za brisanje brodova, nece da brise ne radi