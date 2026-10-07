using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace TrabajoIntegrador
{
    public class ConexionBD
    {
        private static readonly string Server = "localhost";
        private static readonly string Database = "club_deportivo";
        private static readonly string User = "root";
        private static readonly string Password = "root";
        private static readonly string Port = "3306";


        // Conexión general al servidor (sin Database) para inicialización
        public static MySqlConnection ObtenerConexionServidor()
        {
            string cadenaConexion = $"Server={Server};Port={Port};Uid={User};Pwd={Password};";
            return new MySqlConnection(cadenaConexion);
        }
        // Cadena de conexión ensamblada
        private static readonly string CadenaConexion = $"Server={Server};Port={Port};Database={Database};Uid={User};Pwd={Password};";

        /// <summary>
        /// Crea y devuelve una nueva instancia de MySqlConnection desglosada.
        /// </summary>
        public static MySqlConnection ObtenerConexion()
        {
            string cadenaConexion = $"Server={Server};Port={Port};Database={Database};Uid={User};Pwd={Password};";
            return new MySqlConnection(cadenaConexion);
        }
        

        /// <summary>
        /// Método auxiliar para probar la conectividad desde C#.
        /// </summary>
        public static bool ProbarConexion()
        {
            using (MySqlConnection conexion = ObtenerConexion())
            {
                try
                {
                    conexion.Open();
                    return true;
                }
                catch (Exception)
                {
                    // Puedes registrar o imprimir ex.Message si falla
                    return false;
                }
            }
        }

        // Método genérico para validar credenciales (ejemplo)
        public static bool ValidarLogin(string usuario, string clave)
        {
            using (var conexion = ObtenerConexion())
            {
                conexion.Open();
                using (var cmd = new MySqlCommand("sp_ValidarLogin", conexion))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("p_usuario", usuario);
                    cmd.Parameters.AddWithValue("p_clave", clave);

                    using (var reader = cmd.ExecuteReader())
                    {
                        return reader.HasRows;
                    }
                }
            }
        }

        public static bool ExisteCliente(string documento)
        {
            string query = "SELECT COUNT(*) FROM clientes WHERE documento = @doc;";

            using (var conexion = ObtenerConexion())
            {
                conexion.Open();
                using (var cmd = new MySqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@doc", documento);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
        }

        public static bool RegistrarCliente(
            string tipoDoc,
            string documento,
            string nombre,
            string apellido,
            string email,
            string telefono,
            bool esSocio = false,
            bool aptoFisico = false)
        {
            string query = @"INSERT INTO clientes 
                (tipo_documento, documento, nombre, apellido, email, telefono, es_socio, validez, apto_fisico) 
                VALUES 
                (@tipoDoc, @doc, @nombre, @apellido, @email, @telefono, @esSocio, @validez, @aptoFisico);";

            using (var conexion = ObtenerConexion())
            {
                conexion.Open();
                using (var cmd = new MySqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@tipoDoc", tipoDoc);
                    cmd.Parameters.AddWithValue("@doc", documento);
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@apellido", apellido);

                    // Manejo de nulos para campos opcionales
                    cmd.Parameters.AddWithValue("@email", string.IsNullOrWhiteSpace(email) ? (object)DBNull.Value : email);
                    cmd.Parameters.AddWithValue("@telefono", string.IsNullOrWhiteSpace(telefono) ? (object)DBNull.Value : telefono);

                    cmd.Parameters.AddWithValue("@esSocio", esSocio);
                    cmd.Parameters.AddWithValue("@validez", DateTime.Now.AddDays(30).ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@aptoFisico", aptoFisico);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}