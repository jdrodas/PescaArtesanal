using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using PescaArtesanal_NoSQL_WindowsForms.Modelos;
using System.Data;

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
            Municipio municipioEncontrado = ObtenerMunicipio(nombreMunicipio, nombreDepartamento);
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
                .FirstOrDefault();

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
                .FirstOrDefault();

            return municipioEncontrado;
        }

        public static string ObtenerNombreCuencaMunicipio(string nombreMunicipio, string nombreDepartamento)
        {
            Municipio municipioEncontrado = ObtenerMunicipio(nombreMunicipio, nombreDepartamento);
            return municipioEncontrado.NombreCuenca!;
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

            //Si la definición de municipio ya existe, no se hace actualización
            if (unMunicipio.Equals(municipioExistente))
            {
                mensajeActualizacion = $"Ya existe un municipio con el nombre {unMunicipio.Nombre} " +
                                        $"para el departamento {unMunicipio.NombreDepartamento} " +
                                        $"en la cuenca {unMunicipio.NombreCuenca}. No se puede actualizar el registro";
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
                {
                    mensajeActualizacion = $"El municipio {unMunicipio.Nombre} fue actualizado";
                    //TODO Se debe actualizar todas las actividades que previamente se hayan vinculado al municipio previo
                }
                
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
                //TODO Validar si hay actividades asociadas al municipio a eliminar
                
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
                .FirstOrDefault();

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
                .FirstOrDefault();

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

        public static bool InsertarDepartamento(Departamento unDepartamento, out string mensajeInsercion)
        {
            mensajeInsercion = string.Empty;
            var clienteDB = new MongoClient(configDB.ConnectionString);
            var miDB = clienteDB.GetDatabase(configDB.DatabaseName);
            var coleccionDepartamentos = configDB.DepartamentosCollectionName;

            var miColeccion = miDB.GetCollection<Departamento>(coleccionDepartamentos);

            //Buscamos primero si ya existe un departamento registrado con ese nombre
            //Se utiliza Linq para hacer consultas 
            var listaDepartamentosExistentes = miColeccion.AsQueryable()
                .Where(depto => depto.Nombre!.ToLower().Contains(unDepartamento.Nombre!.ToLower()))
                .ToList();

            if (listaDepartamentosExistentes.Count > 0)
            {
                mensajeInsercion = $"Error de inserción. Ya existe un departamento con el nombre {unDepartamento.Nombre}";
                return false;
            }
            else
            {
                miColeccion.InsertOne(unDepartamento);

                //Necesitamos corroborar que la inserción fue exitosa
                string? idDepartamento = ObtenerIdDepartamento(unDepartamento.Nombre!);

                if (string.IsNullOrEmpty(idDepartamento))
                {
                    mensajeInsercion = $"Error en DB al insertar registro de departamento";
                    return false;
                }
                else
                {
                    mensajeInsercion = $"Inserción exitosa para nuevo departamento {unDepartamento.Nombre}";
                    return true;
                }
            }
        }

        public static bool ActualizarDepartamento(Departamento unDepartamento)
        {
            var clienteDB = new MongoClient(configDB.ConnectionString);
            var miDB = clienteDB.GetDatabase(configDB.DatabaseName);
            var coleccionDepartamentos = configDB.DepartamentosCollectionName;

            var miColeccion = miDB.GetCollection<Departamento>(coleccionDepartamentos);
            var resultadoActualizacion = miColeccion.ReplaceOne(documento => documento.Id == unDepartamento.Id,
                unDepartamento);

            //TODO Validar si hay municipios vinculados al nombre previo del departamento
            //TODO Validar si hay actividades asociadas al departamento

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

            //TODO Validar si hay actividades asociadas al departamento

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
                .FirstOrDefault();

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
                .FirstOrDefault();

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

            //TODO Validar si hay municipios asociados al nombre de las cuencas

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

            //TODO Validar si hay actividades asociadas a la cuenca

            return resultadoEliminacion.IsAcknowledged;
        }

        #endregion CRUD Cuencas

        #region CRUD Metodos

        public static List<string> ObtenerListaNombresMetodos()
        {
            var clienteDB = new MongoClient(configDB.ConnectionString);
            var miDB = clienteDB.GetDatabase(configDB.DatabaseName);
            var coleccionMetodos = configDB.MetodosCollectionName;

            var listaMetodos = miDB.GetCollection<Metodo>(coleccionMetodos)
                .Find(new BsonDocument())
                .SortBy(dpto => dpto.Nombre)
                .ToList();

            List<string> listaNombres = new List<string>();

            foreach (Metodo unMetodo in listaMetodos)
                listaNombres.Add(unMetodo.Nombre!);

            return listaNombres;
        }

        //TODO Validar si hay actividades asociadas al método de pesca

        //TODO Implementar Acción de Inserción de Métodos de Pesca

        //TODO Implementar Acción de Actualización de Métodos de Pesca

        //TODO Implementar Acción de Eliminación de Métodos de Pesca

        #endregion CRUD Metodos

        #region CRUD Actividades

        public static string ObtenerIdActividad(Actividad unaActividad)
        {
            Actividad actividadEncontrada = ObtenerActividad(unaActividad.NombreMunicipio!,
                                                             unaActividad.NombreDepartamento!,
                                                             unaActividad.NombreMetodo!,
                                                             unaActividad.Fecha);
            return actividadEncontrada.Id!;
        }

        public static Actividad ObtenerActividad(string idActividad)
        {
            var clienteDB = new MongoClient(configDB.ConnectionString);
            var miDB = clienteDB.GetDatabase(configDB.DatabaseName);
            var coleccionActividades = configDB.ActividadesCollectionName;
            var filtroActividad = new BsonDocument { { "_id", new ObjectId(idActividad) } };

            Actividad actividadEncontrada = miDB.GetCollection<Actividad>(coleccionActividades)
                .Find(filtroActividad)
                .FirstOrDefault();

            return actividadEncontrada;
        }

        public static Actividad ObtenerActividad(string nombreMunicipio, string nombreDepartamento, string nombreMetodo, DateTime fecha)
        {
            var clienteDB = new MongoClient(configDB.ConnectionString);
            var miDB = clienteDB.GetDatabase(configDB.DatabaseName);
            var coleccionActividades = configDB.ActividadesCollectionName;
            var filtroActividad = new BsonDocument
                                    {
                                        { "nombre_municipio", nombreMunicipio},
                                        { "nombre_departamento", nombreDepartamento },
                                        { "nombre_metodo", nombreMetodo },
                                        { "fecha", fecha }
                                    };

            Actividad actividadEncontrada = miDB.GetCollection<Actividad>(coleccionActividades)
                .Find(filtroActividad)
                .FirstOrDefault();

            return actividadEncontrada;
        }

        public static List<Actividad> ObtenerListaActividades()
        {
            var clienteDB = new MongoClient(configDB.ConnectionString);
            var miDB = clienteDB.GetDatabase(configDB.DatabaseName);
            var coleccionActividades = configDB.ActividadesCollectionName;

            var listaActividades = miDB.GetCollection<Actividad>(coleccionActividades)
                .Find(new BsonDocument())
                .SortBy(actividad => actividad.Fecha)
                .ToList();

            return listaActividades;
        }

        public static List<Actividad> ObtenerListaActividadesPorMunicipio(string nombreMunicipio, string nombreDepartamento)
        {
            var clienteDB = new MongoClient(configDB.ConnectionString);
            var miDB = clienteDB.GetDatabase(configDB.DatabaseName);
            var coleccionActividades = configDB.ActividadesCollectionName;
            var filtroMunicipio = new BsonDocument
                                    {
                                        { "nombre_municipio", nombreMunicipio},
                                        { "nombre_departamento", nombreDepartamento }
                                    };

            var listaActividades = miDB.GetCollection<Actividad>(coleccionActividades)
                .Find(filtroMunicipio)
                .SortBy(actividad => actividad.Fecha)
                .ToList();

            return listaActividades;
        }

        public static List<Actividad> ObtenerListaActividadesPorDepartamento(string nombreDepartamento)
        {
            var clienteDB = new MongoClient(configDB.ConnectionString);
            var miDB = clienteDB.GetDatabase(configDB.DatabaseName);
            var coleccionActividades = configDB.ActividadesCollectionName;
            var filtroDepartamento = new BsonDocument { { "nombre_departamento", nombreDepartamento } };

            var listaActividades = miDB.GetCollection<Actividad>(coleccionActividades)
                .Find(filtroDepartamento)
                .SortBy(actividad => actividad.Fecha)
                .ToList();

            return listaActividades;
        }

        public static List<Actividad> ObtenerListaActividadesPorCuenca(string nombreCuenca)
        {
            var clienteDB = new MongoClient(configDB.ConnectionString);
            var miDB = clienteDB.GetDatabase(configDB.DatabaseName);
            var coleccionActividades = configDB.ActividadesCollectionName;
            var filtroCuenca = new BsonDocument { { "nombre_cuenca", nombreCuenca } };

            var listaActividades = miDB.GetCollection<Actividad>(coleccionActividades)
                .Find(filtroCuenca)
                .SortBy(actividad => actividad.Fecha)
                .ToList();

            return listaActividades;
        }

        public static List<Actividad> ObtenerListaActividadesPorMetodo(string nombreMetodo)
        {
            var clienteDB = new MongoClient(configDB.ConnectionString);
            var miDB = clienteDB.GetDatabase(configDB.DatabaseName);
            var coleccionActividades = configDB.ActividadesCollectionName;
            var filtroMetodo = new BsonDocument { { "nombre_metodo", nombreMetodo } };

            var listaActividades = miDB.GetCollection<Actividad>(coleccionActividades)
                .Find(filtroMetodo)
                .SortBy(actividad => actividad.Fecha)
                .ToList();

            return listaActividades;
        }

        public static int ObtenerCantidadActividadesPorMunicipio(string nombreMunicipio, string nombreDepartamento)
        {
            var listaActividades = ObtenerListaActividadesPorMunicipio(nombreMunicipio, nombreDepartamento);
            return listaActividades.Count;
        }

        public static int ObtenerCantidadActividadesPorDepartamento(string nombreDepartamento)
        {
            var listaActividades = ObtenerListaActividadesPorDepartamento(nombreDepartamento);
            return listaActividades.Count;
        }

        public static int ObtenerCantidadActividadesPorCuenca(string nombreCuenca)
        {
            var listaActividades = ObtenerListaActividadesPorCuenca(nombreCuenca);
            return listaActividades.Count;
        }

        public static int ObtenerCantidadActividadesPorMetodo(string nombreMetodo)
        {
            var listaActividades = ObtenerListaActividadesPorMetodo(nombreMetodo);
            return listaActividades.Count;
        }

        public static DataTable ObtenerTablaActividadesPorMunicipio(string nombreMunicipio, string nombreDepartamento)
        {
            DataTable tablaResultado = new DataTable();

            var listaActividades = ObtenerListaActividadesPorMunicipio(nombreMunicipio, nombreDepartamento);

            if (listaActividades.Count > 0)
            {
                tablaResultado.Columns.Add(new DataColumn("fecha", typeof(string)));
                tablaResultado.Columns.Add(new DataColumn("nombre_municipio", typeof(string)));
                tablaResultado.Columns.Add(new DataColumn("nombre_departamento", typeof(string)));
                tablaResultado.Columns.Add(new DataColumn("nombre_cuenca", typeof(string)));
                tablaResultado.Columns.Add(new DataColumn("nombre_metodo", typeof(string)));
                tablaResultado.Columns.Add(new DataColumn("cantidad_pescado", typeof(double)));

                DataRow filaActividad;

                foreach (Actividad unaActividad in listaActividades)
                {
                    filaActividad = tablaResultado.NewRow();

                    filaActividad["fecha"] = unaActividad.Fecha.ToShortDateString();
                    filaActividad["nombre_municipio"] = unaActividad.NombreMunicipio;
                    filaActividad["nombre_departamento"] = unaActividad.NombreDepartamento;
                    filaActividad["nombre_cuenca"] = unaActividad.NombreCuenca;
                    filaActividad["nombre_metodo"] = unaActividad.NombreMetodo;
                    filaActividad["cantidad_pescado"] = unaActividad.CantidadPescado;

                    tablaResultado.Rows.Add(filaActividad);
                }
            }

            return tablaResultado;
        }

        public static DataTable ObtenerTablaActividadesPorDepartamento(string nombreDepartamento)
        {
            DataTable tablaResultado = new DataTable();

            var listaActividades = ObtenerListaActividadesPorDepartamento(nombreDepartamento);

            if (listaActividades.Count > 0)
            {
                tablaResultado.Columns.Add(new DataColumn("fecha", typeof(string)));
                tablaResultado.Columns.Add(new DataColumn("nombre_municipio", typeof(string)));                
                tablaResultado.Columns.Add(new DataColumn("nombre_cuenca", typeof(string)));
                tablaResultado.Columns.Add(new DataColumn("nombre_metodo", typeof(string)));
                tablaResultado.Columns.Add(new DataColumn("cantidad_pescado", typeof(double)));

                DataRow filaActividad;

                foreach (Actividad unaActividad in listaActividades)
                {
                    filaActividad = tablaResultado.NewRow();

                    filaActividad["fecha"] = unaActividad.Fecha.ToShortDateString();
                    filaActividad["nombre_municipio"] = unaActividad.NombreMunicipio;
                    filaActividad["nombre_cuenca"] = unaActividad.NombreCuenca;
                    filaActividad["nombre_metodo"] = unaActividad.NombreMetodo;
                    filaActividad["cantidad_pescado"] = unaActividad.CantidadPescado;

                    tablaResultado.Rows.Add(filaActividad);
                }
            }

            return tablaResultado;
        }

        public static DataTable ObtenerTablaActividadesPorCuenca(string nombreCuenca)
        {
            DataTable tablaResultado = new DataTable();

            var listaActividades = ObtenerListaActividadesPorCuenca(nombreCuenca);

            if (listaActividades.Count > 0)
            {
                tablaResultado.Columns.Add(new DataColumn("fecha", typeof(string)));
                tablaResultado.Columns.Add(new DataColumn("nombre_municipio", typeof(string)));
                tablaResultado.Columns.Add(new DataColumn("nombre_departamento", typeof(string)));
                tablaResultado.Columns.Add(new DataColumn("nombre_metodo", typeof(string)));
                tablaResultado.Columns.Add(new DataColumn("cantidad_pescado", typeof(double)));

                DataRow filaActividad;

                foreach (Actividad unaActividad in listaActividades)
                {
                    filaActividad = tablaResultado.NewRow();

                    filaActividad["fecha"] = unaActividad.Fecha.ToShortDateString();
                    filaActividad["nombre_municipio"] = unaActividad.NombreMunicipio;
                    filaActividad["nombre_departamento"] = unaActividad.NombreDepartamento;
                    filaActividad["nombre_metodo"] = unaActividad.NombreMetodo;
                    filaActividad["cantidad_pescado"] = unaActividad.CantidadPescado;

                    tablaResultado.Rows.Add(filaActividad);
                }
            }

            return tablaResultado;
        }

        public static DataTable ObtenerTablaActividadesPorMetodo(string nombreMetodo)
        {
            DataTable tablaResultado = new DataTable();

            var listaActividades = ObtenerListaActividadesPorMetodo(nombreMetodo);

            if (listaActividades.Count > 0)
            {
                tablaResultado.Columns.Add(new DataColumn("fecha", typeof(string)));
                tablaResultado.Columns.Add(new DataColumn("nombre_municipio", typeof(string)));
                tablaResultado.Columns.Add(new DataColumn("nombre_departamento", typeof(string)));
                tablaResultado.Columns.Add(new DataColumn("nombre_cuenca", typeof(string)));
                tablaResultado.Columns.Add(new DataColumn("cantidad_pescado", typeof(double)));

                DataRow filaActividad;

                foreach (Actividad unaActividad in listaActividades)
                {
                    filaActividad = tablaResultado.NewRow();

                    filaActividad["fecha"] = unaActividad.Fecha.ToShortDateString();
                    filaActividad["nombre_municipio"] = unaActividad.NombreMunicipio;
                    filaActividad["nombre_departamento"] = unaActividad.NombreDepartamento;
                    filaActividad["nombre_cuenca"] = unaActividad.NombreCuenca;
                    filaActividad["cantidad_pescado"] = unaActividad.CantidadPescado;

                    tablaResultado.Rows.Add(filaActividad);
                }
            }

            return tablaResultado;
        }

        public static bool InsertarActividad(Actividad unaActividad, out string mensajeInsercion)
        {
            mensajeInsercion = string.Empty;
            var clienteDB = new MongoClient(configDB.ConnectionString);
            var miDB = clienteDB.GetDatabase(configDB.DatabaseName);
            var coleccionActividades = configDB.ActividadesCollectionName;

            var miColeccion = miDB.GetCollection<Actividad>(coleccionActividades);
            miColeccion.InsertOne(unaActividad);

            //Necesitamos corroborar que la inserción fue exitosa
            string? idActividad = ObtenerIdActividad(unaActividad);

            if (string.IsNullOrEmpty(idActividad))
            {
                mensajeInsercion = "Fallo al realizar la inserción.";
                return false;
            }
            else
            {
                mensajeInsercion = $"Inserción exitosa para la actividad en {unaActividad.NombreMunicipio} " +
                    $"en el departamento {unaActividad.NombreDepartamento} utilizando {unaActividad.NombreMetodo}, " +
                    $"realizada el día {unaActividad.Fecha.ToShortDateString()}";
                return true;
            }
        }

        public static bool ActualizarActividad(Actividad unaActividad, out string mensajeActualizacion)
        {
            mensajeActualizacion = string.Empty;
            var clienteDB = new MongoClient(configDB.ConnectionString);
            var miDB = clienteDB.GetDatabase(configDB.DatabaseName);
            var coleccionActividades = configDB.ActividadesCollectionName;

            //Primero validamos que exista la actividad que vamos a actualizar
            Actividad actividadExistente = ObtenerActividad(unaActividad.Id!);

            //Si no existe actividad con ese ID, no se puede hacer actualización
            if (actividadExistente.Id!.Equals(string.Empty))
            {
                mensajeActualizacion = $"No existe una actividad de pesca para actualizar con los datos suministrados";
                return false;
            }
            else
            {
                var miColeccion = miDB.GetCollection<Actividad>(coleccionActividades);
                var resultadoActualizacion = miColeccion.ReplaceOne(documento => documento.Id == unaActividad.Id,
                    unaActividad);

                if (!resultadoActualizacion.IsAcknowledged)
                    mensajeActualizacion = $"Error al actualizar la actividad en {unaActividad.NombreMunicipio} " +
                        $"para el departamento {unaActividad.NombreDepartamento}";
                else
                    mensajeActualizacion = $"La actividad en {unaActividad.NombreMunicipio} " +
                        $"para el departamento {unaActividad.NombreDepartamento} fue actualizada.";

                return resultadoActualizacion.IsAcknowledged;
            }
        }

        public static bool EliminarActividad(Actividad unaActividad, out string mensajeEliminacion)
        {
            mensajeEliminacion = string.Empty;
            var clienteDB = new MongoClient(configDB.ConnectionString);
            var miDB = clienteDB.GetDatabase(configDB.DatabaseName);
            var coleccionActividades = configDB.ActividadesCollectionName;

            //Primero validamos que exista la actividad que vamos a actualizar
            Actividad actividadExistente = ObtenerActividad(unaActividad.Id!);

            //Si no existe actividad con ese ID, no se puede hacer eliminación
            if (actividadExistente.Id!.Equals(string.Empty))
            {
                mensajeEliminacion = $"No existe actividad a eliminar con esa información";
                return false;
            }
            else
            {
                var miColeccion = miDB.GetCollection<Actividad>(coleccionActividades);
                var resultadoEliminacion = miColeccion.DeleteOne(documento => documento.Id == unaActividad.Id);

                if (!resultadoEliminacion.IsAcknowledged)
                    mensajeEliminacion = $"Error al elimininar la actividad en {unaActividad.NombreMunicipio} " +
                        $"del departamento {unaActividad.NombreDepartamento}";
                else
                    mensajeEliminacion = $"La actividad en {unaActividad.NombreMunicipio}  " +
                        $"del departamento {unaActividad.NombreDepartamento} fue eliminada";

                return resultadoEliminacion.IsAcknowledged;
            }


        }

        #endregion CRUD Actividades
    }
}
