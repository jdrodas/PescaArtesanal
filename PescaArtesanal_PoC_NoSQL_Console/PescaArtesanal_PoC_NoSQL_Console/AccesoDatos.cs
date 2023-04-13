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
                DepartamentosCollectionName = miConfiguracion["PescaArtesanalDatabase:DepartamentosCollectionName"]!,
                MunicipiosCollectionName = miConfiguracion["PescaArtesanalDatabase:MunicipiosCollectionName"]!,
                CuencasCollectionName = miConfiguracion["PescaArtesanalDatabase:CuencasCollectionName"]!
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

        #region CRUD_Municipios

        public static List<Municipio> ObtenerListaMunicipios(string nombreDepartamento)
        {
            var clienteDB = new MongoClient(configDB.ConnectionString);
            var miDB = clienteDB.GetDatabase(configDB.DatabaseName);
            var coleccionMunicipios = configDB.MunicipiosCollectionName;
            var filtroDepartamento = new BsonDocument { { "nombre_departamento", nombreDepartamento } };

            var lista = miDB.GetCollection<Municipio>(coleccionMunicipios)
                .Find(filtroDepartamento)
                .SortBy(mpio => mpio.Nombre)
                .ToList();

            return lista;
        }

        #endregion CRUD_Municipios

        #region CRUD_Cuencas

        public static string ObtenerIdCuenca(string nombreCuenca)
        {
            
            var clienteDB = new MongoClient(configDB.ConnectionString);
            var miDB = clienteDB.GetDatabase(configDB.DatabaseName);
            var coleccionCuencas = configDB.CuencasCollectionName;
            var filtroCuenca = new BsonDocument { { "nombre", nombreCuenca } };

            Cuenca cuencaEncontrada = miDB.GetCollection<Cuenca>(coleccionCuencas)
                .Find(filtroCuenca)
                .First();

            return cuencaEncontrada.Id!;
        }

        public static List<Cuenca> ObtenerListaCuencas()
        {
            var clienteDB = new MongoClient(configDB.ConnectionString);
            var miDB = clienteDB.GetDatabase(configDB.DatabaseName);
            var coleccionCuencas = configDB.CuencasCollectionName;

            var lista = miDB.GetCollection<Cuenca>(coleccionCuencas)
                .Find(new BsonDocument())
                .SortBy(depto => depto.Nombre)
                .ToList();

            return lista;
        }

        public static bool ActualizarCuenca(Cuenca unaCuenca)
        {
            var clienteDB = new MongoClient(configDB.ConnectionString);
            var miDB = clienteDB.GetDatabase(configDB.DatabaseName);
            var coleccionCuencas = configDB.CuencasCollectionName;

            var miColeccion = miDB.GetCollection<Cuenca>(coleccionCuencas);
            var resultadoActualizacion = miColeccion.ReplaceOne(documento => documento.Codigo == unaCuenca.Codigo, 
                unaCuenca);

            return resultadoActualizacion.IsAcknowledged;
        }

        public static bool EliminarCuenca(Cuenca unaCuenca)
        {
            var clienteDB = new MongoClient(configDB.ConnectionString);
            var miDB = clienteDB.GetDatabase(configDB.DatabaseName);
            var coleccionCuencas = configDB.CuencasCollectionName;

            var miColeccion = miDB.GetCollection<Cuenca>(coleccionCuencas);
            var resultadoEliminacion = miColeccion.DeleteOne(documento => documento.Codigo == unaCuenca.Codigo);

            return resultadoEliminacion.IsAcknowledged;
        }

        public static bool InsertarCuenca(Cuenca unaCuenca)
        {
            var clienteDB = new MongoClient(configDB.ConnectionString);
            var miDB = clienteDB.GetDatabase(configDB.DatabaseName);
            var coleccionCuencas = configDB.CuencasCollectionName;

            var miColeccion = miDB.GetCollection<Cuenca>(coleccionCuencas);
            miColeccion.InsertOne(unaCuenca);

            //Necesitamos corroborar que la inserción fue exitosa
            string? idCuenca = ObtenerIdCuenca(unaCuenca.Nombre);

            if (string.IsNullOrEmpty(idCuenca))
                return false;
            else
                return true;

        }

        #endregion CRUD_Cuencas
    }
}
