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

        public static string ObtenerIdMunicipio(string nombreMunicipio, string nombreDepartamento)
        {
            Municipio municipioEncontrado = ObtenerMunicipio(nombreMunicipio,nombreDepartamento);
            return municipioEncontrado.Id!;
        }

        public static Municipio ObtenerMunicipio(string idMunicipio)
        {

            var clienteDB = new MongoClient(configDB.ConnectionString);
            var miDB = clienteDB.GetDatabase(configDB.DatabaseName);
            var coleccionMunicipios = configDB.MunicipiosCollectionName;
            var filtroMunicipio = new BsonDocument { { "_id", new ObjectId(idMunicipio) } };

            Municipio municipioEncontrado = miDB.GetCollection<Municipio>(coleccionMunicipios)
                .Find(filtroMunicipio)
                .First();

            return municipioEncontrado;
        }

        public static Municipio ObtenerMunicipio(string nombreMunicipio, string nombreDepartamento)
        {
            var clienteDB = new MongoClient(configDB.ConnectionString);
            var miDB = clienteDB.GetDatabase(configDB.DatabaseName);
            var coleccionMunicipios = configDB.MunicipiosCollectionName;
            var filtroMunicipio = new BsonDocument 
                                    { 
                                        { "nombre", nombreMunicipio},
                                        { "nombre_departamento", nombreDepartamento } 
                                    };

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
                listaNombres.Add(unMunicipio.Nombre!);

            return listaNombres;
        }

        public static List<string> ObtenerListaNombresMunicipios(string nombreDepartamento)
        {
            var clienteDB = new MongoClient(configDB.ConnectionString);
            var miDB = clienteDB.GetDatabase(configDB.DatabaseName);
            var coleccionMunicipios = configDB.MunicipiosCollectionName;
            var filtroDepartamento = new BsonDocument { { "nombre_departamento", nombreDepartamento } };

            var listaMunicipios = miDB.GetCollection<Municipio>(coleccionMunicipios)
                .Find(filtroDepartamento)
                .SortBy(mpio => mpio.Nombre)
                .ToList();

            List<string> listaNombres = new List<string>();

            foreach (Municipio unMunicipio in listaMunicipios)
                listaNombres.Add(unMunicipio.Nombre!);

            return listaNombres;
        }

        public static List<string> ObtenerListaInformacionMunicipios()
        {
            var clienteDB = new MongoClient(configDB.ConnectionString);
            var miDB = clienteDB.GetDatabase(configDB.DatabaseName);
            var coleccionMunicipios = configDB.MunicipiosCollectionName;

            var listaMunicipios = miDB.GetCollection<Municipio>(coleccionMunicipios)
                .Find(new BsonDocument())
                .SortBy(mpio => mpio.Nombre)
                .ToList();

            List<string> listaInfoMunicipios = new List<string>();

            foreach (Municipio unMunicipio in listaMunicipios)
                listaInfoMunicipios.Add($"{unMunicipio.Nombre} - {unMunicipio.NombreDepartamento} - {unMunicipio.NombreCuenca}");

            return listaInfoMunicipios;
        }

        public static bool InsertarMunicipio(Municipio unMunicipio, out string mensajeInsercion)
        {
            mensajeInsercion = string.Empty;
            var clienteDB = new MongoClient(configDB.ConnectionString);
            var miDB = clienteDB.GetDatabase(configDB.DatabaseName);
            var coleccionMunicipios = configDB.MunicipiosCollectionName;

            //Primero se debe validar que no exista ya un documento con ese nombre de municipio para ese departamento
            Municipio municipioExistente = ObtenerMunicipio(unMunicipio.Nombre!, unMunicipio.NombreDepartamento!);

            if (municipioExistente != null)
            {
                mensajeInsercion = $"Ya existe un municipio con el nombre {unMunicipio.Nombre} " +
                    $"para el departamento {unMunicipio.NombreDepartamento}";
                return false;
            }
            else
            {
                var miColeccion = miDB.GetCollection<Municipio>(coleccionMunicipios);
                miColeccion.InsertOne(unMunicipio);

                //Necesitamos corroborar que la inserción fue exitosa
                string? idMunicipio = ObtenerIdMunicipio(unMunicipio.Nombre!, unMunicipio.NombreDepartamento!);

                if (string.IsNullOrEmpty(idMunicipio))
                {
                    mensajeInsercion = "Fallo al realizar la inserción.";
                    return false;
                }
                else
                {
                    mensajeInsercion = $"Inserción exitosa para el municipio {unMunicipio.Nombre} en el departamento {unMunicipio.NombreDepartamento}";
                    return true;
                }
            }
        }

        public static bool ActualizarMunicipio(Municipio unMunicipio, out string mensajeActualizacion)
        {
            mensajeActualizacion = string.Empty;
            var clienteDB = new MongoClient(configDB.ConnectionString);
            var miDB = clienteDB.GetDatabase(configDB.DatabaseName);
            var coleccionMunicipios = configDB.MunicipiosCollectionName;

            //Primero se debe validar que no exista un municipio con la combinación nombre, nombre departamento
            Municipio municipioExistente = ObtenerMunicipio(unMunicipio.Nombre!, unMunicipio.NombreDepartamento!);

            if (municipioExistente != null)
            {
                mensajeActualizacion = $"Ya existe un municipio con el nombre {unMunicipio.Nombre} " +
                    $"para el departamento {unMunicipio.NombreDepartamento}. No se puede actualizar el nuevo nombre";
                return false;
            }
            else
            {
                var miColeccion = miDB.GetCollection<Municipio>(coleccionMunicipios);
                var resultadoActualizacion = miColeccion.ReplaceOne(documento => documento.Id == unMunicipio.Id,
                    unMunicipio);

                if (!resultadoActualizacion.IsAcknowledged)
                    mensajeActualizacion = $"Error al actualizar el municipio {unMunicipio.Nombre} " +
                        $"del departamento {unMunicipio.NombreDepartamento}";
                else
                    mensajeActualizacion = $"El municipio {unMunicipio.Nombre} fue actualizado";

                return resultadoActualizacion.IsAcknowledged;
            }
        }

        public static bool EliminarMunicipio(Municipio unMunicipio, out string mensajeEliminacion)
        {
            mensajeEliminacion = string.Empty;
            var clienteDB = new MongoClient(configDB.ConnectionString);
            var miDB = clienteDB.GetDatabase(configDB.DatabaseName);
            var coleccionMunicipios = configDB.MunicipiosCollectionName;

            //Primero se debe validar que exista el municipio que se desea borrar
            Municipio municipioExistente = ObtenerMunicipio(unMunicipio.Id!);

            if (municipioExistente == null)
            {
                mensajeEliminacion = $"No existe municipio a eliminar con el nombre {unMunicipio.Nombre}";
                return false;
            }
            else
            {
                var miColeccion = miDB.GetCollection<Municipio>(coleccionMunicipios);
                var resultadoEliminacion = miColeccion.DeleteOne(documento => documento.Id == unMunicipio.Id);

                if (!resultadoEliminacion.IsAcknowledged)
                    mensajeEliminacion = $"Error al elimininar el municipio {unMunicipio.Nombre} " +
                        $"del departamento {unMunicipio.NombreDepartamento}";
                else
                    mensajeEliminacion = $"El municipio {unMunicipio.Nombre} fue eliminado";

                return resultadoEliminacion.IsAcknowledged;
            }
        }

        #endregion CRUD Municipios

        #region CRUD Departamentos

        public static string ObtenerIdDepartamento(string nombreDepartamento)
        {

            var clienteDB = new MongoClient(configDB.ConnectionString);
            var miDB = clienteDB.GetDatabase(configDB.DatabaseName);
            var coleccionDepartamentos = configDB.DepartamentosCollectionName;
            var filtroDepartamento = new BsonDocument { { "nombre", nombreDepartamento } };

            Departamento departamentoEncontrado = miDB.GetCollection<Departamento>(coleccionDepartamentos)
                .Find(filtroDepartamento)
                .First();

            return departamentoEncontrado.Id!;
        }

        public static Departamento ObtenerDepartamento(string idDepartamento)
        {

            var clienteDB = new MongoClient(configDB.ConnectionString);
            var miDB = clienteDB.GetDatabase(configDB.DatabaseName);
            var coleccionDepartamentos = configDB.DepartamentosCollectionName;
            var filtroDepartamento = new BsonDocument { { "_id", new ObjectId(idDepartamento) } };

            Departamento departamentoEncontrado = miDB.GetCollection<Departamento>(coleccionDepartamentos)
                .Find(filtroDepartamento)
                .First();

            return departamentoEncontrado;
        }

        public static List<string> ObtenerListaNombresDepartamentos()
        {
            var clienteDB = new MongoClient(configDB.ConnectionString);
            var miDB = clienteDB.GetDatabase(configDB.DatabaseName);
            var coleccionDepartamentos = configDB.DepartamentosCollectionName;

            var listaDepartamentos = miDB.GetCollection<Departamento>(coleccionDepartamentos)
                .Find(new BsonDocument())
                .SortBy(dpto => dpto.Nombre)
                .ToList();

            List<string> listaNombres = new List<string>();

            foreach (Departamento unDepartamento in listaDepartamentos)
                listaNombres.Add(unDepartamento.Nombre!);

            return listaNombres;
        }

        public static bool InsertarDepartamento(Departamento unDepartamento)
        {
            var clienteDB = new MongoClient(configDB.ConnectionString);
            var miDB = clienteDB.GetDatabase(configDB.DatabaseName);
            var coleccionDepartamentos = configDB.DepartamentosCollectionName;

            var miColeccion = miDB.GetCollection<Departamento>(coleccionDepartamentos);
            miColeccion.InsertOne(unDepartamento);

            //Necesitamos corroborar que la inserción fue exitosa
            string? idDepartamento = ObtenerIdDepartamento(unDepartamento.Nombre!);

            if (string.IsNullOrEmpty(idDepartamento))
                return false;
            else
                return true;
        }

        public static bool ActualizarDepartamento(Departamento unDepartamento)
        {
            var clienteDB = new MongoClient(configDB.ConnectionString);
            var miDB = clienteDB.GetDatabase(configDB.DatabaseName);
            var coleccionDepartamentos = configDB.DepartamentosCollectionName;

            var miColeccion = miDB.GetCollection<Departamento>(coleccionDepartamentos);
            var resultadoActualizacion = miColeccion.ReplaceOne(documento => documento.Id == unDepartamento.Id,
                unDepartamento);

            return resultadoActualizacion.IsAcknowledged;
        }

        public static bool EliminarDepartamento(Departamento unDepartamento, out string mensajeEliminacion)
        {
            mensajeEliminacion = string.Empty;
            var clienteDB = new MongoClient(configDB.ConnectionString);
            var miDB = clienteDB.GetDatabase(configDB.DatabaseName);
            var coleccionDepartamentos = configDB.DepartamentosCollectionName;

            var miColeccion = miDB.GetCollection<Departamento>(coleccionDepartamentos);
            var resultadoEliminacion = miColeccion.DeleteOne(documento => documento.Id == unDepartamento.Id);

            if (!resultadoEliminacion.IsAcknowledged)
                mensajeEliminacion = $"Error al elimininar el departamento {unDepartamento.Nombre} ";
            else
                mensajeEliminacion = $"El departamento {unDepartamento.Nombre} fue eliminado";

            return resultadoEliminacion.IsAcknowledged;
        }

        #endregion CRUD Departamentos

        #region CRUD Cuencas

        public static string ObtenerIdCuenca(string nombreCuenca)
        {

            var clienteDB = new MongoClient(configDB.ConnectionString);
            var miDB = clienteDB.GetDatabase(configDB.DatabaseName);
            var coleccionCuencas = configDB.CuencasCollectionName;
            var filtroCuenca = new BsonDocument { { "nombre", nombreCuenca } };

            Cuenca CuencaEncontrada = miDB.GetCollection<Cuenca>(coleccionCuencas)
                .Find(filtroCuenca)
                .First();

            return CuencaEncontrada.Id!;
        }

        public static Cuenca ObtenerCuenca(string idCuenca)
        {

            var clienteDB = new MongoClient(configDB.ConnectionString);
            var miDB = clienteDB.GetDatabase(configDB.DatabaseName);
            var coleccionCuencas = configDB.CuencasCollectionName;
            var filtroCuenca = new BsonDocument { { "_id", new ObjectId(idCuenca) } };

            Cuenca CuencaEncontrada = miDB.GetCollection<Cuenca>(coleccionCuencas)
                .Find(filtroCuenca)
                .First();

            return CuencaEncontrada;
        }

        public static List<string> ObtenerListaNombresCuencas()
        {
            var clienteDB = new MongoClient(configDB.ConnectionString);
            var miDB = clienteDB.GetDatabase(configDB.DatabaseName);
            var coleccionCuencas = configDB.CuencasCollectionName;

            var listaCuencas = miDB.GetCollection<Cuenca>(coleccionCuencas)
                .Find(new BsonDocument())
                .SortBy(dpto => dpto.Nombre)
                .ToList();

            List<string> listaNombres = new List<string>();

            foreach (Cuenca unCuenca in listaCuencas)
                listaNombres.Add(unCuenca.Nombre!);

            return listaNombres;
        }

        public static bool InsertarCuenca(Cuenca unCuenca)
        {
            var clienteDB = new MongoClient(configDB.ConnectionString);
            var miDB = clienteDB.GetDatabase(configDB.DatabaseName);
            var coleccionCuencas = configDB.CuencasCollectionName;

            var miColeccion = miDB.GetCollection<Cuenca>(coleccionCuencas);
            miColeccion.InsertOne(unCuenca);

            //Necesitamos corroborar que la inserción fue exitosa
            string? idCuenca = ObtenerIdCuenca(unCuenca.Nombre!);

            if (string.IsNullOrEmpty(idCuenca))
                return false;
            else
                return true;
        }

        public static bool ActualizarCuenca(Cuenca unCuenca)
        {
            var clienteDB = new MongoClient(configDB.ConnectionString);
            var miDB = clienteDB.GetDatabase(configDB.DatabaseName);
            var coleccionCuencas = configDB.CuencasCollectionName;

            var miColeccion = miDB.GetCollection<Cuenca>(coleccionCuencas);
            var resultadoActualizacion = miColeccion.ReplaceOne(documento => documento.Id == unCuenca.Id,
                unCuenca);

            return resultadoActualizacion.IsAcknowledged;
        }

        public static bool EliminarCuenca(Cuenca unCuenca, out string mensajeEliminacion)
        {
            mensajeEliminacion = string.Empty;
            var clienteDB = new MongoClient(configDB.ConnectionString);
            var miDB = clienteDB.GetDatabase(configDB.DatabaseName);
            var coleccionCuencas = configDB.CuencasCollectionName;

            var miColeccion = miDB.GetCollection<Cuenca>(coleccionCuencas);
            var resultadoEliminacion = miColeccion.DeleteOne(documento => documento.Id == unCuenca.Id);

            if (!resultadoEliminacion.IsAcknowledged)
                mensajeEliminacion = $"Error al elimininar el Cuenca {unCuenca.Nombre} ";
            else
                mensajeEliminacion = $"El Cuenca {unCuenca.Nombre} fue eliminada";

            return resultadoEliminacion.IsAcknowledged;
        }

        #endregion CRUD Cuencas

    }
}
