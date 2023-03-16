using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PescaArtesanal_WindowsForms.Modelos;

namespace PescaArtesanal_WindowsForms
{
    public class AccesoDatos
    {
        static string? cadenaConexion;
        
        /// <summary>
        /// Obtiene la cadena de conexión para utilizar en las operaciones CRUD
        /// </summary>
        /// <returns>string con la cadena de conexión</returns>
        public static string? ObtieneCadenaConexion()
        {
            //Parametrizamos el acceso al archivo de configuración appsettings.json
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            IConfiguration miConfiguracion = builder.Build();

            return miConfiguracion["ConnectionString:Sqlite"];
        }

        #region CRUD_Departamentos

        /// <summary>
        /// Obtiene la lista con los nombres de los departamentos
        /// </summary>
        /// <returns>lista de strings con los nombres de los departamentos</returns>
        public static List<string> ObtieneListaNombresDepartamentos()
        {
            cadenaConexion = ObtieneCadenaConexion();

            using (IDbConnection cxnDB = new SQLiteConnection(cadenaConexion))
            {
                string sentenciaSQL = "SELECT DISTINCT nombre FROM departamentos ORDER BY nombre";
                var resultadoDepartamentos = cxnDB.Query<string>(sentenciaSQL, new DynamicParameters());

                return resultadoDepartamentos.AsList();
            }
        }

        /// <summary>
        /// Obtiene el código del departamento a partir de su nombre
        /// </summary>
        /// <param name="nombreDepartamento">Nombre del Departamento</param>
        /// <returns>0 si el departamento no existe o el código registrado</returns>
        public static int ObtieneCodigoDepartamento(string nombreDepartamento)
        {
            cadenaConexion = ObtieneCadenaConexion();
            
            using (IDbConnection cxnDB = new SQLiteConnection(cadenaConexion))
            {
                DynamicParameters parametrosSentencia = new DynamicParameters();
                parametrosSentencia.Add("@nombre_departamento", nombreDepartamento,
                    DbType.String, ParameterDirection.Input);

                int codigoDepartamento = cxnDB.Query<int>("SELECT DISTINCT codigo FROM departamentos " +
                "WHERE nombre = @nombre_departamento", parametrosSentencia).FirstOrDefault();

                return codigoDepartamento;
            }
        }

        #endregion CRUD_Departamentos

        #region CRUD_Cuencas

        /// <summary>
        /// Obtiene la lista con los nombres de las cuencas
        /// </summary>
        /// <returns>lista de strings con los nombres de las cuencas</returns>
        public static List<string> ObtieneListaNombresCuencas()
        {
            string? cadenaConexion = ObtieneCadenaConexion();

            using (IDbConnection cxnDB = new SQLiteConnection(cadenaConexion))
            {
                string sentenciaSQL = "SELECT DISTINCT nombre FROM cuencas ORDER BY nombre";
                var resultadoCuencas = cxnDB.Query<string>(sentenciaSQL, new DynamicParameters());

                return resultadoCuencas.AsList();
            }
        }

        /// <summary>
        /// Obtiene el código de la cuenca a partir de su nombre
        /// </summary>
        /// <param name="nombreCuenca">Nombre de la cuenca</param>
        /// <returns>0 si la cuenca no existe o el código registrado</returns>
        public static int ObtieneCodigoCuenca(string nombreCuenca)
        {
            cadenaConexion = ObtieneCadenaConexion();

            using (IDbConnection cxnDB = new SQLiteConnection(cadenaConexion))
            {
                DynamicParameters parametrosSentencia = new DynamicParameters();
                parametrosSentencia.Add("@nombre_cuenca", nombreCuenca,
                    DbType.String, ParameterDirection.Input);

                int codigoCuenca = cxnDB.Query<int>("SELECT DISTINCT codigo FROM cuencas " +
                "WHERE nombre = @nombre_cuenca", parametrosSentencia).FirstOrDefault();

                return codigoCuenca;
            }
        }

        #endregion CRUD_Cuencas

        #region CRUD_Municipios

