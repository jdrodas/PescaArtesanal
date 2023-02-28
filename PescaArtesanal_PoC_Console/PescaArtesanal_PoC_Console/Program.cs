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
        static void Main(string[] args)
        {
            Console.WriteLine("PoC CRUD con SQLite y Dapper");

            //Parametrizamos el acceso al archivo de configuración appsettings.json
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());   
            builder.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            IConfiguration miConfiguracion = builder.Build();

            string? cadenaConexion = miConfiguracion["ConnectionString:Sqlite"];

            Console.WriteLine($"El string de conexión obtenido es : {cadenaConexion}");

            using (IDbConnection cxnDB = new SQLiteConnection(cadenaConexion))
            {
                var salida = cxnDB.Query<string>("SELECT DISTINCT nombre FROM departamentos ORDER BY nombre", new DynamicParameters());
                List<string> nombresDepartamentos = salida.AsList();

                if (nombresDepartamentos.Count == 0)
                    Console.WriteLine("No se encontraron Departamentos registrados");
                else
                {
                    Console.WriteLine("\nLos departamentos registrados son:");

                    foreach (string departamento in nombresDepartamentos)
                        Console.WriteLine($"- {departamento}");
                }

                //Aqui demostramos una consulta mapeada a un objeto:
                Console.WriteLine("\nInformación de los municipios de Antioquia:");

                string miDepartamento = "Antioquia";

                DynamicParameters parametrosSentencia = new DynamicParameters();
                parametrosSentencia.Add("@nombre_departamento", miDepartamento, 
                    DbType.String, ParameterDirection.Input);

                string? sentenciaSQL = "SELECT m.codigo, m.nombre, m.codigo_departamento, " +
                    "m.codigo_cuenca, d.nombre nombre_departamento, c.nombre nombre_cuenca " +
                    "FROM municipios m JOIN cuencas c ON m.codigo_cuenca = c.codigo " +
                    "JOIN departamentos d ON m.codigo_departamento = d.codigo " +
                    "WHERE d.nombre = @nombre_departamento";

                var salidaMunicipios = cxnDB.Query<Municipio>(sentenciaSQL, parametrosSentencia);

                List<Municipio> losMunicipios = salidaMunicipios.AsList();

                if (losMunicipios.Count == 0)
                    Console.WriteLine($"No se encontraron municipios registrados para {miDepartamento}");
                else
                {
                    foreach (Municipio unMunicipio in losMunicipios)
                        Console.WriteLine($"\nMunicipio: {unMunicipio.Nombre} " +
                            $"\nCuenca: {unMunicipio.Nombre_Cuenca}");                    
                }
            }
        }
    }
}