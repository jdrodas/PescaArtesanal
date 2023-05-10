﻿using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using PescaArtesanalAPI.Models;

namespace PescaArtesanalAPI.Services
{
    public class DepartamentosService
    {
        private readonly IMongoCollection<Departamento> _departamentosCollection;
        private readonly IMongoCollection<Municipio> _municipiosCollection;

        public DepartamentosService(IOptions<PescaArtesanalDatabaseSettings> PescaArtesanalDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                PescaArtesanalDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                PescaArtesanalDatabaseSettings.Value.DatabaseName);

            _departamentosCollection = mongoDatabase.GetCollection<Departamento>(
                PescaArtesanalDatabaseSettings.Value.DepartamentosCollectionName);

            _municipiosCollection = mongoDatabase.GetCollection<Municipio>(
                PescaArtesanalDatabaseSettings.Value.MunicipiosCollectionName);
        }

        public async Task<List<Departamento>> GetAsync()
        {
            //Esto equivale a un metodo llamado ObtenerDepartamentos que devuelve una lista de Departamentos
            var losDepartamentos = await _departamentosCollection
                .Find(_ => true)
                .SortBy(departamento => departamento.Nombre)
                .ToListAsync();

            return losDepartamentos;
        }

        public async Task<List<Municipio>> GetMunicipiosDelDepartamento(string nombreDepartamento)
        {


            //Esto equivale a un metodo llamado ObtenerDepartamentos que devuelve una lista de Departamentos
            var filtroDepartamento = new BsonDocument { { "nombre_departamento", nombreDepartamento } };

            var losMunicipios = await _municipiosCollection
                .Find(filtroDepartamento)
                .SortBy(Municipio => Municipio.Nombre)
                .ToListAsync();

            return losMunicipios;
        }

        public async Task<Departamento> GetAsync(string id)
        {
            //Esto equivale a un metodo llamado ObtenerDepartamento por ID
            var unDepartamento = await _departamentosCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
            return unDepartamento;
        }

        public async Task CreateAsync(Departamento unDepartamento)
        {
            await _departamentosCollection.InsertOneAsync(unDepartamento);
        }

        public async Task UpdateAsync(string id, Departamento unDepartamento)
        {
            await _departamentosCollection.ReplaceOneAsync(x => x.Id == id, unDepartamento);
        }

        public async Task RemoveAsync(string id)
        {
            await _departamentosCollection.DeleteOneAsync(x => x.Id == id);
        }
    }
}
