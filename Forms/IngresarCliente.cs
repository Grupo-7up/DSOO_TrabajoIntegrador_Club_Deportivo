using System;
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
                    MessageBox.Show("Cliente registrado correctamente.\nA continuación, se procederá a la pantalla de cobro.",
                                    "Éxito",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);

                    Cliente clienteNuevo = new Cliente(nombre, apellido, tipoDoc, documento, email, 0, fechaNacimiento, esSocio, aptoFisico);
                    clienteNuevo.Id = idClienteGenerado;
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
    }
}