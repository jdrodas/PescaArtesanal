using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data.SQLite;
using System.Data;
using PescaArtesanal_WindowsForms.Modelos;
using System.Data.SqlClient;

namespace PescaArtesanal_WindowsForms
{
    public class AccesoDatos
    {
        static string? cadenaConexion => ObtenerCadenaConexion();
        
        public static string? ObtenerCadenaConexion()
        {
            //Parametrizamos el acceso al archivo de configuración appsettings.json
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            IConfiguration miConfiguracion = builder.Build();

            return miConfiguracion["ConnectionString:Sqlite"];
        }

        #region CRUD_Departamentos
        
        public static int ObtenerCodigoDepartamento(string nombreDepartamento)
        {
            int codigoDepartamento = 0;

            using (IDbConnection cxnDB = new SQLiteConnection(cadenaConexion))
            {
                DynamicParameters parametrosSentencia = new DynamicParameters();
                parametrosSentencia.Add("@nombre_departamento", nombreDepartamento,
                    DbType.String, ParameterDirection.Input);

                codigoDepartamento = cxnDB.Query<int>("SELECT DISTINCT codigo FROM departamentos " +
                "WHERE nombre = @nombre_departamento", parametrosSentencia).FirstOrDefault();
            }
            
            return codigoDepartamento;
        }

        public static List<Departamento> ObtenerListaDepartamentos()
        {
            using (IDbConnection cxnDB = new SQLiteConnection(cadenaConexion))
            {
                string sentenciaSQL = "SELECT DISTINCT codigo, nombre FROM departamentos ORDER BY nombre";
                var resultadoDepartamentos = cxnDB.Query<Departamento>(sentenciaSQL, new DynamicParameters());

                return resultadoDepartamentos.AsList();
            }
        }

        public static List<string> ObtenerListaNombresDepartamentos()
        {
            using (IDbConnection cxnDB = new SQLiteConnection(cadenaConexion))
            {
                string sentenciaSQL = "SELECT DISTINCT nombre FROM departamentos ORDER BY nombre";
                var resultadoDepartamentos = cxnDB.Query<string>(sentenciaSQL, new DynamicParameters());

                return resultadoDepartamentos.AsList();
            }
        }
        
        public static Departamento ObtenerDepartamento(int codigoDepartamento)
        {
            Departamento departamentoResultado = new Departamento();

            using (IDbConnection cxnDB = new SQLiteConnection(cadenaConexion))
            {
                DynamicParameters parametrosSentencia = new DynamicParameters();
                parametrosSentencia.Add("@codigo_departamento", codigoDepartamento,
                    DbType.Int32, ParameterDirection.Input);

                string sentenciaSQL = "SELECT codigo, nombre FROM departamentos " +
                    "WHERE codigo = @codigo_departamento";

                var salida = cxnDB.Query<Departamento>(sentenciaSQL, parametrosSentencia);

                if (salida.ToArray().Length > 0)
                    departamentoResultado = salida.First();
            }

            return departamentoResultado;
        }
        
        public static Departamento ObtenerDepartamento(string nombreDepartamento)
        {
            Departamento departamentoResultado = new Departamento();

            using (IDbConnection cxnDB = new SQLiteConnection(cadenaConexion))
            {
                DynamicParameters parametrosSentencia = new DynamicParameters();
                parametrosSentencia.Add("@nombre_departamento", nombreDepartamento,
                    DbType.String, ParameterDirection.Input);

                string sentenciaSQL =   "SELECT codigo, nombre FROM departamentos " +
                                        "WHERE nombre = @nombre_departamento";

                var salida = cxnDB.Query<Departamento>(sentenciaSQL, parametrosSentencia);

                if (salida.ToArray().Length > 0)
                    departamentoResultado = salida.First();
            }

            return departamentoResultado;
        }

        public static bool InsertarDepartamento(Departamento unDepartamento, out string mensajeInsercion)
        {
            mensajeInsercion = string.Empty;
            bool resultadoInsercion = false;

            int cantidadFilas;

            using (IDbConnection cxnDB = new SQLiteConnection(cadenaConexion))
            {
                //Validamos primero que el nombre del departamento no exista previamente
                //Obtenemos el Objeto que representa este departamento
                Departamento departamentoExistente = ObtenerDepartamento(unDepartamento.Nombre!);

                if (departamentoExistente.Codigo != 0)
                {
                    resultadoInsercion = false;
                    mensajeInsercion = $"Ya existe un departamento con el nombre {unDepartamento.Nombre}";
                }
                else
                {
                    try
                    {
                        string insertaDepartamentoSql = "INSERT INTO departamentos (nombre) " +
                                                        "VALUES (@Nombre)";
                        cantidadFilas = cxnDB.Execute(insertaDepartamentoSql, unDepartamento);
                    }
                    catch (SQLiteException)
                    {
                        resultadoInsercion = false;
                        mensajeInsercion = "Fallo de inserción a nivel de DB";
                        cantidadFilas = 0;
                    }

                    if (cantidadFilas > 0)
                    {
                        resultadoInsercion = true;
                        mensajeInsercion = $"Inserción del departamento {unDepartamento.Nombre} se hizo correctamente";
                    }
                }
            }

            return resultadoInsercion;
        }

        public static bool ActualizarDepartamento(Departamento unDepartamento, out string mensajeActualizacion)
        {
            mensajeActualizacion = string.Empty;
            bool resultadoActualizacion = false;

            int cantidadFilas;

            using (IDbConnection cxnDB = new SQLiteConnection(cadenaConexion))
            {
                try
                {
                    string actualizaDepartamentoSql =   "UPDATE departamentos SET nombre = @Nombre " +
                                                        "WHERE codigo = @Codigo";

                    cantidadFilas = cxnDB.Execute(actualizaDepartamentoSql, unDepartamento);

                    if (cantidadFilas > 0)
                    {
                        resultadoActualizacion = true;
                        mensajeActualizacion = $"Actualización Exitosa. Ahora el departamento se llama {unDepartamento.Nombre}";
                    }
                }
                catch (SQLiteException elError)
                {
                    resultadoActualizacion = false;
                    cantidadFilas = 0;
                    mensajeActualizacion = $"Error de Actualización en la DB. {elError.Message}";
                }
            }

            return resultadoActualizacion;
        }

