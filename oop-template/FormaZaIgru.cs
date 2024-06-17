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
        public List<Brod> brodovi;
        public FormaZaIgru()
        {
            InitializeComponent();
        }

        private void FormaZaIgru_Load(object sender, EventArgs e)
        {

        }

        private void CustomInitializeComponent()
        {
           
        }

        public void PostaviBrodove(List<Brod> brodovi) 
        {
            for (int i = 0; i < brodovi.Count; i++) 
            {

            }
        }
    }
}
