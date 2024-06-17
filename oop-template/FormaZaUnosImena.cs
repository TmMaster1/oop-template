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
    public partial class FormaZaUnosImena : Form
    {
        public string ImeIgraca1 { get; private set; }
        public string ImeIgraca2 { get; private set; }

        public FormaZaUnosImena(bool jeDvaIgraca)
        {
            InitializeComponent();
            if (!jeDvaIgraca)
            {
                labelIgrac2.Visible = false;
                textBoxImeIgrac2.Visible = false;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            ImeIgraca1 = textBoxImeIgrac1.Text;
            ImeIgraca2 = textBoxImeIgrac2.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnOtkazi_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void FormaZaUnosImena_Load(object sender, EventArgs e)
        {

        }
    }
}
