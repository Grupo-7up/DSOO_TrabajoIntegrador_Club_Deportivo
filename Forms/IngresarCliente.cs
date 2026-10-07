namespace WinFormsApp1
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (!CamposCompletos())
            {
                MessageBox.Show("Debe completar todos los campos obligatorios.",
                                "Datos incompletos",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            // acá va la acción de registrar
        }

        private bool CamposCompletos()
        {
            errorProvider1.Clear();
            return ValidarControles(this);
        }

        private bool ValidarControles(Control contenedor)
        {
            bool completo = true;

            foreach (Control c in contenedor.Controls)
            {
                if (c is TextBox txt && string.IsNullOrWhiteSpace(txt.Text))
                {
                    errorProvider1.SetError(txt, "Campo obligatorio");
                    completo = false;
                }
                else if (c is ComboBox cmb && cmb.SelectedIndex == -1)
                {
                    errorProvider1.SetError(cmb, "Seleccione una opción");
                    completo = false;
                }

                if ((c is GroupBox || c is Panel) && !ValidarControles(c))
                {
                    completo = false;
                }
            }

            return completo;
        }
    }
}