using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Data;

namespace PescaArtesanal_PoC_NoSQL_Console
{
    public class AccesoDatos
    {
        static PescaArtesanalDatabaseSettings configDB = ObtenerDBSettings();

        public static PescaArtesanalDatabaseSettings ObtenerDBSettings()
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            IConfiguration miConfiguracion = builder.Build();

            PescaArtesanalDatabaseSettings miConfigDB = new PescaArtesanalDatabaseSettings()
            {
                ConnectionString = miConfiguracion["PescaArtesanalDatabase:ConnectionString"]!,
                DatabaseName = miConfiguracion["PescaArtesanalDatabase:DatabaseName"]!,
                DepartamentosCollectionName = miConfiguracion["PescaArtesanalDatabase:DepartamentosCollectionName"]!
            };

            return miConfigDB;
        }

        #region CRUD_Departamentos

        public static List<Departamento> ObtenerListaDepartamentos()
        {
            var clienteDB = new MongoClient(configDB.ConnectionString);
            var miDB = clienteDB.GetDatabase(configDB.DatabaseName);
            var coleccionDepartamentos = configDB.DepartamentosCollectionName;

            var lista = miDB.GetCollection<Departamento>(coleccionDepartamentos)
                .Find(new BsonDocument())
                .SortBy(depto => depto.Nombre)
                .ToList();

            return lista;
        }

        #endregion CRUD_Departamentos
    }
}
