using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace TrabajoIntegrador
{
    public class ConexionBD
    {
        // Datos de conexión: ahora configurables en tiempo de ejecución (se cargan por teclado
        // desde ConfiguracionConexion antes de iniciar sesión), con estos valores como default.
        public static string Server { get; set; } = "localhost";
        public static string Database { get; set; } = "club_deportivo_grupo7";
        public static string User { get; set; } = "root";
        public static string Password { get; set; } = "root";
        public static string Port { get; set; } = "3306";


        // Conexión general al servidor (sin Database) para inicialización
        public static MySqlConnection ObtenerConexionServidor()
        {
            string cadenaConexion = $"Server={Server};Port={Port};Uid={User};Pwd={Password};";
            return new MySqlConnection(cadenaConexion);
        }

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
            out int idCliente,  
            bool esSocio = false,
            bool aptoFisico = false)
        {
            idCliente = 0;
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

                    cmd.Parameters.AddWithValue("@p_email", string.IsNullOrWhiteSpace(email) ? (object)DBNull.Value : email);
                    cmd.Parameters.AddWithValue("@p_telefono", string.IsNullOrWhiteSpace(telefono) ? (object)DBNull.Value : telefono);
                    cmd.Parameters.AddWithValue("@p_fecha_nacimiento", fechaNacimiento.ToString("yyyy-MM-dd"));

                    cmd.Parameters.AddWithValue("@p_es_socio", esSocio);
                    cmd.Parameters.AddWithValue("@p_apto_fisico", aptoFisico);

                    // Parámetro de salida OUT
                    var paramId = new MySqlParameter("@p_id_cliente", MySqlDbType.Int32);
                    paramId.Direction = System.Data.ParameterDirection.Output;
                    cmd.Parameters.Add(paramId);

                    cmd.ExecuteNonQuery();

                    // Recuperación segura del ID para evitar el error de DBNull
                    if (paramId.Value != null && paramId.Value != DBNull.Value)
                    {
                        idCliente = Convert.ToInt32(paramId.Value);
                    }
                    else
                    {
                        idCliente = 0; // O podés buscar el ID manualmente si fuera necesario
                    }

                    idCliente = Convert.ToInt32(paramId.Value);
                    return true;
                }
            }
        }

        /// <summary>
        /// Guarda el número de carnet emitido para un cliente.
        /// </summary>
        public static bool ActualizarCarnet(int idCliente, string nroCarnet)
        {
            using (var conexion = ObtenerConexion())
            {
                conexion.Open();
                string query = "UPDATE clientes SET nro_carnet = @nroCarnet WHERE id_cliente = @idCliente";
                using (var cmd = new MySqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@nroCarnet", nroCarnet);
                    cmd.Parameters.AddWithValue("@idCliente", idCliente);
                    int filasAfectadas = cmd.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
            }
        }

        /// <summary>
        /// Obtiene los socios cuya cuota vence exactamente en la fecha indicada, consultando
        /// directamente la base (no depende de que la lista en memoria del Club esté cargada).
        /// </summary>
        public static DataTable ObtenerClientesVencidos(DateTime fecha)
        {
            using (var conexion = ObtenerConexion())
            {
                conexion.Open();
                string query = @"SELECT p.nombre, p.apellido, p.tipo_documento, p.documento, c.validez
                                 FROM clientes c
                                 JOIN personas p ON c.id_persona = p.id_persona
                                 WHERE c.es_socio = 1 AND c.validez = @fecha
                                 ORDER BY p.apellido ASC, p.nombre ASC";

                using (var cmd = new MySqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@fecha", fecha.Date);

                    using (var adapter = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        /// <summary>
        /// Obtiene todas las actividades disponibles para cargar en la interfaz de pagos.
        /// </summary>
        public static DataTable ObtenerActividades()
        {
            using (var conexion = ObtenerConexion())
            {
                conexion.Open();
                string query = "SELECT id_actividad, nombre, valor_actividad FROM actividades";
                using (var cmd = new MySqlCommand(query, conexion))
                {
                    using (var adapter = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        /// <summary>
        /// Obtiene los datos clave del cliente (ID y si es socio) para el flujo de pagos.
        /// </summary>
        /// <summary>
        /// Obtiene los datos clave del cliente (ID de cliente y si es socio) haciendo el JOIN correcto con personas.
        /// </summary>
        public static bool ObtenerDatosClienteParaPago(string tipoDoc, string documento, out int idCliente, out bool esSocio, out string nombre, out string apellido)
            {
                idCliente = 0;
                esSocio = false;
                nombre = string.Empty;
                apellido = string.Empty;

                using (var conexion = ObtenerConexion())
                {
                    conexion.Open();
                    // Hacemos el JOIN tal como lo tenés en tu stored procedure sp_existe_cliente
                    string query = @"SELECT c.id_cliente, c.es_socio, p.nombre, p.apellido
                                     FROM clientes c
                                     JOIN personas p ON c.id_persona = p.id_persona
                                     WHERE p.tipo_documento = @tipo AND p.documento = @doc";

                    using (var cmd = new MySqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@tipo", tipoDoc);
                        cmd.Parameters.AddWithValue("@doc", documento);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                idCliente = Convert.ToInt32(reader["id_cliente"]);
                                esSocio = Convert.ToBoolean(reader["es_socio"]);
                                nombre = reader["nombre"].ToString();
                                apellido = reader["apellido"].ToString();
                                return true;
                            }
                        }
                    }
                }
            return false;
        }


        // MÓDULO DE PAGOS - SOCIOS (Cuotas Mensuales)

        /// <summary>
        /// Obtiene los períodos pendientes de cobro de un socio, 
        /// incluyendo el mes corriente si la validez ya ha expirado y aún no fue abonado.
        /// </summary>
        public static List<string> ObtenerPeriodosAdeudadosSocio(int idCliente)
        {
            List<string> periodosPendientes = new List<string>();

            using (var conexion = ObtenerConexion())
            {
                conexion.Open();

                string queryValidez = "SELECT validez FROM clientes WHERE id_cliente = @idCliente";
                DateTime fechaValidez;
                using (var cmd = new MySqlCommand(queryValidez, conexion))
                {
                    cmd.Parameters.AddWithValue("@idCliente", idCliente);
                    object result = cmd.ExecuteScalar();

                    // Si la validez es NULL (socio nuevo), el mes corriente pasa a ser el primer período a abonar
                    if (result == null || result == DBNull.Value)
                    {
                        DateTime actual = DateTime.Now;
                        string mesActualStr = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(actual.Month);
                        periodosPendientes.Add($"{mesActualStr} {actual.Year}");
                        return periodosPendientes;
                    }

                    fechaValidez = Convert.ToDateTime(result);
                }

                DateTime fechaActual = DateTime.Now;

                // Si la fecha de validez aún cubre el momento actual, el socio está al día (lista vacía)
                if (fechaValidez >= fechaActual)
                {
                    return periodosPendientes;
                }

                // Si la validez expiró, empezamos a contar desde el primer día del mes en que venció 
                // hasta llegar e incluir el mes corriente (DateTime.Now)
                DateTime fechaIteracion = new DateTime(fechaValidez.Year, fechaValidez.Month, 1);
                DateTime mesActual = new DateTime(fechaActual.Year, fechaActual.Month, 1);

                while (fechaIteracion <= mesActual)
                {
                    string nombreMes = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(fechaIteracion.Month);
                    periodosPendientes.Add($"{nombreMes} {fechaIteracion.Year}");

                    fechaIteracion = fechaIteracion.AddMonths(1);
                }
            }

            return periodosPendientes;
        }

        /// <summary>
        /// Verifica si el socio ya tiene registrada una cuota paga para el mes y año actual.
        /// </summary>
        public static bool EstaCuotaMesActualPagada(int idCliente)
        {
            using (var conexion = ObtenerConexion())
            {
                conexion.Open();
                string query = @"SELECT COUNT(*) FROM pagos 
                                 WHERE id_cliente = @idCliente 
                                   AND tipo_pago = 'Cuota' 
                                   AND periodo_mes = MONTH(CURDATE()) 
                                   AND periodo_anio = YEAR(CURDATE())";

                using (var cmd = new MySqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@idCliente", idCliente);
                    long count = Convert.ToInt64(cmd.ExecuteScalar());
                    return count > 0; // Si es mayor a 0, significa que ya pagó este mes
                }
            }
        }

        /// <summary>
        /// Registra un nuevo comprobante de pago guardando el período correspondiente.
        /// </summary>
        public static bool RegistrarPagoBD(int idCliente, string concepto, decimal monto, string tipoPago, string formaPago, int cantidadCuotas)
        {
            using (var conexion = ObtenerConexion())
            {
                conexion.Open();

                // Si es una cuota de socio, asociamos el mes y año actual. Si es actividad diaria, puede ir NULL.
                object mes = (tipoPago == "Cuota") ? (object)DateTime.Now.Month : DBNull.Value;
                object anio = (tipoPago == "Cuota") ? (object)DateTime.Now.Year : DBNull.Value;

                string query = @"INSERT INTO pagos (id_cliente, concepto, monto, tipo_pago, forma_pago, cantidad_cuotas, periodo_mes, periodo_anio, fecha_pago, fecha_vencimiento) 
                                 VALUES (@idCliente, @concepto, @monto, @tipoPago, @formaPago, @cantidadCuotas, @mes, @anio, NOW(), DATE_ADD(NOW(), INTERVAL 30 DAY))";

                using (var cmd = new MySqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@idCliente", idCliente);
                    cmd.Parameters.AddWithValue("@concepto", concepto);
                    cmd.Parameters.AddWithValue("@monto", monto);
                    cmd.Parameters.AddWithValue("@tipoPago", tipoPago);
                    cmd.Parameters.AddWithValue("@formaPago", formaPago);
                    cmd.Parameters.AddWithValue("@cantidadCuotas", cantidadCuotas);
                    cmd.Parameters.AddWithValue("@mes", mes);
                    cmd.Parameters.AddWithValue("@anio", anio);

                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
        }

        /// <summary>
        /// Registra el pago de cuotas atrasadas o corrientes de un socio y actualiza su validez.
        /// </summary>
        public static bool RegistrarPagoMensual(int idCliente, decimal monto, string formaPago, int cantidadCuotas, int mesesDeuda)
        {
            using (var conexion = ObtenerConexion())
            {
                conexion.Open();
                using (var transaccion = conexion.BeginTransaction())
                {
                    try
                    {
                        // 1. Insertar comprobante en la tabla pagos
                        string queryPago = @"INSERT INTO pagos (id_cliente, concepto, monto, tipo_pago, forma_pago, cantidad_cuotas, periodo_mes, periodo_anio, fecha_pago, fecha_vencimiento) 
                                             VALUES (@idCliente, @concepto, @monto, 'Cuota', @formaPago, @cantidadCuotas, MONTH(CURDATE()), YEAR(CURDATE()), NOW(), DATE_ADD(NOW(), INTERVAL 30 DAY))";

                        using (var cmd = new MySqlCommand(queryPago, conexion, transaccion))
                        {
                            cmd.Parameters.AddWithValue("@idCliente", idCliente);
                            cmd.Parameters.AddWithValue("@concepto", $"Cuota Social ({mesesDeuda} período/s)");
                            cmd.Parameters.AddWithValue("@monto", monto);
                            cmd.Parameters.AddWithValue("@formaPago", formaPago);
                            cmd.Parameters.AddWithValue("@cantidadCuotas", cantidadCuotas);
                            cmd.ExecuteNonQuery();
                        }

                        // 2. Extender la validez del cliente con COALESCE para evitar errores si validez es NULL (socio nuevo)
                        string queryValidez = @"UPDATE clientes 
                                                SET validez = DATE_ADD(COALESCE(validez, CURDATE()), INTERVAL @meses MONTH), activo = 1
                                                WHERE id_cliente = @idCliente";

                        using (var cmd = new MySqlCommand(queryValidez, conexion, transaccion))
                        {
                            cmd.Parameters.AddWithValue("@meses", mesesDeuda);
                            cmd.Parameters.AddWithValue("@idCliente", idCliente);
                            cmd.ExecuteNonQuery();
                        }

                        transaccion.Commit();
                        return true;
                    }
                    catch (Exception)
                    {
                        transaccion.Rollback();
                        throw;
                    }
                }
            }
        }

        // MÓDULO DE PAGOS - NO SOCIOS (Pases Diarios)

        /// <summary>
        /// Registra el pase diario o actividades sueltas de un no socio.
        /// </summary>
        public static bool RegistrarPagoDiario(int idCliente, decimal monto, string formaPago, int cantidadCuotas, List<int> idsActividades)
        {
            using (var conexion = ObtenerConexion())
            {
                conexion.Open();
                using (var transaccion = conexion.BeginTransaction())
                {
                    try
                    {
                        // 1. Registrar el comprobante global de pago para el No Socio
                        string queryPago = @"INSERT INTO pagos (id_cliente, concepto, monto, tipo_pago, forma_pago, cantidad_cuotas, fecha_pago, fecha_vencimiento) 
                     VALUES (@idCliente, 'Pase Diario - Actividades', @monto, 'Pase', @formaPago, @cantidadCuotas, NOW(), NOW())";

                        using (var cmd = new MySqlCommand(queryPago, conexion, transaccion))
                        {
                            cmd.Parameters.AddWithValue("@idCliente", idCliente);
                            cmd.Parameters.AddWithValue("@monto", monto);
                            cmd.Parameters.AddWithValue("@formaPago", formaPago);
                            cmd.Parameters.AddWithValue("@cantidadCuotas", cantidadCuotas);
                            cmd.ExecuteNonQuery();
                        }

                        // 2. (Opcional pero recomendado) Asociar las actividades pagadas al cliente en la tabla intermedia
                        foreach (int idActividad in idsActividades)
                        {
                            string queryRelacion = @"INSERT IGNORE INTO cliente_actividad (id_cliente, id_actividad, fecha_inscripcion) 
                                                     VALUES (@idCliente, @idActividad, NOW())";

                            using (var cmdRel = new MySqlCommand(queryRelacion, conexion, transaccion))
                            {
                                cmdRel.Parameters.AddWithValue("@idCliente", idCliente);
                                cmdRel.Parameters.AddWithValue("@idActividad", idActividad);
                                cmdRel.ExecuteNonQuery();
                            }
                        }

                        transaccion.Commit();
                        return true;
                    }
                    catch (Exception)
                    {
                        transaccion.Rollback();
                        throw;
                    }
                }
            }
        }

        
    }
}