using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace TrabajoIntegrador
{
    public partial class GestionPago : FormBase
    {
        // Datos recibidos del Paso 1
        private int _idCliente;
        private string _tipoDoc;
        private string _nroDoc;
        private bool _esSocio;

        // Monto total acumulado
        private decimal _montoTotal = 0;

        // Constructor que recibe la información del cliente desde BuscarClienteParaPago
        public GestionPago(string tipoDoc, string nroDoc, bool esSocio, int idCliente)
        {
            InitializeComponent();

            InicializarInterfazVisual();
            _tipoDoc = tipoDoc;
            _nroDoc = nroDoc;
            _esSocio = esSocio;
            _idCliente = idCliente;

            ConfigurarPantallaSegunTipoCliente();
        }

        private void GestionPago_Load(object sender, EventArgs e)
        {
            // Cargar datos básicos del cliente en pantalla
            lblDatosCliente.Text = $"Cliente: {_tipoDoc} {_nroDoc} - Type: {(_esSocio ? "SOCIO" : "NO SOCIO")}";

            ConfigurarPantallaSegunTipoCliente();
        }

        private void ConfigurarPantallaSegunTipoCliente()
        {
            if (_esSocio)
            {
                // SOCIO: Cuota mensual fija
                panelActividades.Visible = false; // Ocultamos selector de actividades
                lblTituloCobro.Text = "Cobro de Cuota Mensual (Socio)";

                // Ejemplo: Monto fijo de cuota mensual (podés traerlo de la BBDD o una constante)
                _montoTotal = 5000;
                lblMontoTotal.Text = $"$ {_montoTotal:N2}";
            }
            else
            {
                // NO SOCIO: Cobro diario por actividades acumuladas
                panelActividades.Visible = true;
                lblTituloCobro.Text = "Selección de Actividades - Pase Diario (No Socio)";
                _montoTotal = 0;
                lblMontoTotal.Text = "$ 0.00";

                CargarActividadesDisponibles();
            }
        }

        private void CargarActividadesDisponibles()
        {
            try
            {
                // Llamamos al método centralizado en la carpeta BBDD
                DataTable dt = ConexionBD.ObtenerActividades();

                lstDisponibles.Items.Clear();

                foreach (DataRow row in dt.Rows)
                {
                    int id = Convert.ToInt32(row["id_actividad"]);
                    string nombre = row["nombre"].ToString();
                    decimal costo = Convert.ToDecimal(row["valor_actividad"]);

                    // Usamos la clase auxiliar ActividadItem que ya teníamos definida
                    lstDisponibles.Items.Add(new ActividadItem(id, nombre, costo));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las actividades desde la base de datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento que se dispara cada vez que el usuario marca/desmarca una actividad (Tiempo Real)
        private void clbActividades_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            // Calculamos el monto acumulado en tiempo real según lo seleccionado
            this.BeginInvoke((MethodInvoker)delegate
            {
                _montoTotal = 0;
                /* Ejemplo de recorrido para sumar montos:
                foreach (var item in clbActividades.CheckedItems)
                {
                    DataRowView row = (DataRowView)item;
                    _montoTotal += Convert.ToDecimal(row["costo"]);
                }
                */
                lblMontoTotal.Text = $"$ {_montoTotal:N2}";
            });
        }

        private void btnConfirmarPago_Click(object sender, EventArgs e)
        {
            if (_montoTotal <= 0 && !_esSocio)
            {
                MessageBox.Show("Debe seleccionar al menos una actividad para procesar el pago.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Invocar Stored Procedure de Pago / Registrar comprobante
            RegistrarPago();
        }

        private void RegistrarPago()
        {
            // Lógica para registrar en la tabla pagos / actualizar vigencia del cliente
            MessageBox.Show("¡Pago registrado con éxito!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Regresamos al menú principal usando FormBase
            VolverAlMenu();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            VolverAlMenu(); // Directo a PantallaOpciones
        }
    }
}