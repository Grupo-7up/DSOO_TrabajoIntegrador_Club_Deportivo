using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using TrabajoIntegrador.Clases;

namespace TrabajoIntegrador
{
    public partial class GestionPago : FormBase
    {
        // Datos recibidos del Paso 1
        private Cliente _clienteActual;

        // Monto total acumulado
        private decimal montoPorMes = 5000.00M; // Monto fijo por mes para socios
        private decimal _montoTotal = 0;

        // Constructor que recibe la información del cliente desde BuscarClienteParaPago
        public GestionPago(Cliente cliente)
        {
            InitializeComponent();

            _clienteActual = cliente;


            // Configuramos la pantalla apenas arranca el formulario
            ConfigurarPantallaSegunTipoCliente();
        }

        private void ConfigurarPantallaSegunTipoCliente()
        {
            // Aplicamos formato de título para corregir mayúsculas/minúsculas de la BBDD
            TextInfo textInfo = System.Globalization.CultureInfo.CurrentCulture.TextInfo;
            string nombreFormateado = textInfo.ToTitleCase(_clienteActual.Nombre.ToLower());
            string apellidoFormateado = textInfo.ToTitleCase(_clienteActual.Apellido.ToLower());

            if (lblInfoCliente != null)
            {
                lblInfoCliente.Text = $"Cliente: {nombreFormateado} {apellidoFormateado}  |  {_clienteActual.TipoDocumento}: {_clienteActual.Documento}  |  Condición: {(_clienteActual.EsSocio ? "SOCIO" : "NO SOCIO")}";
            }

            if (_clienteActual.EsSocio)
            {
                // SOCIO: El panel central visible para mostrar la deuda
                if (lblMedio != null) lblMedio.Text = "A pagar" ;

                // Ocultamos los controles de no socios dentro del panel
                if (lstDisponibles != null) lstDisponibles.Visible = false;
                if (lstSeleccionadas != null) lstSeleccionadas.Visible = false;
                if (btnPasarIzquierda != null) btnPasarIzquierda.Visible = false;
                if (btnPasarDerecha != null) btnPasarDerecha.Visible = false;
                if (lblTituloDisp != null) lblTituloDisp.Visible = false;
                if (lblTituloSelec != null) lblTituloSelec.Visible = false;

                // Mostramos y cargamos el listado de meses adeudados
                if (lstMesesAdeudados != null)
                {
                    lstMesesAdeudados.Visible = true;
                    lstMesesAdeudados.Items.Clear();

                    List<string> mesesDeuda = ConexionBD.ObtenerPeriodosAdeudadosSocio(_clienteActual.Id);
                    int cantidadMeses = Math.Max(1, mesesDeuda.Count);
                    foreach (var mes in mesesDeuda)
                    {
                        lstMesesAdeudados.Items.Add($"• Cuota Social - Período: {mes} ($ {montoPorMes:N2})");
                    }

                    // Calculamos el monto total multiplicando por la cantidad de meses
                    _montoTotal = montoPorMes * cantidadMeses;
                }

                if (lblTotalTexto != null)
                    lblTotalTexto.Text = "Total a Pagar (Cuotas Social Acumulada)";

                if (lblMontoValor != null)
                    lblMontoValor.Text = $"$ {_montoTotal:N2}";

                // Mantenemos una altura de ventana cómoda que deje ver el panel central con los meses
                this.Height = 480;
            }
            else
            {
                // NO SOCIO: Mostramos los controles tradicionales de actividades
                if (lstMesesAdeudados != null) lstMesesAdeudados.Visible = false;
                if (lblMedio != null) lblMedio.Text = "Actividades";

                if (lstDisponibles != null) lstDisponibles.Visible = true;
                if (lstSeleccionadas != null) lstSeleccionadas.Visible = true;

                if (lblTotalTexto != null) lblTotalTexto.Text = "Pase Diario (No Socio)";
                _montoTotal = 0;
                if (lblMontoValor != null) lblMontoValor.Text = "$ 0.00";

                this.Height = 520;
                CargarActividadesDisponibles();
            }

            RecalcularMonto();
        }

        // Clase auxiliar para manejar los ítems de las actividades con su ID y costo
        public class ActividadItem
        {
            public int Id { get; set; }
            public string Nombre { get; set; }
            public decimal Costo { get; set; }

            public ActividadItem(int id, string nombre, decimal costo)
            {
                Id = id;
                Nombre = nombre;
                Costo = costo;
            }

            public override string ToString()
            {
                return $"{Nombre} ($ {Costo:N2})";
            }
        }

