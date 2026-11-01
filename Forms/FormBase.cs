using System;
using System.Windows.Forms;

namespace TrabajoIntegrador
{
    public class FormBase : Form
    {
        protected bool _cerrarConVolver = false;

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            // Si el usuario presiona la 'X' y no se usó el botón Volver
            if (!_cerrarConVolver && e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true; // Cancela el cierre abrupto

                // Reutilizamos el método unificado
                VolverAlMenu();
            }
        }

        // Único lugar donde se define la lógica para volver a la pantalla principal
        protected void VolverAlMenu()
        {
            _cerrarConVolver = true;
            var principal = new PantallaOpciones();
            principal.Show();
            this.Close();
        }
    }
}