        public static bool EliminarDepartamento(Departamento unDepartamento, out string mensajeEliminacion)
        {
            mensajeEliminacion = string.Empty;
            bool resultadoEliminacion = false;

            int cantidadFilas;

            //Validamos primero que el departamento no tenga municipios asociados
            int cantidadMunicipios = ObtenerCantidadMunicipiosPorDepartamento(unDepartamento.Codigo);

            if (cantidadMunicipios != 0)
            {
                resultadoEliminacion = false;
                mensajeEliminacion = $"No se pudo eliminar el departamento {unDepartamento.Nombre} " +
                    $"porque tiene asociado {cantidadMunicipios} municipio(s).";
            }
            else
            {
                //Ya que sabemos que no tiene municipios asociados, se puede borrar
                using (IDbConnection cxnDB = new SQLiteConnection(cadenaConexion))
                {
                    try
                    {
                        string eliminaDepartamentoSql = "DELETE FROM departamentos WHERE " +
                                                        "codigo = @Codigo";

                        cantidadFilas = cxnDB.Execute(eliminaDepartamentoSql, unDepartamento);

                        if (cantidadFilas > 0)
                        {
                            resultadoEliminacion = true;
                            mensajeEliminacion = "Eliminación Exitosa";
                        }

                    }
                    catch (SQLiteException elError)
                    {
                        resultadoEliminacion = false;
                        cantidadFilas = 0;
                        mensajeEliminacion = $"Error de borrado en la DB. {elError.Message}";
                    }
                }
            }

            return resultadoEliminacion;
        }

        private static int ObtenerCantidadMunicipiosPorDepartamento(int codigoDepartamento)
        {
            int cantidadMunicipiosDepartamento=0;

            using (IDbConnection cxnDB = new SQLiteConnection(cadenaConexion))
            {
                DynamicParameters parametrosSentencia = new DynamicParameters();
                parametrosSentencia.Add("@codigo_departamento", codigoDepartamento,
                    DbType.Int32, ParameterDirection.Input);

                string sentenciaSql =   "SELECT count(codigo) total FROM municipios " +
                                        "WHERE codigo_departamento = @codigo_departamento";

                cantidadMunicipiosDepartamento = cxnDB.Query<int>(sentenciaSql, parametrosSentencia).FirstOrDefault();                
            }

            return cantidadMunicipiosDepartamento;
        }

        #endregion CRUD_Departamentos

        #region CRUD_Cuencas

        public static int ObtenerCodigoCuenca(string nombreCuenca)
        {
            int codigoCuenca = 0;

            using (IDbConnection cxnDB = new SQLiteConnection(cadenaConexion))
            {
                DynamicParameters parametrosSentencia = new DynamicParameters();
                parametrosSentencia.Add("@nombre_cuenca", nombreCuenca,
                    DbType.String, ParameterDirection.Input);

                string sentenciaSql =   "SELECT DISTINCT codigo FROM cuencas " +
                                        "WHERE nombre = @nombre_cuenca";
                
                codigoCuenca = cxnDB.Query<int>(sentenciaSql, parametrosSentencia).FirstOrDefault();
            }

            return codigoCuenca;
        }

        public static List<Cuenca> ObtieneListaCuencas()
        {
            using (IDbConnection cxnDB = new SQLiteConnection(cadenaConexion))
            {
                string sentenciaSQL = "SELECT DISTINCT codigo, nombre FROM cuencas ORDER BY nombre";
                var resultadoCuencas = cxnDB.Query<Cuenca>(sentenciaSQL, new DynamicParameters());

                return resultadoCuencas.AsList();
            }
        }

        public static List<string> ObtieneListaNombresCuencas()
        {
            using (IDbConnection cxnDB = new SQLiteConnection(cadenaConexion))
            {
                string sentenciaSQL = "SELECT DISTINCT nombre FROM cuencas ORDER BY nombre";
                var resultadoCuencas = cxnDB.Query<string>(sentenciaSQL, new DynamicParameters());

                return resultadoCuencas.AsList();
            }
        }

        public static Cuenca ObtenerCuenca(int codigoCuenca)
        {
            Cuenca cuencaResultado = new Cuenca();

            using (IDbConnection cxnDB = new SQLiteConnection(cadenaConexion))
            {
                DynamicParameters parametrosSentencia = new DynamicParameters();
                parametrosSentencia.Add("@codigo_cuenca", codigoCuenca,
                    DbType.Int32, ParameterDirection.Input);

                string sentenciaSQL =   "SELECT codigo, nombre FROM cuencas " +
                                        "WHERE codigo = @codigo_cuenca";

                var salida = cxnDB.Query<Cuenca>(sentenciaSQL, parametrosSentencia);

                if (salida.ToArray().Length > 0)
                    cuencaResultado = salida.First();
            }

            return cuencaResultado;
        }

        public static Cuenca ObtenerCuenca(string nombreCuenca)
        {
            Cuenca cuencaResultado = new Cuenca();

            using (IDbConnection cxnDB = new SQLiteConnection(cadenaConexion))
            {
                DynamicParameters parametrosSentencia = new DynamicParameters();
                parametrosSentencia.Add("@nombre_cuenca", nombreCuenca,
                    DbType.String, ParameterDirection.Input);

                string sentenciaSQL =   "SELECT codigo, nombre FROM cuencas " +
                                        "WHERE nombre = @nombre_cuenca";

                var salida = cxnDB.Query<Cuenca>(sentenciaSQL, parametrosSentencia);

                if (salida.ToArray().Length > 0)
                    cuencaResultado = salida.First();
            }

            return cuencaResultado;
        }

