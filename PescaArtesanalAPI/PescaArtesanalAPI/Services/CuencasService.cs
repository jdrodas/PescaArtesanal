using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using PescaArtesanalAPI.Models;

namespace PescaArtesanalAPI.Services
{
    public class CuencasService
    {
        private readonly IMongoCollection<Cuenca> _cuencasCollection;

        public CuencasService(IOptions<PescaArtesanalDatabaseSettings> PescaArtesanalDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                PescaArtesanalDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                PescaArtesanalDatabaseSettings.Value.DatabaseName);

            _cuencasCollection = mongoDatabase.GetCollection<Cuenca>(
                PescaArtesanalDatabaseSettings.Value.CuencasCollectionName);
        }

        public async Task<List<Cuenca>> GetAsync()
        {
            var lasCuencas = await _cuencasCollection
                .Find(_ => true)
                .SortBy(cuenca => cuenca.Nombre)
                .ToListAsync();

            return lasCuencas;
        }

        public async Task<Cuenca> GetAsync(string id)
        {
            var unaCuenca = await _cuencasCollection
                .Find(cuenca => cuenca.Id == id)
                .FirstOrDefaultAsync();
            
            return unaCuenca;
        }

        public async Task CreateAsync(Cuenca unaCuenca)
        {
            await _cuencasCollection
                .InsertOneAsync(unaCuenca);
        }

        public async Task UpdateAsync(string id, Cuenca unaCuenca)
        {
            await _cuencasCollection
                .ReplaceOneAsync(cuenca => cuenca.Id == id, unaCuenca);
        }

        public async Task RemoveAsync(string id)
        {
            await _cuencasCollection
                .DeleteOneAsync(cuenca => cuenca.Id == id);
        }
    }
}
