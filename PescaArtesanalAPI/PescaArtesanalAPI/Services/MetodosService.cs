using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using PescaArtesanalAPI.Models;

namespace PescaArtesanalAPI.Services
{
    public class MetodosService
    {
        private readonly IMongoCollection<Metodo> _metodosCollection;

        public MetodosService(IOptions<PescaArtesanalDatabaseSettings> PescaArtesanalDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                PescaArtesanalDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                PescaArtesanalDatabaseSettings.Value.DatabaseName);

            _metodosCollection = mongoDatabase.GetCollection<Metodo>(
                PescaArtesanalDatabaseSettings.Value.MetodosCollectionName);
        }

        public async Task<List<Metodo>> GetAsync()
        {
            var losMetodos = await _metodosCollection
                .Find(_ => true)
                .SortBy(metodo => metodo.Nombre)
                .ToListAsync();

            return losMetodos;
        }

        public async Task<Metodo> GetAsync(string id)
        {
            var unMetodo = await _metodosCollection
                .Find(metodo => metodo.Id == id)
                .FirstOrDefaultAsync();
            return unMetodo;
        }

        public async Task CreateAsync(Metodo unMetodo)
        {
            await _metodosCollection
                .InsertOneAsync(unMetodo);
        }

        public async Task UpdateAsync(string id, Metodo unMetodo)
        {
            await _metodosCollection
                .ReplaceOneAsync(metodo => metodo.Id == id, unMetodo);
        }

        public async Task RemoveAsync(string id)
        {
            await _metodosCollection
                .DeleteOneAsync(metodo => metodo.Id == id);
        }
    }
}