        public static bool InsertarCuenca(Cuenca unaCuenca, out string mensajeInsercion)
        {
            mensajeInsercion = string.Empty;
            bool resultadoInsercion = false;

            int cantidadFilas;

            using (IDbConnection cxnDB = new SQLiteConnection(cadenaConexion))
            {
                //Validamos primero que el nombre de la cuenca no exista previamente
                //Obtenemos el Objeto que representa esta cuenca
                Cuenca cuencaExistente = ObtenerCuenca(unaCuenca.Nombre!);

                if (cuencaExistente.Codigo != 0)
                {
                    resultadoInsercion = false;
                    mensajeInsercion = $"Ya existe una cuenca con el nombre {unaCuenca.Nombre}";
                }
                else
                {
                    try
                    {
                        string insertaMetodoSql = "INSERT INTO cuencas (nombre) " +
                                                        "VALUES (@Nombre)";
                        cantidadFilas = cxnDB.Execute(insertaMetodoSql, unaCuenca);
                    }
                    catch (SQLiteException)
                    {
                        resultadoInsercion = false;
                        mensajeInsercion = "Fallo de inserción a nivel de DB";
                        cantidadFilas = 0;
                    }

                    if (cantidadFilas > 0)
                    {
                        resultadoInsercion = true;
                        mensajeInsercion = $"Inserción de la cuenca {unaCuenca.Nombre} se hizo correctamente";
                    }
                }
            }

            return resultadoInsercion;
        }

        public static bool ActualizarCuenca(Cuenca unaCuenca, out string mensajeActualizacion)
        {
            mensajeActualizacion = string.Empty;
            bool resultadoActualizacion = false;

            int cantidadFilas;

            //************************ Esto debería ser un issue en GitHub! ;-) *****************
            //Pendiente: Se debe validar previamente que el nuevo nombre de la cuenca no exista.
            //***********************************************************************************
            using (IDbConnection cxnDB = new SQLiteConnection(cadenaConexion))
            {
                try
                {
                    string actualizaCuencaSql = "UPDATE cuencas SET nombre = @Nombre " +
                                                "WHERE codigo = @Codigo";

                    cantidadFilas = cxnDB.Execute(actualizaCuencaSql, unaCuenca);

                    if (cantidadFilas > 0)
                    {
                        resultadoActualizacion = true;
                        mensajeActualizacion = $"Actualización Exitosa. Ahora la cuenca se llama {unaCuenca.Nombre}";
                    }
                }
                catch (SQLiteException elError)
                {
                    resultadoActualizacion = false;
                    cantidadFilas = 0;
                    mensajeActualizacion = $"Error de Actualización en la DB. {elError.Message}";
                }
            }

            return resultadoActualizacion;
        }

        public static bool EliminarCuenca(Cuenca unaCuenca, out string mensajeEliminacion)
        {
            mensajeEliminacion = string.Empty;
            bool resultadoEliminacion = false;

            int cantidadFilas;

            //Validamos primero que el método no tenga actividades asociadas
            int cantidadMunicipios = ObtenerCantidadMunicipiosPorCuenca(unaCuenca.Codigo);

            if (cantidadMunicipios != 0)
            {
                resultadoEliminacion = false;
                mensajeEliminacion = $"No se pudo eliminar la cuenca {unaCuenca.Nombre} " +
                    $"porque tiene asociado {cantidadMunicipios} municipios.";
            }
            else
            {
                //Ya que sabemos que no tiene actividades asociadas, se puede borrar
                using (IDbConnection cxnDB = new SQLiteConnection(cadenaConexion))
                {
                    try
                    {
                        string eliminaCuencaSql = "DELETE FROM cuencas WHERE " +
                                                        "codigo = @Codigo";

                        cantidadFilas = cxnDB.Execute(eliminaCuencaSql, unaCuenca);

                        if (cantidadFilas > 0)
                        {
                            resultadoEliminacion = true;
                            mensajeEliminacion = "Eliminación Exitosa";
                        }

                    }
                    catch (SQLiteException elError)
                    {
                        resultadoEliminacion = false;
                        cantidadFilas = 0;
                        mensajeEliminacion = $"Error de borrado en la DB. {elError.Message}";
                    }
                }
            }

            return resultadoEliminacion;
        }

        private static int ObtenerCantidadMunicipiosPorCuenca(int codigoCuenca)
        {
            int cantidadMunicipiosCuenca = 0;

            using (IDbConnection cxnDB = new SQLiteConnection(cadenaConexion))
            {
                DynamicParameters parametrosSentencia = new DynamicParameters();
                parametrosSentencia.Add("@codigo_cuenca", codigoCuenca,
                    DbType.Int32, ParameterDirection.Input);

                string sentenciaSql = "SELECT count(codigo) total FROM municipios " +
                                        "WHERE codigo_cuenca = @codigo_cuenca";

                cantidadMunicipiosCuenca = cxnDB.Query<int>(sentenciaSql, parametrosSentencia).FirstOrDefault();
            }

            return cantidadMunicipiosCuenca;
        }

        #endregion CRUD_Cuencas

        #region CRUD_Municipios

        public static int ObtenerCodigoMunicipio(string nombreMunicipio, string nombreDepartamento)
        {
            Municipio unMunicipio = ObtenerMunicipio(nombreMunicipio, nombreDepartamento);
            return unMunicipio.Codigo;
        }

        public static List<Municipio> ObtenerListaMunicipios()
        {
            using (IDbConnection cxnDB = new SQLiteConnection(cadenaConexion))
            {
                string consultaMunicipioSQL =   "SELECT DISTINCT codigo_municipio CodigoMunicipio, nombre_municipio NombreMunicipio, " +
                                                "codigo_cuenca CodigoCuenca, nombre_cuenca NombreCuenca, " +
                                                "codigo_departamento CodigoDepartamento, nombre_departamento NombreDepartamento " +
                                                "FROM v_info_municipios ORDER BY nombre_municipio";

                var resultadoMunicipios = cxnDB.Query<Municipio>(consultaMunicipioSQL, new DynamicParameters());

                return resultadoMunicipios.AsList();
            }
        }

        public static List<string> ObtenerListaNombresMunicipios(string nombreDepartamento)
        {
            using (IDbConnection cxnDB = new SQLiteConnection(cadenaConexion))
            {
                DynamicParameters parametrosSentencia = new DynamicParameters();
                parametrosSentencia.Add("@nombre_departamento", nombreDepartamento,
                    DbType.String, ParameterDirection.Input);

                string sentenciaSQL =   "SELECT DISTINCT nombre_municipio nombre " +
                                        "FROM v_info_municipios WHERE nombre_departamento = @nombre_Departamento " +
                                        "ORDER BY nombre";
                var resultadoMunicipios = cxnDB.Query<string>(sentenciaSQL, parametrosSentencia);

                return resultadoMunicipios.AsList();
            }
        }

