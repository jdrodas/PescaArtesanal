using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace PescaArtesanal_NoSQL_WindowsForms.Modelos
{
    public class Actividad
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("nombre_municipio")]
        public string? NombreMunicipio { get; set; }

        [BsonElement("nombre_departamento")]
        public string? NombreDepartamento { get; set; }

        [BsonElement("nombre_cuenca")]
        public string? NombreCuenca { get; set; }

        [BsonElement("nombre_metodo")]
        public string? NombreMetodo { get; set; }

        [BsonElement("cantidad_pescado")]
        public double CantidadPescado { get; set; }

        [BsonElement("fecha")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime Fecha { get; set; }

        public Actividad()
        {
            Id = string.Empty;
            NombreMunicipio = string.Empty;
            NombreDepartamento = string.Empty;
            NombreCuenca = string.Empty;
            NombreMetodo = string.Empty;
            CantidadPescado = 0;
            Fecha = new DateTime();
        }
    }
}