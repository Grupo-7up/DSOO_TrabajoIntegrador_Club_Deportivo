using System;
using System.Windows.Forms;

namespace TrabajoIntegrador
{
    public partial class ConfiguracionConexion : Form
    {
        public ConfiguracionConexion()
        {
            InitializeComponent();
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtServer.Text) ||
                string.IsNullOrWhiteSpace(txtPuerto.Text) ||
                string.IsNullOrWhiteSpace(txtBaseDatos.Text) ||
                string.IsNullOrWhiteSpace(txtUsuario.Text))
            {
                MessageBox.Show("Complete todos los datos de conexión.", "Datos incompletos",
                                 MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Cargamos los datos ingresados por teclado en ConexionBD
            ConexionBD.Server = txtServer.Text.Trim();
            ConexionBD.Port = txtPuerto.Text.Trim();
            ConexionBD.Database = txtBaseDatos.Text.Trim();
            ConexionBD.User = txtUsuario.Text.Trim();
            ConexionBD.Password = txtPassword.Text;

            this.Cursor = Cursors.WaitCursor;
            // Probamos contra el servidor, no contra la base todavía: en una instalación
            // nueva club_deportivo_grupo7 no existe hasta que DatabaseInitializer la crea.
            try
            {
                using (var conexionPrueba = ConexionBD.ObtenerConexionServidor())
                {
                    conexionPrueba.Open();
                }
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                // Mostramos el motivo real (y no un mensaje genérico) para poder diagnosticar.
                MessageBox.Show("No se pudo conectar con esos datos:\n\n" + ex.Message,
                                 "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.Cursor = Cursors.Default;

            try
            {
                DatabaseInitializer.InicializarBaseDeDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se conectó al servidor, pero falló la inicialización de la base: " + ex.Message,
                                 "Error de inicialización", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Importante: NO hacer Dispose() acá. ConfiguracionConexion es el formulario
            // principal que recibió Application.Run() en Program.cs; si se destruye, WinForms
            // corta el bucle de mensajes y cierra toda la aplicación (aunque Login ya esté
            // abierto). Alcanza con ocultarlo, igual que hace Login.cs al pasar a PantallaOpciones.
            var frmLogin = new Login();
            frmLogin.Show();
            this.Hide();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
