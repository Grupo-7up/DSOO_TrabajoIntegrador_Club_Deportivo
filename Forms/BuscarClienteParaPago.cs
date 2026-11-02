using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient; // Asegurate de tener el using de MySQL

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

            // Validar existencia usando el procedimiento almacenado sp_existe_cliente
            if (ClienteExiste(tipoDoc, nroDoc, out bool esSocio, out int idCliente))
            {
                // Si existe, abrimos el Paso 2 (Gestión de Pago) y le pasamos los datos necesarios
                var frmGestionPago = new GestionPago(tipoDoc, nroDoc, esSocio, idCliente);
                frmGestionPago.Show();
                this.Close(); // Al cerrar este, FormBase se encarga de mantener la coherencia
            }
            else
            {
                MessageBox.Show("El cliente no se encuentra registrado en el sistema.", "No encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ClienteExiste(string tipoDoc, string nroDoc, out bool esSocio, out int idCliente)
        {
            esSocio = false;
            idCliente = 0;
            int existe = 0;

            // Cadena de conexión (podés adaptarla a tu clase de conexión global)
            string conexionString = "server=localhost;database=club_deportivo;uid=root;pwd=;";

            using (MySqlConnection conn = new MySqlConnection(conexionString))
            {
                try
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("sp_existe_cliente", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("p_tipo_documento", tipoDoc);
                        cmd.Parameters.AddWithValue("p_documento", nroDoc);

                        // Parámetro de salida
                        MySqlParameter paramExiste = new MySqlParameter("p_existe", MySqlDbType.Int32);
                        paramExiste.Direction = System.Data.ParameterDirection.Output;
                        cmd.Parameters.Add(paramExiste);

                        cmd.ExecuteNonQuery();

                        existe = Convert.ToInt32(cmd.Parameters["p_existe"].Value);
                    }

                    if (existe > 0)
                    {
                        // Consultamos adicionalmente si es socio (puedes unificarlo o hacer una consulta rápida)
                        // Aquí determinamos el estado socio/no socio para pasar al Paso 2
                        // ...
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al verificar el cliente: " + ex.Message, "Error de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return false;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            VolverAlMenu(); 
        }
    }
}