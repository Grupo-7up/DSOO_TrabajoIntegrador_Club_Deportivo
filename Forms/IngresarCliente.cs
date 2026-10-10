using System;
using System.Windows.Forms;
using TrabajoIntegrador.Clases;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace TrabajoIntegrador
{
    public partial class IngresarCliente : Form
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

            // Identificación del documento para verificación
            string documento = txtDocumento.Text.Trim();

            // 1. Verificar si el cliente ya existe
            if (ConexionBD.ExisteCliente(documento))
            {
                MessageBox.Show("Ya existe un cliente registrado con ese número de documento.",
                                "Cliente existente",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Extraer y convertir datos del formulario
                string nombre = txtNombre.Text.Trim();
                string apellido = txtApellido.Text.Trim();
                string tipoDoc = cboTipoDoc.SelectedItem.ToString();
                string email = txtEmail.Text.Trim();

                int.TryParse(txtTelefono.Text.Trim(), out int telefono);

                DateTime fechaNacimiento = dtpFechaNacimiento.Value;

                bool esSocio = chkEsSocio.Checked;
                bool aptoFisico = chkAptoFisico.Checked;

                // Crear el objeto Cliente con los datos ingresados
                Cliente nuevoCliente = new Cliente(
                    nombre,
                    apellido,
                    tipoDoc,
                    documento,
                    email,
                    telefono,
                    fechaNacimiento,
                    esSocio,
                    aptoFisico
                );

                // Llamar al método registrar_cliente de la instancia global de Club
                bool registrado = Program.MiClub.registrar_cliente(nuevoCliente);

                if (registrado)
                {
                    string mensaje = nuevoCliente.EsSocio
                        ? $"Socio registrado correctamente.\nNúmero de documento: {nuevoCliente.Documento}"
                        : "Cliente no socio registrado correctamente.";

                    MessageBox.Show(mensaje,
                                    "Éxito",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    LimpiarFormulario();
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
            var frm = new PantallaOpciones();
            frm.Show();
            this.Close();
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