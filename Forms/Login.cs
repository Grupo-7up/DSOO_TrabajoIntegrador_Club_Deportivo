namespace LoginPractica
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("El usuario es obligatorio.");
                textBox2.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("La contraseña es obligatoria.");
                textBox1.Focus();
                return;
            }

            // ejemplo con datos fijos, reemplazalo por tu validación real
            if (textBox2.Text == "admin" && textBox1.Text == "1234")
            {
                DialogResult = DialogResult.OK; // cierra el login y devuelve OK
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos.");
            }
        }
    }
    }
