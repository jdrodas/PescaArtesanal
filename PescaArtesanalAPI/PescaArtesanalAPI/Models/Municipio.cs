using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Text.Json.Serialization;

namespace PescaArtesanalAPI.Models
{
    public class Municipio
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonPropertyName("Id")]
        public string? Id { get; set; }

        [BsonElement("nombre")]
        public string Nombre { get; set; } = null!;

        [BsonElement("nombre_cuenca")]
        public string NombreCuenca { get; set; } = null!;

        [BsonElement("nombre_departamento")]
        public string NombreDepartamento { get; set; } = null!;
    }
}