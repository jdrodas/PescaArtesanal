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
        public static List<string> ObtieneNombresDepartamentos()
        {
            cadenaConexion = ObtieneCadenaConexion();

            using (IDbConnection cxnDB = new SQLiteConnection(cadenaConexion))
            {
                var resultadoDepartamentos = cxnDB.Query<string>("SELECT DISTINCT nombre FROM departamentos ORDER BY nombre", new DynamicParameters());

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
        public static List<string> ObtieneNombresCuencas()
        {
            string? cadenaConexion = ObtieneCadenaConexion();

            using (IDbConnection cxnDB = new SQLiteConnection(cadenaConexion))
            {
                var resultadoCuencas = cxnDB.Query<string>("SELECT DISTINCT nombre FROM cuencas ORDER BY nombre", new DynamicParameters());

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

        #endregion CRUD_Municipios

        #region CRUD_MetodosPesca

        #endregion CRUD_MetodosPesca

        #region CRUD_ActividadesPesca

        #endregion CRUD_ActividadesPesca
    }
}
