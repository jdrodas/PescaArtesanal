using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace PescaArtesanal_PoC_NoSQL_Console
{
    public class Metodo
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("codigo")]
        public int Codigo { get; set; }

        [BsonElement("nombre")]
        public string Nombre { get; set; }

        public Metodo()
        {
            Id = string.Empty;
            Codigo = 0;
            Nombre = string.Empty;
        }
    }
}

