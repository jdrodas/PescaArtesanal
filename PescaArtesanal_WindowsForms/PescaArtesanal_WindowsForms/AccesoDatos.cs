using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SQLite;
using Dapper;
using System.Configuration;

namespace PescaArtesanal_WindowsForms
{
    public class AccesoDatos
    {
        /// <summary>
        /// Obtiene la cadena de conexión a la DB a partir del archivo de configuración de la App
        /// </summary>
        private static string ObtenerCadenaConexion(string id)
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }

        #region CRUD de Departamentos

        /// <summary>
        /// Obtiene una lista con los nombres de los Departamentos
        /// </summary>
        public static List<string> ObtieneListaNombreDepartamentos()
        {
            string cadenaConexion = ObtenerCadenaConexion("PescasDB");

            using (IDbConnection cxnDB = new SQLiteConnection(cadenaConexion))
            {
                var salida = cxnDB.Query<string>("SELECT DISTINCT nombre FROM departamentos ORDER BY nombre", new DynamicParameters());
                return salida.ToList();
            }
        }

        #endregion CRUD de Departamentos

        #region CRUD de Municipios

        /// <summary>
        /// Obtiene una lista con los nombres de los Municipios
        /// </summary>
        public static List<string> ObtieneListaNombreMuincipios()
        {
            string cadenaConexion = ObtenerCadenaConexion("PescasDB");

            using (IDbConnection cxnDB = new SQLiteConnection(cadenaConexion))
            {
                var salida = cxnDB.Query<string>("SELECT DISTINCT nombre FROM municipios ORDER BY nombre", new DynamicParameters());
                return salida.ToList();
            }
        }

        #endregion CRUD de Municipios

    }
}
