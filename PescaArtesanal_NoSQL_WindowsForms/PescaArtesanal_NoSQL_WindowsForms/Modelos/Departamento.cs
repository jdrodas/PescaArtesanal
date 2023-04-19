using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace PescaArtesanal_NoSQL_WindowsForms.Modelos
{
    public class Departamento
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("nombre")]
        public string? Nombre { get; set; }

        public Departamento()
        {
            Id = string.Empty;
            Nombre = string.Empty;
        }
    }
}