        public static List<string> ObtenerListaInformacionMunicipios()
        {
            using (IDbConnection cxnDB = new SQLiteConnection(cadenaConexion))
            {
                var salida = cxnDB.Query<string>("SELECT (codigo_municipio || ' - ' || " +
                    "nombre_municipio || ' - ' || " +
                    "nombre_departamento || ' - ' || " +
                    "nombre_cuenca) infoMunicipio FROM v_info_municipios ORDER BY codigo_municipio", new DynamicParameters());
                
                return salida.ToList();
            }
        }

        public static Municipio ObtenerMunicipio(int codigoMunicipio)
        {
            Municipio unMunicipio = new Municipio();

            using (IDbConnection cxnDB = new SQLiteConnection(cadenaConexion))
            {
                //Se necesitan los dos parámetros porque existen municipios con el mismo nombre en diferente departamento

                DynamicParameters parametrosSentencia = new DynamicParameters();
                parametrosSentencia.Add("@codigo_municipio", codigoMunicipio,
                    DbType.String, ParameterDirection.Input);

                //Primero, validar la cantidad de municipios
                string cantidadMunicipiosSql = "SELECT COUNT(v.codigo_municipio) cantidadMunicipios FROM v_info_municipios v " +
                                                "WHERE v.codigo_municipio = @codigo_municipio";

                int cantidadMunicipios = cxnDB.Query<int>(cantidadMunicipiosSql, parametrosSentencia).FirstOrDefault();

                if (cantidadMunicipios != 0)
                {
                    string consultaMunicipioSQL = "SELECT DISTINCT codigo_municipio Codigo, nombre_municipio Nombre, " +
                                                    "codigo_cuenca CodigoCuenca, nombre_cuenca NombreCuenca, " +
                                                    "codigo_departamento CodigoDepartamento, nombre_departamento NombreDepartamento " +
                                                    "FROM v_info_municipios WHERE codigo_municipio = @codigo_municipio " +
                                                    "ORDER BY nombre_municipio";

                    var salida = cxnDB.Query<Municipio>(consultaMunicipioSQL, parametrosSentencia);

                    if (salida.ToArray().Length > 0)
                        unMunicipio = salida.First();
                }
            }

            return unMunicipio;
        }

        public static Municipio ObtenerMunicipio(string nombreMunicipio, string nombreDepartamento)
        {
            Municipio unMunicipio = new Municipio();

            using (IDbConnection cxnDB = new SQLiteConnection(cadenaConexion))
            {
                //Se necesitan los dos parámetros porque existen municipios con el mismo nombre en diferente departamento

                DynamicParameters parametrosSentencia = new DynamicParameters();
                parametrosSentencia.Add("@nombre_departamento", nombreDepartamento,
                    DbType.String, ParameterDirection.Input);
                parametrosSentencia.Add("@nombre_municipio", nombreMunicipio,
                    DbType.String, ParameterDirection.Input);

                //Primero, validar la cantidad de municipios
                string cantidadMunicipiosSql = "SELECT COUNT(codigo_municipio) cantidadMunicipios FROM v_info_municipios " +
                                                "WHERE nombre_departamento = @nombre_departamento " +
                                                "AND nombre_municipio = @nombre_municipio";

                int cantidadMunicipios = cxnDB.Query<int>(cantidadMunicipiosSql, parametrosSentencia).FirstOrDefault();

                if (cantidadMunicipios != 0)
                {
                    string consultaMunicipioSQL =   "SELECT DISTINCT codigo_municipio Codigo, nombre_municipio Nombre, " +
                                                    "codigo_cuenca CodigoCuenca, nombre_cuenca NombreCuenca, " +
                                                    "codigo_departamento CodigoDepartamento, nombre_departamento NombreDepartamento " +
                                                    "FROM v_info_municipios " +
                                                    "WHERE nombre_departamento = @nombre_departamento " +
                                                    "AND nombre_municipio = @nombre_municipio " +
                                                    "ORDER BY nombre_municipio";

                    var salida = cxnDB.Query<Municipio>(consultaMunicipioSQL, parametrosSentencia);

                    if (salida.ToArray().Length > 0)
                        unMunicipio = salida.First();
                }
            }

            return unMunicipio;
        }

        public static bool InsertarMunicipio(Municipio nuevoMunicipio, out string mensajeInsercion)
        {
            mensajeInsercion = string.Empty;
            bool resultadoInsercion = false;

            int cantidadFilas;

            //Aqui validamos primero que el nombre del municipio no exista para ese departamento
            using (IDbConnection cxnDB = new SQLiteConnection(cadenaConexion))
            {
                //Complementamos códigos del municipio
                ComplementarCodigosEnMunicipio(nuevoMunicipio);

                //Si el código del municipio es != 0, el municipio ya existe y no se puede insertar
                if (nuevoMunicipio.Codigo != 0)
                {
                    resultadoInsercion = false;
                    mensajeInsercion = $"Ya existe un municipio con ese nombre para " +
                        $"el departamento {nuevoMunicipio.NombreDepartamento}";
                }
                else
                {
                    //Se procede con la inserción
                    try
                    {
                        string insertaDepartamentoSql = "INSERT INTO municipios (nombre, codigo_departamento, codigo_cuenca) " +
                                                        "VALUES (@Nombre, @CodigoDepartamento, @CodigoCuenca)";
                        
                        cantidadFilas = cxnDB.Execute(insertaDepartamentoSql, nuevoMunicipio);
                    }
                    catch (SQLiteException)
                    {
                        resultadoInsercion = false;
                        mensajeInsercion = "Fallo de inserción a nivel de DB";
                        cantidadFilas = 0;
                    }

                    //Si la inserción fue correcta, devolvemos true
                    if (cantidadFilas > 0)
                    {
                        resultadoInsercion = true;
                        mensajeInsercion = $"Inserción del municipio {nuevoMunicipio.Nombre} se hizo para " +
                            $"el departamento {nuevoMunicipio.NombreDepartamento} en la cuenca {nuevoMunicipio.NombreCuenca}";
                    }
                }
            }        
            
            return resultadoInsercion;
        }
        
