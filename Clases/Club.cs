using System;
using System.Collections.Generic;
using System.Linq;

namespace TrabajoIntegrador.Clases
{
    public class Club
    {
        private List<Cliente> socios;
        private List<Cliente> no_socios;
        private List<Actividad> actividades;

        public Club()
        {
            socios = new List<Cliente>();
            no_socios = new List<Cliente>();
            actividades = new List<Actividad>();
        }

        public List<Cliente> Socios
        {
            get { return socios; }
        }

        public List<Cliente> NoSocios
        {
            get { return no_socios; }
        }

        public List<Actividad> Actividades
        {
            get { return actividades; }
        }

        public bool registrar_cliente(Cliente cliente)
        {
            int idCliente;

            // 1. Guardar en Base de Datos usando las propiedades del objeto Cliente (y heredadas de Persona)
            bool registrado = ConexionBD.RegistrarCliente(
                cliente.TipoDocumento, 
                cliente.Documento,
                cliente.Nombre,
                cliente.Apellido,
                cliente.Email,
                cliente.Telefono,
                cliente.FechaNacimiento,
                out idCliente,
                cliente.EsSocio,
                cliente.AptoFisico
            );

            // 2. Si fue exitoso en la BBDD, se agrega a la lista interna en memoria
            if (registrado)
            {
                if (cliente.EsSocio)
                {
                    socios.Add(cliente);
                }
                else
                {
                    no_socios.Add(cliente);
                }
            }

            return registrado;
        }

        public void emitir_carnet(Cliente cliente)
        {
            // El carnet de socio solo aplica a los socios (los no socios no tienen carnet).
            if (!cliente.EsSocio)
            {
                return;
            }

            // Número autonumerable en base al Id del cliente en la base (ej: SOC-00042),
            // en vez de un código random tipo GUID.
            string carnet = "SOC-" + cliente.Id.ToString("D5");

            bool guardado = ConexionBD.ActualizarCarnet(cliente.Id, carnet);
            if (guardado)
            {
                cliente.NroCarnet = carnet;
            }
        }

        // pasa de socio a no_socio y viceversa
        public void cambiar_tipo_socio(Cliente cliente, bool es_socio, decimal monto = 0, string formaPago = "efectivo", int cantidadCuotas = 1)
        {
            if (cliente.EsSocio == es_socio)
            {
                return;
            }

            if (es_socio)
            {
                no_socios.Remove(cliente);
                socios.Add(cliente);
                cliente.EsSocio = true;

                cobrar_cuota_mensual(cliente, monto, DateTime.Now, formaPago, cantidadCuotas);
            }
            else
            {
                socios.Remove(cliente);
                no_socios.Add(cliente);
                cliente.EsSocio = false;
                cliente.Validez = DateTime.Now;
            }
        }

        // el vencimiento de cuota solo aplica a los socios (los no_socios pagan en el momento).
        public List<Cliente> listar_vencimientos()
        {
            return socios.Where(c => c.Validez.Date <= DateTime.Now.Date).ToList();
        }

        public void alertar_vencidos()
        {
            foreach (var cliente in listar_vencimientos())
            {
                Console.WriteLine($"Cliente {cliente.Nombre} {cliente.Apellido} (DNI: {cliente.Documento}) tiene la cuota vencida desde {cliente.Validez.ToShortDateString()}.");
            }
        }

        // aca monto viene del calcular_monto_diario del cliente
        public Pago cobrar_cuota_diaria(Cliente c, decimal monto, DateTime fecha, string forma_pago, int cantidad_cuotas, List<int> idsActividades)
        {
            // 1. Delegamos la persistencia transaccional a la capa de datos
            bool registradoBD = ConexionBD.RegistrarPagoDiario(c.Id, monto, forma_pago, cantidad_cuotas, idsActividades);

            if (!registradoBD)
            {
                throw new Exception("No se pudo registrar el pase diario en la base de datos.");
            }

            // 2. Actualizamos la lógica en memoria del modelo de negocio
            var pago = new Pago(fecha, "Entrada diaria", monto, fecha);
            c.Pagos.Add(pago);
            return pago;
        }

        // forma_pago: "efectivo" o "tarjeta". cantidad_cuotas solo aplica si es con tarjeta (promociones en 3 y 6 cuotas).
        // El nuevo vencimiento arranca el día siguiente al vencimiento anterior, no desde la fecha de pago.
        public Cuota cobrar_cuota_mensual(Cliente c, decimal monto, DateTime fecha, string forma_pago, int cantidad_cuotas, int mesesDeuda = 1)
        {
            if (!forma_pago.Equals("tarjeta", StringComparison.OrdinalIgnoreCase))
            {
                cantidad_cuotas = 1;
            }

            // 1. Delegamos la persistencia transaccional a la capa de datos
            bool registradoBD = ConexionBD.RegistrarPagoMensual(c.Id, monto, forma_pago, cantidad_cuotas, mesesDeuda);

            if (!registradoBD)
            {
                throw new Exception("No se pudo registrar el pago del socio en la base de datos.");
            }

            // 2. Actualizamos la lógica en memoria del modelo de negocio
            DateTime inicio_periodo = c.Validez == default(DateTime) ? DateTime.Now : c.Validez.AddDays(1);
            DateTime nuevo_vencimiento = inicio_periodo.AddMonths(mesesDeuda);

            var cuota = new Cuota(fecha, "Cuota mensual", monto, forma_pago, cantidad_cuotas, fecha.Year, fecha.Month, nuevo_vencimiento);
            c.Pagos.Add(cuota);
            c.Validez = nuevo_vencimiento;
            c.activo = true; // Si estaba inactivo por deuda, se reactiva

            return cuota;
        }
    }
}
