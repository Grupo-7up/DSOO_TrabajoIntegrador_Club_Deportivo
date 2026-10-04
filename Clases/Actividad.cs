using System;

namespace TrabajoIntegrador.Clases
{
    public class Actividad
    {
        private string nombre;
        private int cupo;
        private TimeSpan horario;
        private decimal valor_actividad;

        public Actividad(string nombre, int cupo, TimeSpan horario, decimal valor_actividad)
        {
            this.nombre = nombre;
            this.cupo = cupo;
            this.horario = horario;
            this.valor_actividad = valor_actividad;
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public int Cupo
        {
            get { return cupo; }
            set { cupo = value; }
        }

        public TimeSpan Horario
        {
            get { return horario; }
            set { horario = value; }
        }

        public decimal ValorActividad
        {
            get { return valor_actividad; }
            set { valor_actividad = value; }
        }

        public override string ToString()
        {
            return $"{nombre} (cupo: {cupo}, horario: {horario:hh\\:mm}, valor: {valor_actividad:C})";
        }
    }
}
