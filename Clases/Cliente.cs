using System;
using System.Collections.Generic;
using System.Linq;

namespace TrabajoIntegrador.Clases
{
    public class Cliente : Persona
    {
        private bool es_socio;
        private string nro_carnet;
        private DateTime fecha_inscripcion;
        private DateTime validez;
        private string estado;
        private bool apto_fisico;
        private List<Actividad> actividades;
        private List<Pago> pagos;

        public Cliente(string nombre, string apellido, string tipo_documento, string documento, string email, int telefono, DateTime fecha_nacimiento, bool es_socio, bool apto_fisico)
            : base(nombre, apellido, tipo_documento, documento, email, telefono, fecha_nacimiento)
        {
            this.es_socio = es_socio;
            this.nro_carnet = null; // se asigna cuando club.emitir_carnet() entrega el carnet
            this.fecha_inscripcion = DateTime.Now;
            this.validez = fecha_inscripcion.Date.AddDays(-1); // todavía no pagó ninguna cuota: queda "vencido" hasta el primer cobro
            this.estado = "Activo";
            this.apto_fisico = apto_fisico;
            this.actividades = new List<Actividad>();
            this.pagos = new List<Pago>();
        }

        public bool EsSocio
        {
            get { return es_socio; }
            set { es_socio = value; }
        }

        public string NroCarnet
        {
            get { return nro_carnet; }
            set { nro_carnet = value; }
        }

        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        public DateTime Validez
        {
            get { return validez; }
            set { validez = value; }
        }

        public DateTime FechaInscripcion
        {
            get { return fecha_inscripcion; }
            set { fecha_inscripcion = value; }
        }

        public bool AptoFisico
        {
            get { return apto_fisico; }
            set { apto_fisico = value; }
        }

        public List<Actividad> Actividades
        {
            get { return actividades; }
            set { actividades = value; }
        }

        public List<Pago> Pagos
        {
            get { return pagos; }
            set { pagos = value; }
        }

        // Un socio con la cuota vencida no puede realizar actividades (el no socio paga en el momento, no depende de Validez).
        public bool esta_al_dia()
        {
            return !es_socio || DateTime.Now.Date <= validez.Date;
        }

        public void inscribir_a_actividad(Actividad a)
        {
            if (!esta_al_dia())
            {
                //no es por consola pero lo puse para que no quede vacío
                Console.WriteLine("El socio tiene la cuota vencida y no puede realizar actividades hasta regularizar el pago.");
            }
            //validar si ya tiene esa actividad agregada, si no está en la lista de actividades del club, si tiene cupo disponible, etc.
            actividades.Add(a);
        }

        public void baja_a_actividad(Actividad a)
        {
            //validar si tiene esa actividad agregada, si no está en la lista de actividades del club, etc.
            actividades.Remove(a);
        }

        // No está en el UML: para el no socio, lo que tiene que pagar hoy surge de sumar el valor de cada actividad realizada.
        public decimal calcular_monto_diario()
        {
            // a nivel base de datos deberíamos tener un campo de fecha para guardar el día de la actividad y validar que sean las actividades del día
            return actividades.Sum(a => a.ValorActividad);
        }

        public override string ToString()
        {
            return base.ToString() + $", Tipo membresía: {(es_socio ? "Socio" : "No socio")}, Estado: {estado}";
        }
    }
}
