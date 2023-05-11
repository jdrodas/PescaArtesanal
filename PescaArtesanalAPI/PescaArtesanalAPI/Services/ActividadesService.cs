using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using PescaArtesanalAPI.Models;

namespace PescaArtesanalAPI.Services
{
    public class ActividadesService
    {
        private readonly IMongoCollection<Actividad> _actividadesCollection;

        public ActividadesService(IOptions<PescaArtesanalDatabaseSettings> PescaArtesanalDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                PescaArtesanalDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                PescaArtesanalDatabaseSettings.Value.DatabaseName);

            _actividadesCollection = mongoDatabase.GetCollection<Actividad>(
                PescaArtesanalDatabaseSettings.Value.ActividadesCollectionName);
        }

        public async Task<List<Actividad>> GetAsync()
        {
            var lasActividades = await _actividadesCollection
                .Find(_ => true)
                .SortBy(actividad => actividad.NombreCuenca)
                .ToListAsync();

            return lasActividades;
        }

        public async Task<Actividad> GetAsync(string id)
        {
            var unaActividad = await _actividadesCollection
                .Find(actividad => actividad.Id == id)
                .FirstOrDefaultAsync();

            return unaActividad;
        }

        public async Task CreateAsync(Actividad unaActividad)
        {
            await _actividadesCollection
                .InsertOneAsync(unaActividad);
        }

        public async Task UpdateAsync(string id, Actividad unaActividad)
        {
            await _actividadesCollection
                .ReplaceOneAsync(actividad => actividad.Id == id, unaActividad);
        }

        public async Task RemoveAsync(string id)
        {
            await _actividadesCollection
                .DeleteOneAsync(cuenca => cuenca.Id == id);
        }
    }
}
