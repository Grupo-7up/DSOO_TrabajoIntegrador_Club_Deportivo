using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace TrabajoIntegrador
{
    public class ConexionBD
    {
        private static readonly string Server = "localhost";
        private static readonly string Database = "club_deportivo_grupo7";
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

        public static bool ExisteCliente(string tipoDoc, string documento)
        {
            using (var conexion = ObtenerConexion())
            {
                conexion.Open();
                using (var cmd = new MySqlCommand("sp_existe_cliente", conexion))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    // Parámetros de entrada
                    cmd.Parameters.AddWithValue("@p_tipo_documento", tipoDoc);
                    cmd.Parameters.AddWithValue("@p_documento", documento);

                    // Parámetro de salida (el COUNT que devuelve el procedure)
                    var paramExiste = new MySqlParameter("@p_existe", MySqlDbType.Int32);
                    paramExiste.Direction = System.Data.ParameterDirection.Output;
                    cmd.Parameters.Add(paramExiste);

                    cmd.ExecuteNonQuery();

                    // Convertimos el resultado a entero y evaluamos si es mayor a 0
                    int cantidad = Convert.ToInt32(paramExiste.Value);
                    return cantidad > 0;
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
    DateTime fechaNacimiento,
    bool esSocio = false,
    bool aptoFisico = false)
        {
            using (var conexion = ObtenerConexion())
            {
                conexion.Open();
                using (var cmd = new MySqlCommand("sp_registrar_cliente", conexion))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@p_tipo_documento", tipoDoc);
                    cmd.Parameters.AddWithValue("@p_documento", documento);
                    cmd.Parameters.AddWithValue("@p_nombre", nombre);
                    cmd.Parameters.AddWithValue("@p_apellido", apellido);

                    // Manejo de nulos para campos opcionales
                    cmd.Parameters.AddWithValue("@p_email", string.IsNullOrWhiteSpace(email) ? (object)DBNull.Value : email);
                    cmd.Parameters.AddWithValue("@p_telefono", string.IsNullOrWhiteSpace(telefono) ? (object)DBNull.Value : telefono);
                    cmd.Parameters.AddWithValue("@p_fecha_nacimiento", fechaNacimiento.ToString("yyyy-MM-dd"));

                    cmd.Parameters.AddWithValue("@p_es_socio", esSocio);
                    cmd.Parameters.AddWithValue("@p_apto_fisico", aptoFisico);

                    cmd.ExecuteNonQuery();
                    return true; 
                }
            }
        }
    }
}