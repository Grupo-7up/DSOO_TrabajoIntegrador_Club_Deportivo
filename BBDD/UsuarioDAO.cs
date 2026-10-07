using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TrabajoIntegrador
{
    public class UsuarioDAO
    {
        public bool ValidarUsuario(string nombreUsuario, string contrasenia)
        {
            bool existe = false;
            string query = "SELECT COUNT(*) FROM Usuarios WHERE usuario = @usuario AND clave = @clave";

            // 1. Instanciamos y abrimos la conexión
            using (MySqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                conexion.Open();

                // 2. Instanciamos el objeto 'cmd' pasándole la consulta y la conexión activa
                using (MySqlCommand cmd = new MySqlCommand(query, conexion))
                {
                    // 3. Pasamos los parámetros
                    cmd.Parameters.AddWithValue("@usuario", nombreUsuario);
                    cmd.Parameters.AddWithValue("@clave", contrasenia);

                    // 4. Ejecutamos ExecuteScalar de forma segura
                    object resultado = cmd.ExecuteScalar();

                    if (resultado != null && resultado != DBNull.Value)
                    {
                        int count = Convert.ToInt32(resultado);
                        existe = count > 0;
                    }
                }
            }

            return existe;
        }
    }
}
