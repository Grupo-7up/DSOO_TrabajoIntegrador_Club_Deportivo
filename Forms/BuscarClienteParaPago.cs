using MySql.Data.MySqlClient; // Asegurate de tener el using de MySQL
using System;
using System.Windows.Forms;
using TrabajoIntegrador.Clases;

namespace TrabajoIntegrador
{
    public partial class BuscarClienteParaPago : FormBase
    {
        public BuscarClienteParaPago()
        {
            InitializeComponent();
            // Opcional: cargar tipos de documento en el ComboBox si lo tenés
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string tipoDoc = cmbTipoDocumento.Text.Trim();
            string nroDoc = txtNumeroDocumento.Text.Trim();

            if (string.IsNullOrEmpty(nroDoc))
            {
                MessageBox.Show("Por favor, ingrese un número de documento.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Consultamos los datos básicos del cliente
            if (ConexionBD.ObtenerDatosClienteParaPago(tipoDoc, nroDoc, out int idCliente, out bool esSocio, out string nombre, out string apellido))
            {
                // 🛑 VALIDACIÓN NUEVA: Si es socio, verificamos si ya abonó el período corriente
                if (esSocio && ConexionBD.EstaCuotaMesActualPagada(idCliente))
                {
                    MessageBox.Show($"El socio {nombre} {apellido} ya tiene la cuota correspondiente al período corriente paga.",
                                    "Cuota al Día", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return; // Detenemos el flujo y no abrimos la ventana de pagos
                }

                Cliente clienteEncontrado = new Cliente(nombre, apellido, tipoDoc, nroDoc, "", 0, DateTime.Now, esSocio, true);
                clienteEncontrado.Id = idCliente; // Asignamos el ID de la base de datos

                // Abrimos la pasarela de pagos pasándole el objeto completo
                var frmGestionPago = new GestionPago(clienteEncontrado);
                frmGestionPago.Show();

                this.Hide();
                this.Dispose();
            }
            else
            {
                MessageBox.Show("El cliente no se encuentra registrado en el sistema.", "No encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            VolverAlMenu(); 
        }
    }
}