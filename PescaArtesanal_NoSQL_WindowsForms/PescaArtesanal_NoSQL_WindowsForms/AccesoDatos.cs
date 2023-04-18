using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using PescaArtesanal_NoSQL_WindowsForms.Modelos;

namespace PescaArtesanal_NoSQL_WindowsForms
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
                CuencasCollectionName = miConfiguracion["PescaArtesanalDatabase:CuencasCollectionName"]!,
                MetodosCollectionName = miConfiguracion["PescaArtesanalDatabase:MetodosCollectionName"]!,
                ActividadesCollectionName = miConfiguracion["PescaArtesanalDatabase:ActividadesCollectionName"]!
            };

            return miConfigDB;
        }

        #region CRUD Municipios

        public static string ObtenerIdMunicipio(string nombreMunicipio)
        {

            var clienteDB = new MongoClient(configDB.ConnectionString);
            var miDB = clienteDB.GetDatabase(configDB.DatabaseName);
            var coleccionMunicipios = configDB.MunicipiosCollectionName;
            var filtroMunicipio = new BsonDocument { { "nombre_municipio", nombreMunicipio } };

            Municipio municipioEncontrado = miDB.GetCollection<Municipio>(coleccionMunicipios)
                .Find(filtroMunicipio)
                .First();

            return municipioEncontrado.Id!;
        }

        public static Municipio ObtenerMunicipio(string idMunicipio)
        {

            var clienteDB = new MongoClient(configDB.ConnectionString);
            var miDB = clienteDB.GetDatabase(configDB.DatabaseName);
            var coleccionMunicipios = configDB.MunicipiosCollectionName;
            var filtroMunicipio = new BsonDocument { { "_id", idMunicipio } };

            Municipio municipioEncontrado = miDB.GetCollection<Municipio>(coleccionMunicipios)
                .Find(filtroMunicipio)
                .First();

            return municipioEncontrado;
        }

        public static List<Municipio> ObtenerListaMunicipiosDepartamento(string nombreDepartamento)
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

        public static List<string> ObtenerListaNombresMunicipios()
        {
            var clienteDB = new MongoClient(configDB.ConnectionString);
            var miDB = clienteDB.GetDatabase(configDB.DatabaseName);
            var coleccionMunicipios = configDB.MunicipiosCollectionName;

            var listaMunicipios = miDB.GetCollection<Municipio>(coleccionMunicipios)
                .Find(new BsonDocument())
                .SortBy(mpio => mpio.Nombre)
                .ToList();

            List<string> listaNombres = new List<string>();

            foreach (Municipio unMunicipio in listaMunicipios)
                listaNombres.Add(unMunicipio.Nombre);

            return listaNombres;
        }

        public static bool InsertarMunicipio(Municipio unMunicipio)
        {
            var clienteDB = new MongoClient(configDB.ConnectionString);
            var miDB = clienteDB.GetDatabase(configDB.DatabaseName);
            var coleccionMunicipios = configDB.MunicipiosCollectionName;

            var miColeccion = miDB.GetCollection<Municipio>(coleccionMunicipios);
            miColeccion.InsertOne(unMunicipio);

            //Necesitamos corroborar que la inserción fue exitosa
            string? idMunicipio = ObtenerIdMunicipio(unMunicipio.Nombre);

            if (string.IsNullOrEmpty(idMunicipio))
                return false;
            else
                return true;
        }

        public static bool ActualizarMunicipio(Municipio unMunicipio)
        {
            var clienteDB = new MongoClient(configDB.ConnectionString);
            var miDB = clienteDB.GetDatabase(configDB.DatabaseName);
            var coleccionMunicipios = configDB.MunicipiosCollectionName;

            var miColeccion = miDB.GetCollection<Municipio>(coleccionMunicipios);
            var resultadoActualizacion = miColeccion.ReplaceOne(documento => documento.Codigo == unMunicipio.Codigo,
                unMunicipio);

            return resultadoActualizacion.IsAcknowledged;
        }

        public static bool EliminarMunicipio(Municipio unMunicipio, out string mensajeEliminacion)
        {
            mensajeEliminacion = string.Empty;
            var clienteDB = new MongoClient(configDB.ConnectionString);
            var miDB = clienteDB.GetDatabase(configDB.DatabaseName);
            var coleccionMunicipios = configDB.MunicipiosCollectionName;

            var miColeccion = miDB.GetCollection<Municipio>(coleccionMunicipios);
            var resultadoEliminacion = miColeccion.DeleteOne(documento => documento.Codigo == unMunicipio.Codigo);

            if (!resultadoEliminacion.IsAcknowledged)
                mensajeEliminacion = $"Error al elimininar el municipio {unMunicipio.Nombre} " +
                    $"del departamento {unMunicipio.NombreDepartamento}";
            else
                mensajeEliminacion = $"El municipio {unMunicipio.Nombre} fue eliminado";

            return resultadoEliminacion.IsAcknowledged;
        }

        #endregion CRUD Municipios
    }
}