        private void CargarActividadesDisponibles()
        {
            try
            {
                DataTable dt = ConexionBD.ObtenerActividades();

                lstDisponibles.Items.Clear();

                foreach (DataRow row in dt.Rows)
                {
                    int id = Convert.ToInt32(row["id_actividad"]);
                    string nombre = row["nombre"].ToString();
                    decimal costo = Convert.ToDecimal(row["valor_actividad"]);

                    lstDisponibles.Items.Add(new ActividadItem(id, nombre, costo));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las actividades desde la base de datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento del botón para pasar actividad de Disponible a Seleccionada (➡)
        private void btnPasarDerecha_Click(object sender, EventArgs e)
        {
            if (lstDisponibles.SelectedItem != null)
            {
                var itemSeleccionado = lstDisponibles.SelectedItem;
                lstSeleccionadas.Items.Add(itemSeleccionado);
                lstDisponibles.Items.Remove(itemSeleccionado);
                RecalcularMonto();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una actividad de la lista de disponibles.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Evento del botón para quitar actividad de Seleccionada y devolverla a Disponibles (⬅)
        private void btnPasarIzquierda_Click(object sender, EventArgs e)
        {
            if (lstSeleccionadas.SelectedItem != null)
            {
                var itemSeleccionado = lstSeleccionadas.SelectedItem;
                lstDisponibles.Items.Add(itemSeleccionado);
                lstSeleccionadas.Items.Remove(itemSeleccionado);
                RecalcularMonto();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una actividad de la lista de seleccionadas para quitar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Método auxiliar para sumar los costos o calcular cuotas
        private void RecalcularMonto()
        {
            decimal subtotal = 0;

            if (_clienteActual.EsSocio)
            {
                // Para socios, recalculamos multiplicando por la cantidad de meses adeudados reales
                List<string> mesesDeuda = ConexionBD.ObtenerPeriodosAdeudadosSocio(_clienteActual.Id);
                int cantidadMeses = Math.Max(1, mesesDeuda.Count);
                subtotal = 5000.00M * cantidadMeses;
            }
            else
            {
                foreach (var item in lstSeleccionadas.Items)
                {
                    if (item is ActividadItem act)
                    {
                        subtotal += act.Costo;
                    }
                }
            }

            _montoTotal = subtotal;

            if (lblMontoValor != null)
            {
                lblMontoValor.Text = $"$ {_montoTotal:N2}";
            }

            // Evaluamos si debemos mostrar el detalle de cuotas en tarjeta de crédito
            string medioPago = cmbMedioPago?.SelectedItem?.ToString();
            bool esTarjetaConCuotas = (medioPago == "Tarjeta de Crédito" && (rb3Cuotas.Checked || rb6Cuotas.Checked));

            if (esTarjetaConCuotas && lblCuotasDetalle != null)
            {
                int cantidadCuotas = rb3Cuotas.Checked ? 3 : 6;
                decimal valorCuota = _montoTotal / cantidadCuotas;

                lblCuotasDetalle.Text = $"(Equivalente a {cantidadCuotas} cuotas sin interés de $ {valorCuota:N2})";
                lblCuotasDetalle.Visible = true;
            }
            else if (lblCuotasDetalle != null)
            {
                lblCuotasDetalle.Visible = false;
            }
        }

        private void btnConfirmarPago_Click(object sender, EventArgs e)
        {
            if (_montoTotal <= 0 && !_clienteActual.EsSocio)
            {
                MessageBox.Show("Debe seleccionar al menos una actividad para procesar el pago.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbMedioPago.SelectedItem == null || string.IsNullOrWhiteSpace(cmbMedioPago.SelectedItem.ToString()))
            {
                MessageBox.Show("Debe seleccionar un medio de pago válido.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbMedioPago.Focus();
                return;
            }

            RegistrarPago();
        }

        private void RegistrarPago()
        {
            try
            {
                string formaPago = cmbMedioPago.SelectedItem.ToString();
                int cantidadCuotas = 1;

                if (formaPago == "Tarjeta de Crédito")
                {
                    if (rb3Cuotas.Checked) cantidadCuotas = 3;
                    else if (rb6Cuotas.Checked) cantidadCuotas = 6;
                }

                // Buscamos o instanciamos el cliente en la memoria del club para que ejecute el negocio
                if (_clienteActual.EsSocio)
                {
                    List<string> mesesDeuda = ConexionBD.ObtenerPeriodosAdeudadosSocio(_clienteActual.Id);
                    int cantidadMeses = Math.Max(1, mesesDeuda.Count);

                    // El club procesa el cobro y la persistencia pasándole el objeto cliente
                    Program.MiClub.cobrar_cuota_mensual(_clienteActual, _montoTotal, DateTime.Now, formaPago, cantidadCuotas, cantidadMeses);
                }
                else
                {
                    List<int> idsActividades = new List<int>();
                    foreach (var item in lstSeleccionadas.Items)
                    {
                        if (item is ActividadItem act)
                        {
                            idsActividades.Add(act.Id);
                        }
                    }

                    // El club procesa el pase diario pasándole el objeto cliente
                    Program.MiClub.cobrar_cuota_diaria(_clienteActual, _montoTotal, DateTime.Now, formaPago, cantidadCuotas, idsActividades);
                }

                MessageBox.Show("¡Pago registrado y procesado por el club con éxito!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                VolverAlMenu();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar el pago: " + ex.Message, "Error crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            VolverAlMenu();
        }

        private void cmbMedioPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMedioPago.SelectedItem?.ToString() == "Tarjeta de Crédito")
            {
                if (panelCuotas != null) panelCuotas.Visible = true;
            }
            else
            {
                if (panelCuotas != null) panelCuotas.Visible = false;

                if (rb1Pago != null)
                {
                    rb1Pago.Checked = true;
                }
            }
            RecalcularMonto();
        }

        private void rbCuotas_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                RecalcularMonto();
            }
        }
    }
}