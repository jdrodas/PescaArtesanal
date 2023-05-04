using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Text.Json.Serialization;

namespace PescaArtesanalAPI.Models
{
    public class Departamento
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonPropertyName("Id")]
        public string? Id { get; set; }

        [BsonElement("nombre")]
        [JsonPropertyName("Nombre")]
        public string? Nombre { get; set; }

        public Departamento()
        {
            Id = string.Empty;
            Nombre = string.Empty;
        }
    }
}