using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using TrabajoIntegrador.Clases;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace TrabajoIntegrador
{
    public partial class IngresarCliente : FormBase
    {
        public IngresarCliente()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (!CamposCompletos())
            {
                MessageBox.Show("Debe completar los campos obligatorios.",
                                "Datos incompletos",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            string documento = txtDocumento.Text.Trim();
            string tipoDoc = cboTipoDoc.SelectedItem.ToString();

            if (ConexionBD.ExisteCliente(tipoDoc, documento))
            {
                MessageBox.Show("Ya existe un cliente registrado con ese número de documento.",
                                "Cliente existente",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string nombre = txtNombre.Text.Trim();
                string apellido = txtApellido.Text.Trim();
                string email = txtEmail.Text.Trim();
                string telefono = txtTelefono.Text.Trim(); // <-- Lo manejamos como string directamente

                DateTime fechaNacimiento = dtpFechaNacimiento.Value;
                bool esSocio = chkEsSocio.Checked;
                bool aptoFisico = chkAptoFisico.Checked;

                int idClienteGenerado;

                // Llamamos al método actualizado con el out en su posición correcta
                bool registrado = ConexionBD.RegistrarCliente(
                    tipoDoc, documento, nombre, apellido, email, telefono, fechaNacimiento,
                    out idClienteGenerado, esSocio, aptoFisico
                );

                if (registrado)
                {
                    Cliente clienteNuevo = new Cliente(
                        nombre, apellido, tipoDoc, documento,
                        email, telefono, fechaNacimiento,
                        esSocio, aptoFisico
                    );

                    clienteNuevo.Id = idClienteGenerado;

                    // Emitimos el carnet antes de mostrar el mensaje
                    Program.MiClub.emitir_carnet(clienteNuevo);

                    string mensaje;

                    if (clienteNuevo.EsSocio)
                    {
                        if (!string.IsNullOrWhiteSpace(clienteNuevo.NroCarnet))
                        {
                            mensaje = "Socio registrado correctamente.\n" +
                                      "Número de carnet asignado: " +
                                      clienteNuevo.NroCarnet +
                                      "\nSe procederá a la pantalla de cobro.";
                        }
                        else
                        {
                            mensaje = "El socio se registró correctamente, " +
                                      "pero no se pudo obtener el número de carnet.";
                        }
                    }
                    else
                    {
                        mensaje = "Cliente registrado correctamente.\n" +
                                  "Se procederá a la pantalla de cobro.";
                    }

                    MessageBox.Show(mensaje,
                                    "Éxito",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);

                    // Derivamos automáticamente a GestionPago
                    var frmGestionPago = new GestionPago(clienteNuevo);
                    frmGestionPago.Show();

                    this.Hide();
                    this.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar cliente: " + ex.Message,
                                "Error de Base de Datos",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            VolverAlMenu();
        }

        private bool CamposCompletos()
        {
            errorProvider1.Clear();
            return ValidarControlesObligatorios();
        }

        private bool ValidarControlesObligatorios()
        {
            bool completo = true;

            // Validar Nombre
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                errorProvider1.SetError(txtNombre, "El nombre es obligatorio");
                completo = false;
            }

            // Validar Apellido
            if (string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                errorProvider1.SetError(txtApellido, "El apellido es obligatorio");
                completo = false;
            }

            // Validar Tipo de Documento
            if (cboTipoDoc.SelectedIndex == -1)
            {
                errorProvider1.SetError(cboTipoDoc, "Seleccione un tipo de documento");
                completo = false;
            }

            // Validar Documento
            if (string.IsNullOrWhiteSpace(txtDocumento.Text))
            {
                errorProvider1.SetError(txtDocumento, "El documento es obligatorio");
                completo = false;
            }

            // Validar Email (obligatorio + formato válido)
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                errorProvider1.SetError(txtEmail, "El email es obligatorio");
                completo = false;
            }
            else if (!Regex.IsMatch(txtEmail.Text.Trim(), @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                errorProvider1.SetError(txtEmail, "El email no tiene un formato válido");
                completo = false;
            }

            // Validar Teléfono
            if (string.IsNullOrWhiteSpace(txtTelefono.Text))
            {
                errorProvider1.SetError(txtTelefono, "El teléfono es obligatorio");
                completo = false;
            }

            // Validar Fecha de nacimiento (no puede ser una fecha futura)
            if (dtpFechaNacimiento.Value.Date > DateTime.Now.Date)
            {
                errorProvider1.SetError(dtpFechaNacimiento, "La fecha de nacimiento no puede ser futura");
                completo = false;
            }
            else
            {
                errorProvider1.SetError(dtpFechaNacimiento, "");
            }

            // Validar Apto físico
            if (!chkAptoFisico.Checked)
            {
                errorProvider1.SetError(chkAptoFisico, "El apto físico es obligatorio");
                completo = false;
            }

            return completo;
        }

        private void LimpiarFormulario()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            cboTipoDoc.SelectedIndex = -1;
            txtDocumento.Clear();
            txtTelefono.Clear();
            txtEmail.Clear();
            chkEsSocio.Checked = false;
            chkAptoFisico.Checked = false;
            errorProvider1.Clear();
            txtNombre.Focus();
        }

        private void lbl_tipoDocumento_Click(object sender, EventArgs e)
        {

        }

        private void lbl_telefono_Click(object sender, EventArgs e)
        {

        }
        
        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void chkAptoFisico_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkEsSocio_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtDocumento_TextChanged(object sender, EventArgs e)
        {

        }

        private void cboTipoDoc_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {

        }

        private void lbl_mail_Click(object sender, EventArgs e)
        {

        }

        private void lbl_apellido_Click(object sender, EventArgs e)
        {

        }

        private void lbl_nombre_Click(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtApellido_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}