        public static bool ActualizarMunicipio(Municipio unMunicipio, out string mensajeActualizacion)
        {
            mensajeActualizacion = string.Empty;
            bool resultadoActualizacion = false;

            int cantidadFilas;

            /*
                Actualización:
                Busca permitir el cambio de nombre, departamento o cuenca a un municipio siempre y cuando
                el resultado no coincida con la misma combinación de otro municipio que ya exista
            */

            //Complementamos códigos de Cuenca y Departamento según los datos que viene de la Interfaz
            unMunicipio.CodigoCuenca = ObtenerCodigoCuenca(unMunicipio.NombreCuenca!);
            unMunicipio.CodigoDepartamento = ObtenerCodigoDepartamento(unMunicipio.NombreDepartamento!);

            //Con esos mismos nombres de municipio y departamento, buscamos si existe un municipio
            Municipio municipioExistente = ObtenerMunicipio(unMunicipio.Nombre!, unMunicipio.NombreDepartamento!);

            //Si el código es distinto entre estos dos municipios pero con mismo nombre de municipio y departamento,
            //no se puede hacer la actualización porque ya hay otro municipio con ese nombre
            if(unMunicipio.Codigo != municipioExistente.Codigo &&
                unMunicipio.Nombre == municipioExistente.Nombre &&
                unMunicipio.NombreDepartamento == municipioExistente.NombreDepartamento)
            {
                resultadoActualizacion = false;
                mensajeActualizacion = $"No se hizo actualización porque ya existe un municipio " +
                    $"en el departamento {unMunicipio.NombreDepartamento} " +
                    $"para la cuenca {unMunicipio.NombreCuenca}";
            }
            else
            {
                using (IDbConnection cxnDB = new SQLiteConnection(cadenaConexion))
                {
                    try
                    {
                        string actualizaMunicipioSQL =  "UPDATE municipios SET nombre = @Nombre, " +
                                                        "codigo_cuenca = @CodigoCuenca, " +
                                                        "codigo_departamento = @CodigoDepartamento " +
                                                        "WHERE codigo = @Codigo";

                        cantidadFilas = cxnDB.Execute(actualizaMunicipioSQL, unMunicipio);

                        if (cantidadFilas > 0)
                        {
                            resultadoActualizacion = true;
                            mensajeActualizacion = $"Municipio actualizado correctamente. Nombre {unMunicipio.Nombre}, " +
                                $"en la cuenca {unMunicipio.NombreCuenca}, en el departamento {unMunicipio.NombreDepartamento}";
                        }
                    }
                    catch (SQLiteException elError)
                    {
                        resultadoActualizacion = false;
                        cantidadFilas = 0;
                        mensajeActualizacion = $"Error de Actualizción en la DB. {elError.Message}";
                    }
                }
            }

            return resultadoActualizacion;
        }

        public static bool EliminarMunicipio(Municipio unMunicipio, out string mensajeEliminacion)
        {
            mensajeEliminacion = string.Empty;
            bool resultadoEliminacion = false;

            int cantidadFilas;

            //Validaciones a realizar
            //1. Que el municipio exista
            //2. Que no tenga actividades de pesca asignadas

            Municipio municipioExistente = ObtenerMunicipio(unMunicipio.Codigo);

            if (municipioExistente.Codigo == 0)
            {
                resultadoEliminacion = false;
                mensajeEliminacion = $"No se encontró municipio {unMunicipio.Nombre} para eliminar";
            }
            else
            {
                //Ya que sabemos existe, validemos que no haya actividades de pesca asociadas
                int cantidadActividades = ObtenerCantidadActividadesPorMunicipio(unMunicipio.Codigo);

                if (cantidadActividades != 0)
                {
                    resultadoEliminacion = false;
                    mensajeEliminacion = $"No se pudo eliminar el municipio {unMunicipio.Nombre} " +
                        $"porque tiene asociadas {cantidadActividades} actividad(es) de pesca";
                }
                else 
                {
                    //Ya que sabemos que no tiene actividades de pesca asociada, se puede borrar
                    using (IDbConnection cxnDB = new SQLiteConnection(cadenaConexion))
                    {
                        try
                        {
                            string eliminaMunicipioSQL = "DELETE FROM municipios " +
                                                         "WHERE codigo = @Codigo";

                            cantidadFilas = cxnDB.Execute(eliminaMunicipioSQL, unMunicipio);

                            if (cantidadFilas > 0)
                            {
                                resultadoEliminacion = true;
                                mensajeEliminacion = "Eliminación Exitosa";
                            }

                        }
                        catch (SQLiteException elError)
                        {
                            resultadoEliminacion = false;
                            cantidadFilas = 0;
                            mensajeEliminacion = $"Error de borrado en la DB. {elError.Message}";
                        }

                    }

                }
            }

            return resultadoEliminacion;
        }

        private static void ComplementarCodigosEnMunicipio(Municipio municipioIncompleto)
        {
            municipioIncompleto.Codigo = ObtenerCodigoMunicipio(municipioIncompleto.Nombre!, municipioIncompleto.NombreDepartamento!);
            municipioIncompleto.CodigoCuenca = ObtenerCodigoCuenca(municipioIncompleto.NombreCuenca!);
            municipioIncompleto.CodigoDepartamento = ObtenerCodigoDepartamento(municipioIncompleto.NombreDepartamento!);
        }

        #endregion CRUD_Municipios

        #region CRUD_MetodosPesca

        public static int ObtenerCodigoMetodo(string nombreMetodo)
        {
            int codigoMetodo = 0;

            using (IDbConnection cxnDB = new SQLiteConnection(cadenaConexion))
            {
                DynamicParameters parametrosSentencia = new DynamicParameters();
                parametrosSentencia.Add("@nombre_metodo", nombreMetodo,
                    DbType.String, ParameterDirection.Input);

                string sentenciaSql = "SELECT DISTINCT codigo FROM metodos " +
                                        "WHERE nombre = @nombre_metodo";

                codigoMetodo = cxnDB.Query<int>(sentenciaSql, parametrosSentencia).FirstOrDefault();
            }

            return codigoMetodo;
        }

        public static List<Metodo> ObtenerListaMetodos()
        {
            using (IDbConnection cxnDB = new SQLiteConnection(cadenaConexion))
            {
                string sentenciaSQL = "SELECT DISTINCT codigo, nombre FROM metodos ORDER BY nombre";
                var resultadoMetodos = cxnDB.Query<Metodo>(sentenciaSQL, new DynamicParameters());

                return resultadoMetodos.AsList();
            }
        }

