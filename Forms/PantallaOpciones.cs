namespace Pantalla_De_Opciones
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var frm = new WinFormsApp1.IngresarCliente())
            {
                frm.ShowDialog();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
        }
    }
}