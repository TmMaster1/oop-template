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
    public partial class FormaZaIzborTable : Form
    {

        public int IzabranaVelicinaTable { get; private set; }
        public FormaZaIzborTable()
        {
            InitializeComponent();
        }

        private void FormaZaIzborTable_Load(object sender, EventArgs e)
        {

        }

        private void labelIzborVelicinePolja_Click(object sender, EventArgs e)
        {

        }

        private void radioBtn4x4_CheckedChanged(object sender, EventArgs e)
        {
            /*if (radioBtn4x4.Checked)
            {
                IzabranaVelicinaTable = 4;
            }*/
        }

        private void radioBtn8x8_CheckedChanged(object sender, EventArgs e)
        {
            /*if (radioBtn8x8.Checked)
            {
                IzabranaVelicinaTable = 8;
            }*/
        }

        private void radioBtn10x10_CheckedChanged(object sender, EventArgs e)
        {
            /*if (radioBtn10x10.Checked)
            {
                IzabranaVelicinaTable = 10;
            }*/
        }

        private void potvrdiBtn_Click(object sender, EventArgs e)
        {
            if (radioBtn4x4.Checked)
                IzabranaVelicinaTable = 4;
            else if (radioBtn8x8.Checked)
                IzabranaVelicinaTable = 8;
            else if (radioBtn10x10.Checked)
                IzabranaVelicinaTable = 10;

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