        public static List<string> ObtenerListaNombresMetodos()
        {
            using (IDbConnection cxnDB = new SQLiteConnection(cadenaConexion))
            {
                string sentenciaSQL = "SELECT DISTINCT nombre FROM metodos ORDER BY nombre";
                var resultadoMetodos = cxnDB.Query<string>(sentenciaSQL, new DynamicParameters());

                return resultadoMetodos.AsList();
            }
        }

        public static Metodo ObtenerMetodo(int codigoMetodo)
        {
            Metodo metodoResultado = new Metodo();

            using (IDbConnection cxnDB = new SQLiteConnection(cadenaConexion))
            {

                DynamicParameters parametrosSentencia = new DynamicParameters();
                parametrosSentencia.Add("@codigo_metodo", codigoMetodo,
                    DbType.Int32, ParameterDirection.Input);

                string sentenciaSQL = "SELECT codigo, nombre FROM metodos " +
                                        "WHERE codigo = @codigo_metodo";

                var salida = cxnDB.Query<Metodo>(sentenciaSQL, parametrosSentencia);

                if (salida.ToArray().Length > 0)
                    metodoResultado = salida.First();
            }

            return metodoResultado;
        }

        public static Metodo ObtenerMetodo(string nombreMetodo)
        {
            Metodo metodoResultado = new Metodo();

            using (IDbConnection cxnDB = new SQLiteConnection(cadenaConexion))
            {

                DynamicParameters parametrosSentencia = new DynamicParameters();
                parametrosSentencia.Add("@nombre_metodo", nombreMetodo,
                    DbType.String, ParameterDirection.Input);

                string sentenciaSQL = "SELECT codigo, nombre FROM metodos " +
                                        "WHERE nombre = @nombre_metodo";

                var salida = cxnDB.Query<Metodo>(sentenciaSQL, parametrosSentencia);

                if (salida.ToArray().Length > 0)
                    metodoResultado = salida.First();
            }

            return metodoResultado;
        }

        public static bool InsertarMetodo(Metodo unMetodo, out string mensajeInsercion)
        {
            mensajeInsercion = string.Empty;
            bool resultadoInsercion = false;

            int cantidadFilas;

            using (IDbConnection cxnDB = new SQLiteConnection(cadenaConexion))
            {
                //Validamos primero que el nombre del metodo no exista previamente
                //Obtenemos el Objeto que representa este metodo
                Metodo metodoExistente = ObtenerMetodo(unMetodo.Nombre!);

                if (metodoExistente.Codigo != 0)
                {
                    resultadoInsercion = false;
                    mensajeInsercion = $"Ya existe un método con el nombre {unMetodo.Nombre}";
                }
                else
                {
                    try
                    {
                        string insertaMetodoSql = "INSERT INTO metodos (nombre) " +
                                                        "VALUES (@Nombre)";
                        cantidadFilas = cxnDB.Execute(insertaMetodoSql, unMetodo);
                    }
                    catch (SQLiteException)
                    {
                        resultadoInsercion = false;
                        mensajeInsercion = "Fallo de inserción a nivel de DB";
                        cantidadFilas = 0;
                    }

                    if (cantidadFilas > 0)
                    {
                        resultadoInsercion = true;
                        mensajeInsercion = $"Inserción del método {unMetodo.Nombre} se hizo correctamente";
                    }
                }
            }

            return resultadoInsercion;
        }

        public static bool ActualizarMetodo(Metodo unMetodo, out string mensajeActualizacion)
        {
            mensajeActualizacion = string.Empty;
            bool resultadoActualizacion = false;

            int cantidadFilas;

            //************************ Esto debería ser un issue en GitHub! ;-) *****************
            //Pendiente: Se debe validar previamente que el nuevo nombre del método no exista.
            //***********************************************************************************
            using (IDbConnection cxnDB = new SQLiteConnection(cadenaConexion))
            {
                try
                {
                    string actualizaMetodoSql = "UPDATE metodos SET nombre = @Nombre " +
                                                "WHERE codigo = @Codigo";

                    cantidadFilas = cxnDB.Execute(actualizaMetodoSql, unMetodo);

                    if (cantidadFilas > 0)
                    {
                        resultadoActualizacion = true;
                        mensajeActualizacion = $"Actualización Exitosa. Ahora el método se llama {unMetodo.Nombre}";
                    }
                }
                catch (SQLiteException elError)
                {
                    resultadoActualizacion = false;
                    cantidadFilas = 0;
                    mensajeActualizacion = $"Error de Actualización en la DB. {elError.Message}";
                }
            }

            return resultadoActualizacion;
        }

        public static bool EliminarMetodo(Metodo unMetodo, out string mensajeEliminacion)
        {
            mensajeEliminacion = string.Empty;
            bool resultadoEliminacion = false;

            int cantidadFilas;

            //Validamos primero que el método no tenga actividades asociadas
            int cantidadActividades = ObtenerCantidadActividadesPorMetodo(unMetodo.Codigo);

            if (cantidadActividades != 0)
            {
                resultadoEliminacion = false;
                mensajeEliminacion = $"No se pudo eliminar el método de pesca {unMetodo.Nombre} " +
                    $"porque tiene asociado {cantidadActividades} actividad(es) de pesca.";
            }
            else
            {
                //Ya que sabemos que no tiene actividades asociadas, se puede borrar
                using (IDbConnection cxnDB = new SQLiteConnection(cadenaConexion))
                {
                    try
                    {
                        string eliminaMetodoSql = "DELETE FROM metodos WHERE " +
                                                        "codigo = @Codigo";

                        cantidadFilas = cxnDB.Execute(eliminaMetodoSql, unMetodo);

                        if (cantidadFilas > 0)
                        {
                            resultadoEliminacion = true;
                            mensajeEliminacion = "Eliminación Exitosa";
                        }

                    }
                    catch (SQLiteException elError)
                    {
                        resultadoEliminacion = false;
                        cantidadFilas = 0;
                        mensajeEliminacion = $"Error de borrado en la DB. {elError.Message}";
                    }
                }
            }

            return resultadoEliminacion;
        }

