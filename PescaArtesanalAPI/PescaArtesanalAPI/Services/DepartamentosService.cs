using Microsoft.Extensions.Options;
using MongoDB.Driver;
using PescaArtesanalAPI.Models;

namespace PescaArtesanalAPI.Services
{
    public class DepartamentosService
    {
        private readonly IMongoCollection<Departamento> _departamentosCollection;

        public DepartamentosService(IOptions<PescaArtesanalDatabaseSettings> PescaArtesanalDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                PescaArtesanalDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                PescaArtesanalDatabaseSettings.Value.DatabaseName);

            _departamentosCollection = mongoDatabase.GetCollection<Departamento>(
                PescaArtesanalDatabaseSettings.Value.DepartamentosCollectionName);
        }

        public async Task<List<Departamento>> GetAsync()
        {
            //Esto equivale a un metodo llamado ObtenerDepartamentos
            var losContratistas = await _departamentosCollection.Find(_ => true).ToListAsync();
            return losContratistas;
        }

        public async Task<Departamento> GetAsync(string id)
        {
            //Esto equivale a un metodo llamado ObtenerDepartamento por ID
            var unContratista = await _departamentosCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
            return unContratista;
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
