using System;
using System.Data;
using System.Windows.Forms;

namespace TrabajoIntegrador
{
    public partial class ListarVencimientos : FormBase
    {
        public ListarVencimientos()
        {
            InitializeComponent();
        }

        private void ListarVencimientos_Load(object sender, EventArgs e)
        {
            // Fecha y hora en la que se realiza la consulta (momento de la ejecución)
            lblFechaConsulta.Text = "Consulta realizada el: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm");

            // Por defecto, se verifica el día de hoy; el usuario puede elegir otra fecha
            dtpFechaVerificar.Value = DateTime.Now.Date;
            CargarVencimientos(dtpFechaVerificar.Value.Date);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarVencimientos(dtpFechaVerificar.Value.Date);
        }

        private void CargarVencimientos(DateTime fecha)
        {
            lstVencimientos.Items.Clear();

            try
            {
                DataTable dt = ConexionBD.ObtenerClientesVencidos(fecha);

                if (dt.Rows.Count == 0)
                {
                    lstVencimientos.Items.Add($"No hay socios con la cuota vencida el {fecha:dd/MM/yyyy}.");
                    return;
                }

                foreach (DataRow row in dt.Rows)
                {
                    string nombre = row["nombre"].ToString();
                    string apellido = row["apellido"].ToString();
                    string tipoDoc = row["tipo_documento"].ToString();
                    string documento = row["documento"].ToString();
                    DateTime validez = Convert.ToDateTime(row["validez"]);

                    lstVencimientos.Items.Add($"{apellido}, {nombre} — {tipoDoc} {documento} — Vence el {validez:dd/MM/yyyy}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al consultar los vencimientos: " + ex.Message,
                                 "Error de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            VolverAlMenu();
        }

        private void lblTitulo_Click(object sender, EventArgs e)
        {

        }
    }
}