        #endregion CRUD_MetodosPesca

        #region CRUD_ActividadesPesca

        public static Actividad ObtenerActividad(int codigoActividad)
        {
            Actividad actividadResultado = new Actividad();

            using (IDbConnection cxnDB = new SQLiteConnection(cadenaConexion))
            {

                DynamicParameters parametrosSentencia = new DynamicParameters();
                parametrosSentencia.Add("@codigo_actividad", codigoActividad,
                    DbType.Int32, ParameterDirection.Input);

                string sentenciaSQL = "SELECT codigo_actividad Codigo, codigo_municipio CodigoMunicipio, " +
                    "nombre_municipio NombreMunicipio, codigo_metodo CodigoMetodo, " +
                    "nombre_metodo NombreMetodo, fecha, cantidad_pescado CantidadPescado " +
                    "FROM v_info_actividad " +
                    "WHERE codigo_actividad = @codigo_actividad";


                var salida = cxnDB.Query<Actividad>(sentenciaSQL, parametrosSentencia);

                //validamos cuantos registros devuelve la lista
                if (salida.ToArray().Length > 0)
                    actividadResultado = salida.First();
            }

            return actividadResultado;
        }
        public static bool InsertarActividad(Actividad nuevaActividad, out string mensajeInsercion)
        {
            mensajeInsercion = string.Empty;
            bool resultadoInsercion = false;

            int cantidadFilas;

            ComplementarCodigosEnActividad(nuevaActividad);

            //Aqui validamos primero que el nombre del municipio no exista para ese departamento
            using (IDbConnection cxnDB = new SQLiteConnection(cadenaConexion))
            {
                try
                {
                    string insertaActividadSQL = "INSERT INTO actividades (codigo_municipio, codigo_metodo, " +
                    "fecha, cantidad_pescado) VALUES (@CodigoMunicipio, @CodigoMetodo, @Fecha, @CantidadPescado)";

                    cantidadFilas = cxnDB.Execute(insertaActividadSQL, nuevaActividad);
                }
                catch (SQLiteException)
                {
                    resultadoInsercion = false;
                    mensajeInsercion = "Fallo de inserción a nivel de DB";
                    cantidadFilas = 0;
                }

                //Si la inserción fue correcta, devolvemos true
                if (cantidadFilas > 0)
                {
                    resultadoInsercion = true;
                    mensajeInsercion = $"Inserción de actividad de pesca en {nuevaActividad.NombreMunicipio} con " +
                        $"el método {nuevaActividad.NombreMetodo} el día {nuevaActividad.Fecha} con un total de " +
                        $"{nuevaActividad.CantidadPescado} Kgs de pescado";
                }
            }

            return resultadoInsercion;
        }

        public static bool ActualizarActividad(Actividad unaActividad, out string mensajeActualizacion)
        {
            mensajeActualizacion = string.Empty;
            bool resultadoActualizacion = false;

            int cantidadFilas;

            //Aqui validamos primero que la actividad a actualizar ya exista

            //Obtenemos el Objeto que representa este municipio
            Actividad otraActividad = ObtenerActividad(unaActividad.Codigo);

            if (otraActividad.Codigo == 0)
            {
                resultadoActualizacion = false;
                mensajeActualizacion = $"No existe actividad de pesca registrada con ese código.";
            }
            else
            {
                using (IDbConnection cxnDB = new SQLiteConnection(cadenaConexion))
                {
                    try
                    {
                        string actualizaActividadSQL = "UPDATE actividades SET " +
                            "codigo_municipio = @CodigoMunicipio, " +
                            "codigo_metodo = @CodigoMetodo," +
                            "cantidad_pescado = @CantidadPescado, " +
                            "fecha = @Fecha " +
                            "WHERE codigo = @Codigo";


                        cantidadFilas = cxnDB.Execute(actualizaActividadSQL, unaActividad);

                        if (cantidadFilas > 0)
                        {
                            resultadoActualizacion = true;
                            mensajeActualizacion = "Actualización Exitosa";
                        }
                    }
                    catch (SQLiteException elError)
                    {
                        resultadoActualizacion = false;
                        cantidadFilas = 0;
                        mensajeActualizacion = $"Error de Actualización en la DB. {elError.Message}";
                    }

                }
            }

            return resultadoActualizacion;
        }

        public static bool EliminarActividad(int codigoActividad, out string mensajeEliminacion)
        {
            mensajeEliminacion = string.Empty;
            bool resultadoEliminacion = false;

            int cantidadFilas;

            //Validaciones a realizar
            //1. Que la actividad exista

            Actividad unaActividad = ObtenerActividad(codigoActividad);

            if (unaActividad.Codigo == 0)
            {
                resultadoEliminacion = false;
                mensajeEliminacion = "No se encontró actividad con ese código";
            }
            else
            {
                //Ya que sabemos que existe la actividad, se puede borrar
                using (IDbConnection cxnDB = new SQLiteConnection(cadenaConexion))
                {
                    try
                    {
                        DynamicParameters parametrosSentencia = new DynamicParameters();
                        parametrosSentencia.Add("@codigo_actividad", codigoActividad,
                            DbType.Int32, ParameterDirection.Input);

                        string eliminaActividadSQL = "DELETE FROM actividades WHERE " +
                            "codigo = @codigo_actividad";

                        cantidadFilas = cxnDB.Execute(eliminaActividadSQL, parametrosSentencia);

                        if (cantidadFilas > 0)
                        {
                            resultadoEliminacion = true;
                            mensajeEliminacion = "Eliminación Exitosa";
                        }

                    }
                    catch (SQLiteException elError)
                    {
                        resultadoEliminacion = false;
                        cantidadFilas = 0;
                        mensajeEliminacion = $"Error de borrado en la DB. {elError.Message}";
                    }
                }
            }

            return resultadoEliminacion;
        }

        private static void ComplementarCodigosEnActividad(Actividad actividadIncompleta)
        {
            actividadIncompleta.CodigoMunicipio = ObtenerCodigoMunicipio(actividadIncompleta.NombreMunicipio!, actividadIncompleta.NombreDepartamento!);
            actividadIncompleta.CodigoMetodo = ObtenerCodigoMetodo(actividadIncompleta.NombreMetodo!);
        }

