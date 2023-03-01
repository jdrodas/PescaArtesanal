using System;
using System.IO;
using System.Data;
using System.Data.SQLite;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Dapper;

namespace PescaArtesanal_PoC_Console
{
    public class Program
    {
        /// <summary>
        /// Obtiene la cadena de conexión para utilizar en las operaciones CRUD
        /// </summary>
        /// <returns>string con la cadena de conexión</returns>
        static string? ObtieneCadenaConexion()
        {
            //Parametrizamos el acceso al archivo de configuración appsettings.json
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            IConfiguration miConfiguracion = builder.Build();

            return miConfiguracion["ConnectionString:Sqlite"];
        }

        /// <summary>
        /// Obtiene la lista con los nombres de los departamentos
        /// </summary>
        /// <returns>lista de strings con los nombres de los departamentos</returns>
        static List<string> ObtieneNombresDepartamentos()
        {
            string? cadenaConexion = ObtieneCadenaConexion();

            using (IDbConnection cxnDB = new SQLiteConnection(cadenaConexion))
            {
                var resultadoDepartamentos = cxnDB.Query<string>("SELECT DISTINCT nombre FROM departamentos ORDER BY nombre", new DynamicParameters());

                return resultadoDepartamentos.AsList();
            }
        }

        /// <summary>
        /// Obtiene Los municipios asociados a un departamento
        /// </summary>
        /// <param name="nombreDepartamento">El nombre del departamento</param>
        /// <returns>Lista de objetos del tipo Municipio</returns>
        static List<Municipio> ObtieneMunicipiosDepartamento(string nombreDepartamento)
        {
            string? cadenaConexion = ObtieneCadenaConexion();

            using (IDbConnection cxnDB = new SQLiteConnection(cadenaConexion))
            {
                DynamicParameters parametrosSentencia = new DynamicParameters();
                parametrosSentencia.Add("@nombre_departamento", nombreDepartamento,
                    DbType.String, ParameterDirection.Input);

                string? sentenciaSQL = "SELECT m.codigo, m.nombre, m.codigo_departamento, " +
                    "m.codigo_cuenca, d.nombre nombre_departamento, c.nombre nombre_cuenca " +
                    "FROM municipios m JOIN cuencas c ON m.codigo_cuenca = c.codigo " +
                    "JOIN departamentos d ON m.codigo_departamento = d.codigo " +
                    "WHERE d.nombre = @nombre_departamento";

                var resultadoMunicipios = cxnDB.Query<Municipio>(sentenciaSQL, parametrosSentencia);

                return resultadoMunicipios.AsList();
            }
        }
                
        static void Main(string[] args)
        {
            Console.WriteLine("PoC CRUD con SQLite y Dapper");

            string? cadenaConexion = ObtieneCadenaConexion();
            Console.WriteLine($"El string de conexión obtenido es : {cadenaConexion}\n");

            //Aqui demostramos una consulta a una tabla devolviendo una lista de strings
            Console.WriteLine($"Departamentos registrados en la DB:");
            List<string> losDepartamentos = ObtieneNombresDepartamentos();

            if (losDepartamentos.Count == 0)
                Console.WriteLine("No se encontraron Departamentos registrados");
            else
            {
                Console.WriteLine($"\nSe encontraron {losDepartamentos.Count} departamentos");

                foreach (string departamento in losDepartamentos)
                    Console.WriteLine($"- {departamento}");
            }

            //Aqui demostramos una consulta mapeada a un objeto:
            string miDepartamento = "Antioquia";
            Console.WriteLine($"\nInformación de los municipios de {miDepartamento}:");

            List<Municipio> losMunicipios = ObtieneMunicipiosDepartamento(miDepartamento);

            if (losMunicipios.Count == 0)
                Console.WriteLine($"No se encontraron municipios registrados para {miDepartamento}");
            else
            {
                Console.WriteLine($"\nSe encontraron {losMunicipios.Count} municipios");

                foreach (Municipio unMunicipio in losMunicipios)
                    Console.WriteLine($"\nMunicipio: {unMunicipio.Nombre} " +
                        $"\nCuenca: {unMunicipio.Nombre_Cuenca}");
            }
        }
    }
}