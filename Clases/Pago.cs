using System;

namespace TrabajoIntegrador.Clases
{
    public class Pago
    {
        private DateTime fecha_pago;
        private string concepto;
        private decimal monto;
        private DateTime fecha_vencimiento;

        public Pago(DateTime fecha_pago, string concepto, decimal monto, DateTime fecha_vencimiento)
        {
            this.fecha_pago = fecha_pago;
            this.concepto = concepto;
            this.monto = monto;
            this.fecha_vencimiento = fecha_vencimiento;
        }

        public DateTime FechaPago
        {
            get { return fecha_pago; }
            set { fecha_pago = value; }
        }

        public string Concepto
        {
            get { return concepto; }
            set { concepto = value; }
        }

        public decimal Monto
        {
            get { return monto; }
            set { monto = value; }
        }

        public string EmitirComprobante(string nombreCliente = "Socio / Visitante")
        {
            return
                "=======================================\n" +
                "      CLUB DEPORTIVO - COMPROBANTE     \n" +
                "=======================================\n" +
                $" Fecha de emisión: {fecha_pago:dd/MM/yyyy HH:mm}\n" +
                $" Titular: {nombreCliente}\n" +
                $" Concepto: {concepto}\n" +
                $" Prox vencimiento: {fecha_vencimiento:dd/MM/yyyy}\n" +
                $" Monto Abonado: ${monto:N2}\n" +
                "---------------------------------------\n" +
                "     ¡Gracias por mantenerse al día!   \n" +
                "=======================================";
        }

        public override string ToString()
        {
            return $"{fecha_pago:dd/MM/yyyy} - {concepto}: ${monto:N2}";
        }
    }
}
