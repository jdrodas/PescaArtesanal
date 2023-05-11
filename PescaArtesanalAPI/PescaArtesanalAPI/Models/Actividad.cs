using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Text.Json.Serialization;

namespace PescaArtesanalAPI.Models
{
    public class Actividad
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonPropertyName("Id")]
        public string? Id { get; set; }

        [BsonElement("nombre_municipio")]
        [JsonPropertyName("NombreMunicipio")]
        public string NombreMunicipio { get; set; } = null!;

        [BsonElement("nombre_departamento")]
        [JsonPropertyName("NombreDepartamento")]
        public string NombreDepartamento { get; set; } = null!;

        [BsonElement("nombre_cuenca")]
        [JsonPropertyName("NombreCuenca")]
        public string NombreCuenca { get; set; } = null!;

        [BsonElement("nombre_metodo")]
        [JsonPropertyName("NombreMetodo")]
        public string NombreMetodo { get; set; } = null!;

        [BsonElement("cantidad_pescado")]
        [JsonPropertyName("CantidadPescado")]
        public double CantidadPescado { get; set; }

        [BsonElement("fecha")]
        [JsonPropertyName("Fecha")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime Fecha { get; set; }
    }
}
