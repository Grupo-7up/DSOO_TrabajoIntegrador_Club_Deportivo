using MySql.Data.MySqlClient;
using System;
using System.IO;


namespace TrabajoIntegrador
{
    public static class DatabaseInitializer
    {
        public static void InicializarBaseDeDatos()
        {
            string rutaRelativa = Path.Combine("BBDD", "script_base_datos.sql");
            string rutaScript = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, rutaRelativa);

            if (!File.Exists(rutaScript))
            {
                DirectoryInfo dirBase = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
                if (dirBase.Parent != null && dirBase.Parent.Parent != null)
                {
                    rutaScript = Path.Combine(dirBase.Parent.Parent.FullName, rutaRelativa);
                }
            }

            if (!File.Exists(rutaScript))
            {
                throw new FileNotFoundException($"No se encontró el archivo SQL en: {rutaScript}");
            }

            string contenidoSql = File.ReadAllText(rutaScript);

            // Conectamos al servidor SIN especificar la base de datos
            using (MySqlConnection conexion = ConexionBD.ObtenerConexionServidor())
            {
                conexion.Open();
                MySqlScript script = new MySqlScript(conexion, contenidoSql);
                script.Execute();
            }
        }
    }
}