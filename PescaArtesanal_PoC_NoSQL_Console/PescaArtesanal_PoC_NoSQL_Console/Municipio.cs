using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace PescaArtesanal_PoC_NoSQL_Console
{
    public class Municipio
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("codigo")]
        public int Codigo { get; set; }

        [BsonElement("nombre_municipio")]
        public string Nombre { get; set; }

        [BsonElement("nombre_cuenca")]
        public string NombreCuenca { get; set; }

        [BsonElement("nombre_departamento")]
        public string NombreDepartamento { get; set; }

        public Municipio()
        {
            Id = string.Empty;
            Codigo = 0;
            Nombre = string.Empty;
            NombreCuenca = string.Empty;
            NombreDepartamento = string.Empty;
        }
    }
}
