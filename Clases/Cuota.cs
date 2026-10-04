using System;

namespace TrabajoIntegrador.Clases
{
    public class Cuota : Pago
    {
        private string forma_pago;
        private int cantidad_cuotas;
        private int periodo_anio;
        private int periodo_mes;
        private DateTime fecha_vencimiento;

        public Cuota(DateTime fecha_pago, string concepto, decimal monto, string forma_pago, int cantidad_cuotas, int periodo_anio, int periodo_mes, DateTime fecha_vencimiento)
            : base(fecha_pago, concepto, monto)
        {
            this.forma_pago = forma_pago;
            this.cantidad_cuotas = cantidad_cuotas;
            this.periodo_anio = periodo_anio;
            this.periodo_mes = periodo_mes;
            this.fecha_vencimiento = fecha_vencimiento;
        }

        public string FormaPago
        {
            get { return forma_pago; }
            set { forma_pago = value; }
        }

        public int CantidadCuotas
        {
            get { return cantidad_cuotas; }
            set { cantidad_cuotas = value; }
        }

        public int PeriodoAnio
        {
            get { return periodo_anio; }
            set { periodo_anio = value; }
        }

        public int PeriodoMes
        {
            get { return periodo_mes; }
            set { periodo_mes = value; }
        }

        public DateTime FechaVencimiento
        {
            get { return fecha_vencimiento; }
            set { fecha_vencimiento = value; }
        }

        public override string ToString()
        {
            return base.ToString() + $" (vence: {fecha_vencimiento:dd/MM/yyyy})";
        }
    }
}
