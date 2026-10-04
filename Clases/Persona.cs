using System;

namespace TrabajoIntegrador.Clases
{
    public class Persona
    {
        private string nombre;
        private string apellido;
        private string tipo_documento;
        private string documento;
        private string email;
        private int telefono;
        private DateTime fecha_nacimiento;

        public Persona(string nombre, string apellido, string tipo_documento, string documento, string email, int telefono, DateTime fecha_nacimiento)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.tipo_documento = tipo_documento;
            this.documento = documento;
            this.email = email;
            this.telefono = telefono;
            this.fecha_nacimiento = fecha_nacimiento;
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }

        public string TipoDocumento
        {
            get { return tipo_documento; }
            set { tipo_documento = value; }
        }

        public string Documento
        {
            get { return documento; }
            set { documento = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public int Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }

        public DateTime FechaNacimiento
        {
            get { return fecha_nacimiento; }
            set { fecha_nacimiento = value; }
        }

        public override string ToString()
        {
            return $"Nombre: {nombre}, Apellido: {apellido}, Documento: {documento}";
        }
    }
}
