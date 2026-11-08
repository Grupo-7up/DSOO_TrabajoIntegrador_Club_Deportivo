using System;
using System.Windows.Forms;

namespace TrabajoIntegrador
{
    public partial class PantallaOpciones : Form
    {
        private bool _saliendoPorNavegacion = false;

        public PantallaOpciones()
        {
            InitializeComponent();
        }

        private void btn_inscribirCliente_Click(object sender, EventArgs e)
        {
            _saliendoPorNavegacion = true;

            var frm = new TrabajoIntegrador.IngresarCliente();
            frm.Show();
            this.Close();
        }

        private void btn_pagarCuota_Click(object sender, EventArgs e)
        {
            _saliendoPorNavegacion = true;
            var frm = new TrabajoIntegrador.BuscarClienteParaPago();
            frm.Show();
            this.Close();
        }

        private void btn_listarVencimiento_Click(object sender, EventArgs e)
        {
            _saliendoPorNavegacion = true;
            var frm = new TrabajoIntegrador.ListarVencimientos();
            frm.Show();
            this.Close();
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show(
                "¿Estás seguro de que querés salir de la aplicación?",
                "Salir",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (resultado == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            // Si el usuario presiona la 'X' para cerrar la pantalla principal
            if (!_saliendoPorNavegacion && e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult resultado = MessageBox.Show(
                    "¿Estás seguro de que querés salir de la aplicación?",
                    "Salir",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (resultado == DialogResult.Yes)
                {
                    // Cierra por completo el proceso y libera Visual Studio
                    Application.Exit();
                }
                else
                {
                    // Si el usuario se arrepiente, cancelamos el cierre
                    e.Cancel = true;
                }
            }
        }
    }
}