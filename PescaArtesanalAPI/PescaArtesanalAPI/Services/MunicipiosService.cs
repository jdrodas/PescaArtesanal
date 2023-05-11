using Microsoft.Extensions.Options;
using MongoDB.Driver;
using PescaArtesanalAPI.Models;

namespace PescaArtesanalAPI.Services
{
    public class MunicipiosService
    {
        private readonly IMongoCollection<Municipio> _municipiosCollection;

        public MunicipiosService(IOptions<PescaArtesanalDatabaseSettings> PescaArtesanalDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                PescaArtesanalDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                PescaArtesanalDatabaseSettings.Value.DatabaseName);

            _municipiosCollection = mongoDatabase.GetCollection<Municipio>(
                PescaArtesanalDatabaseSettings.Value.MunicipiosCollectionName);
        }

        public async Task<List<Municipio>> GetAsync()
        {
            var losMunicipios = await _municipiosCollection
                .Find(_ => true)
                .SortBy(municipio => municipio.Nombre)
                .ToListAsync();

            return losMunicipios;
        }

        public async Task<Municipio> GetAsync(string id)
        {
            var unMunicipio = await _municipiosCollection
                .Find(municipio => municipio.Id == id)
                .FirstOrDefaultAsync();
            
            return unMunicipio;
        }

        public async Task CreateAsync(Municipio unMunicipio)
        {
            await _municipiosCollection
                .InsertOneAsync(unMunicipio);
        }

        public async Task UpdateAsync(string id, Municipio unMunicipio)
        {
            await _municipiosCollection
                .ReplaceOneAsync(municipio => municipio.Id == id, unMunicipio);
        }

        public async Task RemoveAsync(string id)
        {
            await _municipiosCollection
                .DeleteOneAsync(x => x.Id == id);
        }
    }
}