        /// <summary>
        /// Obtiene el código del Municipio a partir del nombre del municipio y el departamento
        /// </summary>
        /// <param name="nombreMunicipio">EL nombre del municipio</param>
        /// <param name="nombreDepartamento">El nombre de la cuenca</param>
        /// <returns>0 si el municipio no existe o el código registrado</returns>
        public static int ObtieneCodigoMunicipio(string nombreMunicipio, string nombreDepartamento)
        {
            cadenaConexion = ObtieneCadenaConexion();

            using (IDbConnection cxnDB = new SQLiteConnection(cadenaConexion))
            {
                //Se necesitan los dos parámetros porque existen municipios con el mismo nombre en diferente departamento
                
                DynamicParameters parametrosSentencia = new DynamicParameters();
                parametrosSentencia.Add("@nombre_departamento", nombreDepartamento,
                    DbType.String, ParameterDirection.Input);
                parametrosSentencia.Add("@nombre_municipio", nombreMunicipio,
                    DbType.String, ParameterDirection.Input);

                string consultaMunicipioSQL = "SELECT DISTINCT m.codigo FROM municipios m " +
                "JOIN departamentos d ON m.codigo_departamento = d.codigo " +
                "WHERE d.nombre = @nombre_departamento " +
                "AND m.nombre = @nombre_municipio";

                int codigoMunicipio = cxnDB.Query<int>(consultaMunicipioSQL, parametrosSentencia).FirstOrDefault();

                return codigoMunicipio;
            }
        }

        /// <summary>
        /// Obtiene lista con información ampliada de los municipios
        /// </summary>
        /// <returns>Lista con información de los municipios</returns>
        public static List<string> ObtieneListaInfoMunicipios()
        {
            cadenaConexion = ObtieneCadenaConexion();

            using (IDbConnection cxnDB = new SQLiteConnection(cadenaConexion))
            {
                var salida = cxnDB.Query<string>("SELECT (codigo_municipio || ' - ' || " +
                    "nombre_municipio || ' - ' || " +
                    "nombre_departamento || ' - ' || " +
                    "nombre_cuenca) infoMunicipio FROM v_info_municipios ORDER BY codigo_municipio", new DynamicParameters());
                
                return salida.ToList();
            }
        }

        /// <summary>
        /// Inserta un nuevo municipio
        /// </summary>
        /// <param name="nombreMunicipio">nombre del municipio</param>
        /// <param name="nombreDepartamento">nombre del departamento</param>
        /// <param name="nombreCuenca">nombre de la cuenca</param>
        /// <param name="mensajeInsercion">Resultado del proceso de inserción</param>
        /// <returns>verdadero si la inserción fue exitosa</returns>
        public static bool InsertaNuevoMunicipio(string nombreMunicipio,
                                string nombreDepartamento,
                                string nombreCuenca,
                                out string mensajeInsercion)
        {
            mensajeInsercion = string.Empty;
            bool resultadoInsercion = false;

            int cantidadFilas = 0;
            cadenaConexion = ObtieneCadenaConexion();

            //Aqui validamos primero que el nombre del municipio no exista para ese departamento
            using (IDbConnection cxnDB = new SQLiteConnection(cadenaConexion))
            {
                //Obtenemos el Objeto que representa este municipio
                Municipio nuevoMunicipio = ObtieneMunicipio(nombreMunicipio, nombreCuenca, nombreDepartamento);

                //Si el código del municipio es != 0, el municipio ya existe y no se puede insertar
                if (nuevoMunicipio.Codigo != 0)
                {
                    resultadoInsercion = false;
                    mensajeInsercion = $"Ya existe un municipio con ese nombre para " +
                        $"el departamento {nombreDepartamento}";
                }
                else
                {
                    //Se procede con la inserción
                    try
                    {
                        string insertaDepartamentoSql = "INSERT INTO municipios (nombre, codigo_departamento, codigo_cuenca) " +
                            " VALUES (@Nombre, @CodigoDepartamento, @CodigoCuenca)";
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
                        mensajeInsercion = $"Inserción del municipio {nombreMunicipio} se hizo para " +
                            $"el departamento {nombreDepartamento} en la cuenca {nombreCuenca}";
                    }
                }
            }            
            return resultadoInsercion;
        }