        public static DataTable ObtenerTablaActividadesPorMunicipio(int codigoMuninicipio)
        {
            DataTable tablaResultado = new DataTable();

            using (SQLiteConnection cxnDB = new SQLiteConnection(cadenaConexion))
            {
                string sentenciaSQL = "SELECT fecha, nombre_cuenca, nombre_metodo, cantidad_pescado " +
                    "FROM v_info_Actividad WHERE codigo_municipio = @codigo_municipio ORDER BY fecha";

                SQLiteCommand comandoSQL = new SQLiteCommand(sentenciaSQL, cxnDB);
                comandoSQL.Parameters.AddWithValue("@codigo_municipio",codigoMuninicipio);

                SQLiteDataAdapter daActividades = new SQLiteDataAdapter(comandoSQL);
                daActividades.Fill(tablaResultado);
            }

            return tablaResultado;
        }

        public static DataTable ObtenerTablaActividadesPorDepartamento(int codigoDepartamento)
        {
            DataTable tablaResultado = new DataTable();

            using (SQLiteConnection cxnDB = new SQLiteConnection(cadenaConexion))
            {
                string sentenciaSQL = "SELECT fecha, nombre_municipio, nombre_cuenca, nombre_metodo, cantidad_pescado " +
                    "FROM v_info_Actividad WHERE codigo_departamento = @codigo_departamento ORDER BY fecha";

                SQLiteCommand comandoSQL = new SQLiteCommand(sentenciaSQL, cxnDB);
                comandoSQL.Parameters.AddWithValue("@codigo_departamento", codigoDepartamento);

                SQLiteDataAdapter daActividades = new SQLiteDataAdapter(comandoSQL);
                daActividades.Fill(tablaResultado);
            }

            return tablaResultado;
        }

        public static DataTable ObtenerTablaActividadesPorMetodo(int codigoMetodo)
        {
            DataTable tablaResultado = new DataTable();

            using (SQLiteConnection cxnDB = new SQLiteConnection(cadenaConexion))
            {
                string sentenciaSQL = "SELECT fecha, nombre_municipio, nombre_departamento, nombre_cuenca, cantidad_pescado " +
                    "FROM v_info_Actividad WHERE codigo_metodo = @codigo_metodo ORDER BY fecha";

                SQLiteCommand comandoSQL = new SQLiteCommand(sentenciaSQL, cxnDB);
                comandoSQL.Parameters.AddWithValue("@codigo_metodo", codigoMetodo);

                SQLiteDataAdapter daActividades = new SQLiteDataAdapter(comandoSQL);
                daActividades.Fill(tablaResultado);
            }

            return tablaResultado;
        }

        public static DataTable ObtenerTablaActividadesPorCuenca(int codigoCuenca)
        {
            DataTable tablaResultado = new DataTable();

            using (SQLiteConnection cxnDB = new SQLiteConnection(cadenaConexion))
            {
                string sentenciaSQL = "SELECT fecha, nombre_municipio, nombre_departamento, nombre_metodo, cantidad_pescado " +
                    "FROM v_info_Actividad WHERE codigo_cuenca = @codigo_cuenca ORDER BY fecha";

                SQLiteCommand comandoSQL = new SQLiteCommand(sentenciaSQL, cxnDB);
                comandoSQL.Parameters.AddWithValue("@codigo_cuenca", codigoCuenca);

                SQLiteDataAdapter daActividades = new SQLiteDataAdapter(comandoSQL);
                daActividades.Fill(tablaResultado);
            }

            return tablaResultado;
        }

        private static int ObtenerCantidadActividadesPorMunicipio(int codigoMuninicipio)
        {
            using (IDbConnection cxnDB = new SQLiteConnection(cadenaConexion))
            {
                DynamicParameters parametrosSentencia = new DynamicParameters();
                parametrosSentencia.Add("@codigo_municipio", codigoMuninicipio,
                    DbType.Int32, ParameterDirection.Input);

                int cantidadActividades = cxnDB.Query<int>("SELECT count(codigo_actividad) total FROM v_info_Actividad " +
                "WHERE codigo_municipio = @codigo_municipio", parametrosSentencia).FirstOrDefault();

                return cantidadActividades;
            }
        }

        private static int ObtenerCantidadActividadesPorDepartamento(int codigoDepartamento)
        {
            using (IDbConnection cxnDB = new SQLiteConnection(cadenaConexion))
            {
                DynamicParameters parametrosSentencia = new DynamicParameters();
                parametrosSentencia.Add("@codigo_departamento", codigoDepartamento,
                    DbType.Int32, ParameterDirection.Input);

                int cantidadActividades = cxnDB.Query<int>("SELECT count(codigo_actividad) total FROM v_info_Actividad " +
                "WHERE codigo_departamento = @codigo_departamento", parametrosSentencia).FirstOrDefault();

                return cantidadActividades;
            }
        }

        private static int ObtenerCantidadActividadesPorMetodo(int codigoMetodo)
        {
            using (IDbConnection cxnDB = new SQLiteConnection(cadenaConexion))
            {
                DynamicParameters parametrosSentencia = new DynamicParameters();
                parametrosSentencia.Add("@codigo_metodo", codigoMetodo,
                    DbType.Int32, ParameterDirection.Input);

                int cantidadActividades = cxnDB.Query<int>("SELECT count(codigo_actividad) total FROM v_info_Actividad " +
                "WHERE codigo_metodo = @codigo_metodo", parametrosSentencia).FirstOrDefault();

                return cantidadActividades;
            }
        }

        private static int ObtenerCantidadActividadesPorCuenca(int codigoCuenca)
        {
            using (IDbConnection cxnDB = new SQLiteConnection(cadenaConexion))
            {
                DynamicParameters parametrosSentencia = new DynamicParameters();
                parametrosSentencia.Add("@codigo_cuenca", codigoCuenca,
                    DbType.Int32, ParameterDirection.Input);

                int cantidadActividades = cxnDB.Query<int>("SELECT count(codigo_actividad) total FROM v_info_Actividad " +
                "WHERE codigo_cuenca = @codigo_cuenca", parametrosSentencia).FirstOrDefault();

                return cantidadActividades;
            }
        }

        #endregion CRUD_ActividadesPesca
    }
}

