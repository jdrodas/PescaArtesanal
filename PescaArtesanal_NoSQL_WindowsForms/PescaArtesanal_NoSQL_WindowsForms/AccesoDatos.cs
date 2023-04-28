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

        public static List<Municipio> ObtenerListaMunicipiosCuenca(string nombreCuenca)
        {
            var clienteDB = new MongoClient(configDB.ConnectionString);
            var miDB = clienteDB.GetDatabase(configDB.DatabaseName);
            var coleccionMunicipios = configDB.MunicipiosCollectionName;
            var filtroCuenca = new BsonDocument { { "nombre_cuenca", nombreCuenca } };

            var lista = miDB.GetCollection<Municipio>(coleccionMunicipios)
                .Find(filtroCuenca)
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

        public static int ObtenerCantidadMunicipiosDepartamento(string nombreDepartamento)
        {
            var listaMunicipios = ObtenerListaMunicipiosDepartamento(nombreDepartamento);
            return listaMunicipios.Count;
        }

        public static int ObtenerCantidadMunicipiosCuenca(string nombreCuenca)
        {
            var listaMunicipios = ObtenerListaMunicipiosCuenca(nombreCuenca);
            return listaMunicipios.Count;
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

            //Primero se debe validar que exista el municipio que se desea borrar
            Municipio municipioExistente = ObtenerMunicipio(unMunicipio.Id!);

            if (municipioExistente == null)
            {
                mensajeEliminacion = $"No existe municipio a eliminar con el nombre {unMunicipio.Nombre}";
                return false;
            }

            //Luego, se debe validar si hay actividades asociadas al municipio a eliminar
            int actividadesAsociadas = ObtenerCantidadActividadesPorMunicipio(unMunicipio.Nombre, unMunicipio.NombreDepartamento);

            if(actividadesAsociadas>0)
            {
                mensajeEliminacion = $"No se puede eliminar el municipio {unMunicipio.Nombre} porque " +
                    $"tiene asociadas {actividadesAsociadas} actividad(es) de pesca";
                return false;
            }

            var clienteDB = new MongoClient(configDB.ConnectionString);
            var miDB = clienteDB.GetDatabase(configDB.DatabaseName);
            var coleccionMunicipios = configDB.MunicipiosCollectionName;

            var miColeccion = miDB.GetCollection<Municipio>(coleccionMunicipios);
            var resultadoEliminacion = miColeccion.DeleteOne(documento => documento.Id == unMunicipio.Id);

            if (!resultadoEliminacion.IsAcknowledged)
                mensajeEliminacion = $"Error al elimininar el municipio {unMunicipio.Nombre} " +
                    $"del departamento {unMunicipio.NombreDepartamento}";
            else
                mensajeEliminacion = $"El municipio {unMunicipio.Nombre} fue eliminado";

            return resultadoEliminacion.IsAcknowledged;
        }

        #endregion CRUD Municipios

        #region CRUD Departamentos

        public static string ObtenerIdDepartamento(string nombreDepartamento)
        {
            var clienteDB = new MongoClient(configDB.ConnectionString);
            var miDB = clienteDB.GetDatabase(configDB.DatabaseName);
            var coleccionDepartamentos = configDB.DepartamentosCollectionName;

            Departamento? departamentoEncontrado = miDB.GetCollection<Departamento>(coleccionDepartamentos)
                .AsQueryable()
                .Where(depto => depto.Nombre!.ToLower().Contains(nombreDepartamento!.ToLower()))
                .ToList()
                .FirstOrDefault();

            if (departamentoEncontrado is null)
                return string.Empty;

            return departamentoEncontrado!.Id!;
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

            //Buscamos primero si ya existe un departamento registrado con ese nombre
            string IdDepartamentoExistente = ObtenerIdDepartamento(unDepartamento.Nombre!);

            if (!string.IsNullOrEmpty(IdDepartamentoExistente))
            {
                mensajeInsercion = $"Error de inserción. Ya existe un departamento con el nombre {unDepartamento.Nombre}";
                return false;
            }
            else
            {
                var clienteDB = new MongoClient(configDB.ConnectionString);
                var miDB = clienteDB.GetDatabase(configDB.DatabaseName);
                var coleccionDepartamentos = configDB.DepartamentosCollectionName;

                var miColeccion = miDB.GetCollection<Departamento>(coleccionDepartamentos);
                miColeccion.InsertOne(unDepartamento);

                //Necesitamos corroborar que la inserción fue exitosa
                string idDepartamento = ObtenerIdDepartamento(unDepartamento.Nombre!);

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

        public static bool ActualizarDepartamento(Departamento unDepartamento, out string mensajeActualizacion)
        {
            mensajeActualizacion = string.Empty;

            //Buscamos primero si ya existe un departamento registrado con ese ID
            Departamento departamentoExistente = ObtenerDepartamento(unDepartamento.Id!);

            if (string.IsNullOrEmpty(departamentoExistente.Id))
            {
                mensajeActualizacion = $"Error de actualización. no existe un departamento para actualiza con ese ID";
                return false;
            }

            var clienteDB = new MongoClient(configDB.ConnectionString);
            var miDB = clienteDB.GetDatabase(configDB.DatabaseName);
            var coleccionDepartamentos = configDB.DepartamentosCollectionName;

            var miColeccion = miDB.GetCollection<Departamento>(coleccionDepartamentos);
            var resultadoActualizacion = miColeccion.ReplaceOne(documento => documento.Id == unDepartamento.Id,
                unDepartamento);

            if (!resultadoActualizacion.IsAcknowledged)
            {
                mensajeActualizacion = $"Error al actualizar el nombre del departamento de {departamentoExistente.Nombre} " +
                                        $"{unDepartamento.Nombre} ";
                return false;
            }

            mensajeActualizacion = $"El departamento {departamentoExistente.Nombre} fue actualizado a {unDepartamento.Nombre}. ";

            int municipiosActualizables = ObtenerCantidadMunicipiosDepartamento(departamentoExistente.Nombre!);
            if (municipiosActualizables > 0)
            {
                ActualizarDepartamentoEnMunicipios(departamentoExistente.Nombre!, unDepartamento.Nombre!);
                mensajeActualizacion += $"Se actualizaron {municipiosActualizables} municipio(s) asociados.";
            }

            int actividadesActualizables = ObtenerCantidadActividadesPorDepartamento(departamentoExistente.Nombre!);
            if (actividadesActualizables > 0)
            {
                ActualizarDepartamentoEnActividades(departamentoExistente.Nombre!, unDepartamento.Nombre!);
                mensajeActualizacion += $"Se actualizaron {actividadesActualizables} actividad(es) asociadas.";
            }

            return resultadoActualizacion.IsAcknowledged;
        }

        public static void ActualizarDepartamentoEnMunicipios(string departamentoAntiguo, string departamentoNuevo)
        {
            // Obtener municipios del departamento anterior
            List<Municipio> municipiosActualizables = ObtenerListaMunicipiosDepartamento(departamentoAntiguo);

            // Se actualiza nuevamente en la base de datos
            var clienteDB = new MongoClient(configDB.ConnectionString);
            var miDB = clienteDB.GetDatabase(configDB.DatabaseName);
            var coleccionMunicipios = configDB.MunicipiosCollectionName;

            var miColeccion = miDB.GetCollection<Municipio>(coleccionMunicipios);

            // A cada uno de ellos, se le cambia el nombre del departamento
            foreach (Municipio unMunicipio in municipiosActualizables)
            {
                unMunicipio.NombreDepartamento = departamentoNuevo;
                miColeccion.ReplaceOne(documento => documento.Id == unMunicipio.Id, unMunicipio);
            }
        }

        public static void ActualizarDepartamentoEnActividades(string departamentoAntiguo, string departamentoNuevo)
        {
            // Obtener municipios del departamento anterior
            List<Actividad> actividadesActualizables = ObtenerListaActividadesPorDepartamento(departamentoAntiguo);

            // Se actualiza nuevamente en la base de datos
            var clienteDB = new MongoClient(configDB.ConnectionString);
            var miDB = clienteDB.GetDatabase(configDB.DatabaseName);
            var coleccionActividades = configDB.ActividadesCollectionName;

            var miColeccion = miDB.GetCollection<Actividad>(coleccionActividades);

            // A cada uno de ellos, se le cambia el nombre del departamento
            foreach (Actividad unaActividad in actividadesActualizables)
            {
                unaActividad.NombreDepartamento = departamentoNuevo;
                miColeccion.ReplaceOne(documento => documento.Id == unaActividad.Id, unaActividad);
            }
        }

        public static bool EliminarDepartamento(Departamento unDepartamento, out string mensajeEliminacion)
        {
            mensajeEliminacion = string.Empty;

            //Buscamos primero si ya existe un departamento registrado con ese ID
            Departamento departamentoExistente = ObtenerDepartamento(unDepartamento.Id!);

            if (string.IsNullOrEmpty(departamentoExistente.Id))
            {
                mensajeEliminacion = $"Error de eliminación. No existe un departamento para eliminar con ese ID";
                return false;
            }

            //Validar si hay actividades asociadas al departamento a eliminar
            int cantidadActividadesDepartamento = ObtenerCantidadActividadesPorDepartamento(unDepartamento.Nombre!);

            if (cantidadActividadesDepartamento > 0)
            {
                mensajeEliminacion = $"No se puede eliminar Departamento {unDepartamento.Nombre} porque tiene " +
                    $"asociadas {cantidadActividadesDepartamento} actividades de pesca";
                return false;
            }

            //Validar si hay municipios asociados al departamento a eliminar
            int cantidadMunicipiosDepartamento = ObtenerCantidadMunicipiosDepartamento(unDepartamento.Nombre!);
            if (cantidadMunicipiosDepartamento > 0)
            {
                mensajeEliminacion = $"No se puede eliminar Departamento {unDepartamento.Nombre} porque tiene " +
                    $"asociados {cantidadMunicipiosDepartamento} municipios";
                return false;
            }

            var clienteDB = new MongoClient(configDB.ConnectionString);
            var miDB = clienteDB.GetDatabase(configDB.DatabaseName);
            var coleccionDepartamentos = configDB.DepartamentosCollectionName;

            var miColeccion = miDB.GetCollection<Departamento>(coleccionDepartamentos);
            var resultadoEliminacion = miColeccion.DeleteOne(documento => documento.Id == unDepartamento.Id);

            if (!resultadoEliminacion.IsAcknowledged)
                mensajeEliminacion = $"Error al eliminar el departamento {unDepartamento.Nombre} ";
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

            Cuenca? cuencaEncontrada = miDB.GetCollection<Cuenca>(coleccionCuencas)
                .AsQueryable()
                .Where(cuenca => cuenca.Nombre!.ToLower().Contains(nombreCuenca!.ToLower()))
                .ToList()
                .FirstOrDefault();

            if (cuencaEncontrada is null)
                return string.Empty;

            return cuencaEncontrada!.Id!;
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

        public static bool InsertarCuenca(Cuenca unaCuenca, out string mensajeInsercion)
        {
            mensajeInsercion = string.Empty;

            //Buscamos primero si ya existe una cuenca registrada con ese nombre
            string IdCuencaExistente = ObtenerIdCuenca(unaCuenca.Nombre!);

            if (!string.IsNullOrEmpty(IdCuencaExistente))
            {
                mensajeInsercion = $"Error de inserción. Ya existe una cuenca con el nombre {unaCuenca.Nombre}";
                return false;
            }
            else
            {
                var clienteDB = new MongoClient(configDB.ConnectionString);
                var miDB = clienteDB.GetDatabase(configDB.DatabaseName);
                var coleccionCuenca = configDB.CuencasCollectionName;

                var miColeccion = miDB.GetCollection<Cuenca>(coleccionCuenca);
                miColeccion.InsertOne(unaCuenca);

                //Necesitamos corroborar que la inserción fue exitosa
                string idCuenca = ObtenerIdCuenca(unaCuenca.Nombre!);

                if (string.IsNullOrEmpty(idCuenca))
                {
                    mensajeInsercion = $"Error en DB al insertar registro de cuenca";
                    return false;
                }
                else
                {
                    mensajeInsercion = $"Inserción exitosa para nueva cuenca {unaCuenca.Nombre}";
                    return true;
                }
            }
        }

        public static bool ActualizarCuenca(Cuenca unaCuenca, out string mensajeActualizacion)
        {
            mensajeActualizacion = string.Empty;

            //Buscamos primero si ya existe un cuenca registrada con ese ID
            Cuenca cuencaExistente = ObtenerCuenca(unaCuenca.Id!);

            if (string.IsNullOrEmpty(cuencaExistente.Id))
            {
                mensajeActualizacion = $"Error de actualización. no existe una cuenca para actualizar con ese ID";
                return false;
            }

            var clienteDB = new MongoClient(configDB.ConnectionString);
            var miDB = clienteDB.GetDatabase(configDB.DatabaseName);
            var coleccionCuencas = configDB.CuencasCollectionName;

            var miColeccion = miDB.GetCollection<Cuenca>(coleccionCuencas);
            var resultadoActualizacion = miColeccion.ReplaceOne(cuenca => cuenca.Id == unaCuenca.Id,
                unaCuenca);

            if (!resultadoActualizacion.IsAcknowledged)
            {
                mensajeActualizacion = $"Error al actualizar el nombre de la cuenca de {cuencaExistente.Nombre} " +
                                        $"{unaCuenca.Nombre} ";
                return false;
            }

            mensajeActualizacion = $"La cuenca {cuencaExistente.Nombre} fue actualizada a {unaCuenca.Nombre}. ";

            int municipiosActualizables = ObtenerCantidadMunicipiosCuenca(cuencaExistente.Nombre!);
            if (municipiosActualizables > 0)
            {
                ActualizarCuencaEnMunicipios(cuencaExistente.Nombre!, unaCuenca.Nombre!);
                mensajeActualizacion += $"Se actualizaron {municipiosActualizables} municipio(s) asociados.";
            }

            int actividadesActualizables = ObtenerCantidadActividadesPorCuenca(cuencaExistente.Nombre!);
            if (actividadesActualizables > 0)
            {
                ActualizarCuencaEnActividades(cuencaExistente.Nombre!, unaCuenca.Nombre!);
                mensajeActualizacion += $"Se actualizaron {actividadesActualizables} actividad(es) asociadas.";
            }

            return resultadoActualizacion.IsAcknowledged;
        }

        public static void ActualizarCuencaEnMunicipios(string cuencaAntigua, string cuencaNueva)
        {
            // Obtener municipios de la cuenca anterior
            List<Municipio> municipiosActualizables = ObtenerListaMunicipiosCuenca(cuencaAntigua);

            // Se actualiza nuevamente en la base de datos
            var clienteDB = new MongoClient(configDB.ConnectionString);
            var miDB = clienteDB.GetDatabase(configDB.DatabaseName);
            var coleccionMunicipios = configDB.MunicipiosCollectionName;

            var miColeccion = miDB.GetCollection<Municipio>(coleccionMunicipios);

            // A cada uno de ellos, se le cambia el nombre de la cuenca
            foreach (Municipio unMunicipio in municipiosActualizables)
            {
                unMunicipio.NombreCuenca = cuencaNueva;
                miColeccion.ReplaceOne(documento => documento.Id == unMunicipio.Id, unMunicipio);
            }
        }

        public static void ActualizarCuencaEnActividades(string cuencaAntigua, string cuencaNueva)
        {
            // Obtener actividades de la cuenca anterior
            List<Actividad> actividadesActualizables = ObtenerListaActividadesPorCuenca(cuencaAntigua);

            // Se actualiza nuevamente en la base de datos
            var clienteDB = new MongoClient(configDB.ConnectionString);
            var miDB = clienteDB.GetDatabase(configDB.DatabaseName);
            var coleccionActividades = configDB.ActividadesCollectionName;

            var miColeccion = miDB.GetCollection<Actividad>(coleccionActividades);

            // A cada uno de ellos, se le cambia el nombre de la cuenca
            foreach (Actividad unaActividad in actividadesActualizables)
            {
                unaActividad.NombreCuenca = cuencaNueva;
                miColeccion.ReplaceOne(documento => documento.Id == unaActividad.Id, unaActividad);
            }
        }

        public static bool EliminarCuenca(Cuenca unaCuenca, out string mensajeEliminacion)
        {
            mensajeEliminacion = string.Empty;

            //Buscamos primero si ya existe una cuenca registrada con ese ID
            Cuenca cuencaExistente = ObtenerCuenca(unaCuenca.Id!);

            if (string.IsNullOrEmpty(cuencaExistente.Id))
            {
                mensajeEliminacion = $"Error de eliminación. No existe una cuenca para eliminar con ese ID";
                return false;
            }

            //Validar si hay actividades asociadas a la cuenca a eliminar
            int cantidadActividadesCuenca = ObtenerCantidadActividadesPorCuenca(unaCuenca.Nombre!);

            if (cantidadActividadesCuenca > 0)
            {
                mensajeEliminacion = $"No se puede eliminar cuenca {unaCuenca.Nombre} porque tiene " +
                    $"asociadas {cantidadActividadesCuenca} actividades de pesca";
                return false;
            }

            //Validar si hay municipios asociados al departamento a eliminar
            int cantidadMunicipiosCuenca = ObtenerCantidadMunicipiosCuenca(unaCuenca.Nombre!);
            if (cantidadMunicipiosCuenca > 0)
            {
                mensajeEliminacion = $"No se puede eliminar cuenca {unaCuenca.Nombre} porque tiene " +
                    $"asociados {cantidadMunicipiosCuenca} municipios";
                return false;
            }

            var clienteDB = new MongoClient(configDB.ConnectionString);
            var miDB = clienteDB.GetDatabase(configDB.DatabaseName);
            var coleccionCuenca = configDB.CuencasCollectionName;

            var miColeccion = miDB.GetCollection<Cuenca>(coleccionCuenca);
            var resultadoEliminacion = miColeccion.DeleteOne(documento => documento.Id == unaCuenca.Id);

            if (!resultadoEliminacion.IsAcknowledged)
                mensajeEliminacion = $"Error al eliminar la cuenca {unaCuenca.Nombre} ";
            else
                mensajeEliminacion = $"La cuenca {unaCuenca.Nombre} fue eliminada";

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