        /// <summary>
        /// Actualiza un municipio existente
        /// </summary>
        /// <param name="unMunicipio">Objeto municipio a actualizar</param>
        /// <param name="mensajeActualizacion">Resultado del proceso de actualización</param>
        /// <returns>verdadero si la actualización fue exitosa</returns>
        public static bool ActualizaMunicipio(Municipio unMunicipio, out string mensajeActualizacion)
        {
            mensajeActualizacion = string.Empty;
            bool resultadoActualizacion = false;

            //Aqui actualizamos los códigos de cuenca y departamento
            unMunicipio.CodigoCuenca = ObtieneCodigoCuenca(unMunicipio.NombreCuenca!);
            unMunicipio.CodigoDepartamento = ObtieneCodigoDepartamento(unMunicipio.NombreDepartamento!);

            int cantidadFilas = 0;
            cadenaConexion = ObtieneCadenaConexion();

            //Aqui validamos primero que el nuevo nombre del municipio no exista para ese departamento

            //Obtenemos el Objeto que representa este municipio
            Municipio otroMunicipio = ObtieneMunicipio(unMunicipio.Nombre!,
                unMunicipio.NombreCuenca!, unMunicipio.NombreDepartamento!);

            //Si el código del municipio es != 0, el municipio ya existe y no se puede insertar
            if (otroMunicipio.Codigo != 0 &&
                unMunicipio.CodigoCuenca == otroMunicipio.CodigoCuenca
                && unMunicipio.CodigoDepartamento == otroMunicipio.CodigoDepartamento)
            {
                resultadoActualizacion = false;
                mensajeActualizacion = $"No se hizo actualización porque ya existe un municipio" +
                    $"en el departamento {unMunicipio.NombreDepartamento} " +
                    $"para la cuenca {unMunicipio.NombreCuenca}";
            }
            else
            {
                using (IDbConnection cxnDB = new SQLiteConnection(cadenaConexion))
                {
                    try
                    {
                        string actualizaMunicipioSQL = "UPDATE municipios SET nombre = @Nombre, " +
                            "codigo_cuenca = @CodigoCuenca, " +
                            "codigo_departamento = @CodigoDepartamento " +
                            "WHERE codigo = @Codigo";

                        cantidadFilas = cxnDB.Execute(actualizaMunicipioSQL, unMunicipio);

                        if (cantidadFilas > 0)
                        {
                            resultadoActualizacion = true;
                            mensajeActualizacion = "Inserción Exitosa";
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

        /// <summary>
        /// Elimina un municipio existente
        /// </summary>
        /// <param name="codigoMunicipio">Codigo del municipio a eliminar</param>
        /// <param name="mensajeEliminacion">Resultado del proceso de eliminación</param>
        /// <returns>verdadero si la eliminación fue exitosa</returns>
        public static bool EliminaMunicipio(int codigoMunicipio, out string mensajeEliminacion)
        {
            mensajeEliminacion = string.Empty;
            bool resultadoEliminacion = false;

            int cantidadFilas = 0;
            cadenaConexion = ObtieneCadenaConexion();

            //Validaciones a realizar
            //1. Que el municipio exista
            //2. Que no tenga actividades de pesca asignadas

            Municipio unMunicipio = ObtieneMunicipio(codigoMunicipio);
            if (unMunicipio.Codigo == 0)
            {
                resultadoEliminacion = false;
                mensajeEliminacion = "No se encontró municipio con ese código";
            }
            else
            {
                //Ya que sabemos existe, validemos que no haya actividades de pesca asociadas
                int cantidadActividades = ObtieneCantidadActividadesPescaMunicipio(codigoMunicipio);

                if (cantidadActividades != 0)
                {
                    resultadoEliminacion = false;
                    mensajeEliminacion = $"No se pudo eliminar el municipio {unMunicipio.Nombre} " +
                        $"porque tiene asociadas {cantidadActividades} actividades de pesca";
                }
                else 
                {
                    //Ya que sabemos que no tiene actividades de pesca asociada, se puede borrar
                    using (IDbConnection cxnDB = new SQLiteConnection(cadenaConexion))
                    {
                        try
                        {
                            DynamicParameters parametrosSentencia = new DynamicParameters();
                            parametrosSentencia.Add("@codigo_municipio", codigoMunicipio,
                                DbType.Int32, ParameterDirection.Input);

                            string eliminaMunicipioSQL = "DELETE FROM municipios WHERE " +
                                "codigo = @codigo_municipio";

                            cantidadFilas = cxnDB.Execute(eliminaMunicipioSQL, parametrosSentencia);

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

        private static int ObtieneCantidadActividadesPescaMunicipio(int codigoMunicipio)
        {
            cadenaConexion = ObtieneCadenaConexion();

            using (IDbConnection cxnDB = new SQLiteConnection(cadenaConexion))
            {
                DynamicParameters parametrosSentencia = new DynamicParameters();
                parametrosSentencia.Add("@codigo_municipio", codigoMunicipio,
                    DbType.Int32, ParameterDirection.Input);

                int cantidadActividades = cxnDB.Query<int>("SELECT count(codigo) total FROM actividades " +
                "WHERE codigo_municipio = @codigo_municipio", parametrosSentencia).FirstOrDefault();

                return cantidadActividades;
            }
        }

        /// <summary>
        /// Obtiene el objeto municipio a partir del nombre, cuenca y departamento
        /// </summary>
        /// <param name="nombreMunicipio">nombre del municipio</param>
        /// <param name="nombreDepartamento">nombre del departamento</param>
        /// <param name="nombreCuenca">nombre de la cuenca</param>
        /// <returns></returns>
        private static Municipio ObtieneMunicipio(string nombreMunicipio, string nombreCuenca, string nombreDepartamento)
        {
            Municipio elMunicipio = new Municipio();

            elMunicipio.Nombre = nombreMunicipio;
            elMunicipio.NombreCuenca = nombreCuenca;
            elMunicipio.NombreDepartamento = nombreDepartamento;
            elMunicipio.Codigo = ObtieneCodigoMunicipio(nombreMunicipio, nombreDepartamento);
            elMunicipio.CodigoCuenca = ObtieneCodigoCuenca(nombreCuenca);
            elMunicipio.CodigoDepartamento = ObtieneCodigoDepartamento(nombreDepartamento);

            return elMunicipio;
        }

        /// <summary>
        /// Obtiene el objeto municipio a partir del código
        /// </summary>
        /// <param name="codigoMunicipio">Codigo del municipio</param>
        /// <returns></returns>
        public static Municipio ObtieneMunicipio(int codigoMunicipio)
        {
            cadenaConexion = ObtieneCadenaConexion();
            Municipio municipioResultado = new Municipio();

            using (IDbConnection cxnDB = new SQLiteConnection(cadenaConexion))
            {

                DynamicParameters parametrosSentencia = new DynamicParameters();
                parametrosSentencia.Add("@codigo_municipio", codigoMunicipio,
                    DbType.Int32, ParameterDirection.Input);

                string sentenciaSQL = "SELECT codigo_municipio Codigo, nombre_municipio Nombre, " +
                    "codigo_departamento CodigoDepartamento, nombre_departamento NombreDepartamento, " +
                    "codigo_cuenca CodigoCuenca, nombre_cuenca NombreCuenca FROM v_info_municipios " +
                    "WHERE codigo_municipio = @codigo_municipio";

                var salida = cxnDB.Query<Municipio>(sentenciaSQL, parametrosSentencia);

                //validamos cuantos registros devuelve la lista
                if (salida.ToArray().Length > 0 )
                    municipioResultado = salida.First();

                return municipioResultado;
            }

        }

        #endregion CRUD_Municipios

        #region CRUD_MetodosPesca

        #endregion CRUD_MetodosPesca

        #region CRUD_ActividadesPesca

        /// <summary>
        /// Obtiene La actividad de pesca asociada al código
        /// </summary>
        /// <param name="codigoActividad">El código de la actividad de pesca</param>
        /// <returns></returns>
        public static Actividad ObtieneActividad(int codigoActividad)
        {
            cadenaConexion = ObtieneCadenaConexion();
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

                return actividadResultado;
            }
        }

        /// <summary>
        /// Inserta una nueva actividad
        /// </summary>
        /// <param name="nuevaActividad">Actividad a insertar</param>
        /// <param name="mensajeInsercion">Resultado del proceso de inserción</param>
        /// <returns>verdadero si la inserción fue exitosa</returns>
        public static bool InsertaNuevaActividad(Actividad nuevaActividad,
                        out string mensajeInsercion)
        {
            mensajeInsercion = string.Empty;
            bool resultadoInsercion = false;

            int cantidadFilas = 0;
            cadenaConexion = ObtieneCadenaConexion();

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

        /// <summary>
        /// Actualiza una actividad existente
        /// </summary>
        /// <param name="unaActividad">Objeto actividad a actualizar</param>
        /// <param name="mensajeActualizacion">Resultado del proceso de actualización</param>
        /// <returns>verdadero si la actualización fue exitosa</returns>
        public static bool ActualizaActividad(Actividad unaActividad, out string mensajeActualizacion)
        {
            mensajeActualizacion = string.Empty;
            bool resultadoActualizacion = false;

            int cantidadFilas = 0;
            cadenaConexion = ObtieneCadenaConexion();

            //Aqui validamos primero que la actividad a actualizar ya exista

            //Obtenemos el Objeto que representa este municipio
            Actividad otraActividad = ObtieneActividad(unaActividad.Codigo);

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
                            mensajeActualizacion = "Inserción Exitosa";
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

        /// <summary>
        /// Elimina una actividad existente
        /// </summary>
        /// <param name="codigoActividad">Codigo de la actividad a eliminar</param>
        /// <param name="mensajeEliminacion">Resultado del proceso de eliminación</param>
        /// <returns>verdadero si la eliminación fue exitosa</returns>
        public static bool EliminaActividad(int codigoActividad, out string mensajeEliminacion)
        {
            mensajeEliminacion = string.Empty;
            bool resultadoEliminacion = false;

            int cantidadFilas = 0;
            cadenaConexion = ObtieneCadenaConexion();

            //Validaciones a realizar
            //1. Que la actividad exista

            Actividad unaActividad = ObtieneActividad(codigoActividad);
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

        #endregion CRUD_ActividadesPesca
    }
}
