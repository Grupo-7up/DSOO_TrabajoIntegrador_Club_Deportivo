using System;
using System.Windows.Forms;

namespace TrabajoIntegrador
{
    public partial class PantallaOpciones : Form
    {
        public PantallaOpciones()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var frm = new TrabajoIntegrador.IngresarCliente())
            {
                frm.ShowDialog();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
        }
    }
}