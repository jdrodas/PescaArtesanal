using System;
using System.IO;
using System.Data;
using System.Data.SQLite;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Dapper;
using System.ComponentModel.Design;
using System.Linq;

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
            builder.SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            
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

        static List<string> ObtieneNombresCuencas()
        {
            string? cadenaConexion = ObtieneCadenaConexion();

            using (IDbConnection cxnDB = new SQLiteConnection(cadenaConexion))
            {
                var resultadoCuencas = cxnDB.Query<string>("SELECT DISTINCT nombre FROM cuencas ORDER BY nombre", new DynamicParameters());

                return resultadoCuencas.AsList();
            }
        }

        static List<Cuenca> ObtieneCuencas()
        {
            string? cadenaConexion = ObtieneCadenaConexion();

            using (IDbConnection cxnDB = new SQLiteConnection(cadenaConexion))
            {
                var resultadoCuencas = cxnDB.Query<Cuenca>("SELECT DISTINCT codigo, nombre FROM cuencas ORDER BY nombre DESC", new DynamicParameters());

                return resultadoCuencas.AsList();
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

                string? sentenciaSql = "SELECT m.codigo, m.nombre, m.codigo_departamento codigoDepartamento, " +
                    "m.codigo_cuenca codigoCuenca, d.nombre nombreDepartamento, c.nombre nombreCuenca " +
                    "FROM municipios m JOIN cuencas c ON m.codigo_cuenca = c.codigo " +
                    "JOIN departamentos d ON m.codigo_departamento = d.codigo " +
                    "WHERE d.nombre = @nombre_departamento";

                var resultadoMunicipios = cxnDB.Query<Municipio>(sentenciaSql, parametrosSentencia);

                return resultadoMunicipios.AsList();
            }
        }

        /// <summary>
        /// Inserta un nuevo registro para los departamentos
        /// </summary>
        /// <param name="nombreDepartamento">nombre del departamento</param>
        /// <returns>verdadero si la inserción fue exitosa</returns>
        static bool InsertaDepartamento(string nombreDepartamento)
        {
            int cantidadFilas = 0;
            bool resultado = false;
            string? cadenaConexion = ObtieneCadenaConexion();

            //Aqui validamos primero que el nombre del departamento no exista
            using (IDbConnection cxnDB = new SQLiteConnection(cadenaConexion))
            {
                DynamicParameters parametrosSentencia = new DynamicParameters();
                parametrosSentencia.Add("@nombre_departamento", nombreDepartamento,
                    DbType.String, ParameterDirection.Input);

                string consultaDepartamentoSql = "SELECT COUNT(codigo) total FROM departamentos " +
                    "WHERE nombre = @nombre_departamento";

                cantidadFilas = cxnDB.Query<int>(consultaDepartamentoSql, parametrosSentencia).FirstOrDefault();

                //Si no hay filas, se puede insertar nuevo registro
                if (cantidadFilas == 0)
                {
                    try
                    {
                        string insertaDepartamentoSql = "INSERT INTO departamentos (nombre) VALUES (@nombre_departamento)";
                        cantidadFilas = cxnDB.Execute(insertaDepartamentoSql, parametrosSentencia);
                    }
                    catch (SQLiteException)
                    {
                        resultado = false;
                        cantidadFilas = 0;
                    }

                    //Si la inserción fue correcta, devolvemos true
                    if (cantidadFilas > 0)
                        resultado = true;
                }
            }

            return resultado;
        }

        static bool InsertaCuenca(string nombreCuenca)
        {
            int cantidadFilas = 0;
            bool resultado = false;
            string? cadenaConexion = ObtieneCadenaConexion();

            //Aqui validamos primero que el nombre del departamento no exista
            using (IDbConnection cxnDB = new SQLiteConnection(cadenaConexion))
            {
                DynamicParameters parametrosSentencia = new DynamicParameters();
                parametrosSentencia.Add("@nombre_cuenca", nombreCuenca,
                    DbType.String, ParameterDirection.Input);

                string consultaCuencaSql = "SELECT COUNT(codigo) total FROM cuencas " +
                    "WHERE nombre = @nombre_cuenca";

                cantidadFilas = cxnDB.Query<int>(consultaCuencaSql, parametrosSentencia).FirstOrDefault();

                //Si no hay filas, se puede insertar nuevo registro
                if (cantidadFilas == 0)
                {
                    try
                    {
                        string insertaCuencaSql = "INSERT INTO cuencas (nombre) VALUES (@nombre_cuenca)";
                        cantidadFilas = cxnDB.Execute(insertaCuencaSql, parametrosSentencia);
                    }
                    catch (SQLiteException)
                    {
                        resultado = false;
                        cantidadFilas = 0;
                    }

                    //Si la inserción fue correcta, devolvemos true
                    if (cantidadFilas > 0)
                        resultado = true;
                }
            }

            return resultado;
        }

        /// <summary>
        /// Actualiza el nombre de un departamento
        /// </summary>
        /// <param name="nombreDepartamento">Nombre del Departamento a actualizar</param>
        /// <param name="nuevoNombreDepartamento">nuevo nombre a asignar</param>
        /// <returns>verdadero si la operación fue exitosa</returns>
        static bool ActualizaNombreDepartamento(string nombreDepartamento, string nuevoNombreDepartamento)
        {
            int cantidadFilas = 0;
            bool resultado = false;
            string? cadenaConexion = ObtieneCadenaConexion();

            //Aqui validamos primero que el nombre previo del departamento exista
            using (IDbConnection cxnDB = new SQLiteConnection(cadenaConexion))
            {
                DynamicParameters parametrosSentencia = new DynamicParameters();
                parametrosSentencia.Add("@nombre_departamento", nombreDepartamento,
                    DbType.String, ParameterDirection.Input);
                parametrosSentencia.Add("@nuevo_nombre_departamento", nuevoNombreDepartamento,
                    DbType.String, ParameterDirection.Input);

                string consultaDepartamentoSql = "SELECT COUNT(codigo) total FROM departamentos " +
                    "WHERE nombre = @nombre_departamento";

                cantidadFilas = cxnDB.Query<int>(consultaDepartamentoSql, parametrosSentencia).FirstOrDefault();

                //Si no hay filas, no existe departamento que actualizar
                if (cantidadFilas == 0)
                    return false;
                else
                {
                    //Validamos si el nuevo nombre no exista
                    consultaDepartamentoSql = "SELECT COUNT(codigo) total FROM departamentos " +
                    "WHERE nombre = @nuevo_nombre_departamento";

                    cantidadFilas = cxnDB.Query<int>(consultaDepartamentoSql, parametrosSentencia).FirstOrDefault();

                    //Si hay filas, el nuevo nombre a utilizar ya existe!
                    if (cantidadFilas != 0)
                        return false;
                    else
                    {
                        try
                        {
                            string actualizaDepartamentoSql = "UPDATE departamentos SET nombre = @nuevo_nombre_departamento " +
                                "WHERE nombre = @nombre_departamento"; ;

                            cantidadFilas = cxnDB.Execute(actualizaDepartamentoSql, parametrosSentencia);
                        }
                        catch (SQLiteException)
                        {
                            resultado = false;
                            cantidadFilas = 0;
                        }

                        //Si la actualización fue correcta, devolvemos true
                        if (cantidadFilas > 0)
                            resultado = true;
                    }
                }
            }

            return resultado;
        }

        static bool ActualizaNombreCuenca(string nombreCuenca, string nuevoNombreCuenca)
        {
            int cantidadFilas = 0;
            bool resultado = false;
            string? cadenaConexion = ObtieneCadenaConexion();

            //Aqui validamos primero que el nombre previo del departamento exista
            using (IDbConnection cxnDB = new SQLiteConnection(cadenaConexion))
            {
                DynamicParameters parametrosSentencia = new DynamicParameters();
                parametrosSentencia.Add("@nombre_cuenca", nombreCuenca,
                    DbType.String, ParameterDirection.Input);
                parametrosSentencia.Add("@nuevo_nombre_cuenca", nuevoNombreCuenca,
                    DbType.String, ParameterDirection.Input);

                string consultaCuencaSql = "SELECT COUNT(codigo) total FROM cuencas " +
                    "WHERE nombre = @nombre_cuenca";

                cantidadFilas = cxnDB.Query<int>(consultaCuencaSql, parametrosSentencia).FirstOrDefault();

                //Si no hay filas, no existe departamento que actualizar
                if (cantidadFilas == 0)
                    return false;
                else
                {
                    //Validamos si el nuevo nombre no exista
                    consultaCuencaSql = "SELECT COUNT(codigo) total FROM cuencas " +
                    "WHERE nombre = @nuevo_nombre_cuenca";

                    cantidadFilas = cxnDB.Query<int>(consultaCuencaSql, parametrosSentencia).FirstOrDefault();

                    //Si hay filas, el nuevo nombre a utilizar ya existe!
                    if (cantidadFilas != 0)
                        return false;
                    else
                    {
                        try
                        {
                            string actualizaCuencaSql = "UPDATE cuencas SET nombre = @nuevo_nombre_cuenca " +
                                "WHERE nombre = @nombre_cuenca";

                            cantidadFilas = cxnDB.Execute(actualizaCuencaSql, parametrosSentencia);
                        }
                        catch (SQLiteException)
                        {
                            resultado = false;
                            cantidadFilas = 0;
                        }

                        //Si la actualización fue correcta, devolvemos true
                        if (cantidadFilas > 0)
                            resultado = true;
                    }
                }
            }

            return resultado;
        }

        /// <summary>
        /// Borra un registro de departamento a partir de su nombre
        /// </summary>
        /// <param name="nombreDepartamento">El departamento a borrar</param>
        /// <returns>verdadero si la operación fue exitosa</returns>
        static bool BorraDepartamento(string nombreDepartamento)
        {
            int cantidadFilas = 0;
            bool resultado = false;
            string? cadenaConexion = ObtieneCadenaConexion();

            //Aqui validamos primero que el departamento exista
            using (IDbConnection cxnDB = new SQLiteConnection(cadenaConexion))
            {
                DynamicParameters parametrosSentencia = new DynamicParameters();
                parametrosSentencia.Add("@nombre_departamento", nombreDepartamento,
                    DbType.String, ParameterDirection.Input);

                string consultaDepartamentoSql = "SELECT COUNT(codigo) total FROM departamentos " +
                    "WHERE nombre = @nombre_departamento";

                cantidadFilas = cxnDB.Query<int>(consultaDepartamentoSql, parametrosSentencia).FirstOrDefault();

                //Si no hay filas, no existe departamento que se va a borrar
                if (cantidadFilas == 0)
                    return false;
                else
                {
                    try
                    {
                        string borraDepartamentoSql = "DELETE FROM departamentos " +
                            "WHERE nombre = @nombre_departamento"; ;

                        cantidadFilas = cxnDB.Execute(borraDepartamentoSql, parametrosSentencia);
                    }
                    catch (SQLiteException)
                    {
                        resultado = false;
                        cantidadFilas = 0;
                    }

                    //Si el borrado fue correcto, devolvemos true
                    if (cantidadFilas > 0)
                        resultado = true;
                }
            }
            
            return resultado;
        }

        /// <summary>
        /// Visualiza los nombres de los departamentos registrados en la DB
        /// </summary>
        static void VisualizaDepartamentos()
        {
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
        }

        static void VisualizaCuencas()
        {
            Console.WriteLine($"Cuencas registrados en la DB:");
            List<Cuenca> lasCuencas = ObtieneCuencas();

            if (lasCuencas.Count == 0)
                Console.WriteLine("No se encontraron cuencas registrados");
            else
            {
                Console.WriteLine($"\nSe encontraron {lasCuencas.Count} cuencas");

                foreach (Cuenca unaCuenca in lasCuencas)
                    Console.WriteLine($"Código: {unaCuenca.Codigo}, Nombre: {unaCuenca.Nombre}");
            }
        }
        
        /// <summary>
        /// Función Principal
        /// </summary>
        static void Main(string[] args)
        {
            Console.WriteLine("PoC CRUD con SQLite y Dapper");

            string? cadenaConexion = ObtieneCadenaConexion();
            Console.WriteLine($"El string de conexión obtenido es : {cadenaConexion}");

            //Aqui demostramos una consulta a una tabla devolviendo una lista de strings
            Console.WriteLine("\n*** Sentencias de Consulta ***");
            VisualizaDepartamentos();

            //Aqui demostramos una consulta mapeada a un objeto:
            string miDepartamento = "Bolívar";
            Console.WriteLine($"\nInformación de los municipios de {miDepartamento}:");

            List<Municipio> losMunicipios = ObtieneMunicipiosDepartamento(miDepartamento);

            if (losMunicipios.Count == 0)
                Console.WriteLine($"No se encontraron municipios registrados para {miDepartamento}");
            else
            {
                Console.WriteLine($"\nSe encontraron {losMunicipios.Count} municipios");

                foreach (Municipio unMunicipio in losMunicipios)
                    Console.WriteLine($"\nMunicipio: {unMunicipio.Nombre} " +
                        $"\nCuenca: {unMunicipio.NombreCuenca}");
            }

            //Aqui demostramos una inserción
            Console.WriteLine("\n*** Sentencias de Inserción ***");
            string nuevoDepartamento = "Risaralda";
            Console.WriteLine($"\nRegistro de nuevo departamento: {nuevoDepartamento}:");

            bool resultadoInsercion = InsertaDepartamento(nuevoDepartamento);

            if (!resultadoInsercion)
                Console.WriteLine($"No fue posible insertar nuevo departamento. Ya existe {nuevoDepartamento}");
            else
            {
                Console.WriteLine($"\nInserción exitosa para el departamento: {nuevoDepartamento}");
                VisualizaDepartamentos();
            }

            //Aqui demostramos una actualización
            Console.WriteLine("\n*** Sentencias de Actualización ***");
            string nuevoNombreDepartamento = "Gran Risaralda";

            bool resultadoActualizacion = ActualizaNombreDepartamento(nuevoDepartamento, nuevoNombreDepartamento);

            if(!resultadoActualizacion)
                Console.WriteLine($"No fue posible actualizar el nombre del departamento. Ya existe registro para {nuevoNombreDepartamento}");
            else
            {
                Console.WriteLine($"\nActualización exitosa. Ahora se llama {nuevoNombreDepartamento}");
                VisualizaDepartamentos();
            }

            //Aqui demostramos un borrado
            Console.WriteLine("\n*** Sentencias de Borrado ***");

            bool resultadoBorrado = BorraDepartamento(nuevoNombreDepartamento);

            if (!resultadoBorrado)
                Console.WriteLine($"No fue posible borrar el departamento. {nuevoNombreDepartamento}");
            else
            {
                Console.WriteLine($"\nBorrado exitoso. Eliminado departamento {nuevoNombreDepartamento}");
                VisualizaDepartamentos();
            }


            //******* Operaciones CRUD para las cuencas *********************

            //Demostración de la consulta (R)
            Console.WriteLine("\n\nDemostración de CRUD con cuencas");
            VisualizaCuencas();

            //Demostración de la inserción (C)
            Console.WriteLine("\n\nInserción de una Cuenca");
            string nombreCuenca = "Orinoco";

            resultadoInsercion = InsertaCuenca(nombreCuenca);

            if (!resultadoInsercion)
            {
                Console.WriteLine($"Fallo en inserción de cuenca para {nombreCuenca}. Ya existe!");
            }
            else
            {
                Console.WriteLine($"Inserción exitosa para {nombreCuenca}");
                VisualizaCuencas();
            }

            //Demostración de la actualización (U)
            Console.WriteLine("\n\nActualización de una Cuenca");
            string nuevoNombreCuenca = "Atrato";

            resultadoActualizacion = ActualizaNombreCuenca(nombreCuenca, nuevoNombreCuenca);

            if (!resultadoActualizacion)
            {
                Console.WriteLine($"Fallo en actualización de cuenca para {nombreCuenca}.\n" +
                    $"Los datos ingresados no funcionaron");
            }
            else
            {
                Console.WriteLine($"actualización exitosa para {nombreCuenca}. \n" +
                    $"Ahora se llama {nuevoNombreCuenca}");
                VisualizaCuencas();
            }



        }
    }
}