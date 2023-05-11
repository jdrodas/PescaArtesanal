using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Text.Json.Serialization;

namespace PescaArtesanalAPI.Models
{
    public class Cuenca
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonPropertyName("Id")]
        public string? Id { get; set; }

        [BsonElement("nombre")]
        [JsonPropertyName("Nombre")]
        public string Nombre { get; set; } = null!;
    }
}
