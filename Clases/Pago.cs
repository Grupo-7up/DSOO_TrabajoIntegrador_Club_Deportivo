using System;

namespace TrabajoIntegrador.Clases
{
    public class Pago
    {
        private DateTime fecha_pago;
        private string concepto;
        private decimal monto;

        public Pago(DateTime fecha_pago, string concepto, decimal monto)
        {
            this.fecha_pago = fecha_pago;
            this.concepto = concepto;
            this.monto = monto;
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

        public override string ToString()
        {
            return $"{fecha_pago:dd/MM/yyyy} - {concepto}: {monto:C}";
        }
    }
}
