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

        private void btn_inscribirCliente_Click(object sender, EventArgs e)
        {
            var frm = new TrabajoIntegrador.IngresarCliente();
            frm.Show();
            this.Close();
        }
    }
}