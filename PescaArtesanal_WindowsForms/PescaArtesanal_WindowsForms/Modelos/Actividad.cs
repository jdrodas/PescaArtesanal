namespace PescaArtesanal_WindowsForms.Modelos
{
    public class Actividad
    {
        public int Codigo { get; set; }
        public int CodigoMunicipio { get; set; }
        public string? NombreMunicipio { get; set; }
        public int CodigoMetodo { get; set; }
        public string? NombreMetodo { get; set; }
        public int CodigoDepartamento { get; set; }
        public string? NombreDepartamento { get; set; }

        public string? Fecha { get; set; }
        public double CantidadPescado { get; set; }


        public Actividad()
        {
            Codigo = 0;
            CodigoMunicipio = 0;
            CodigoMetodo = 0;
            CodigoDepartamento = 0;
            CantidadPescado = 0;
            NombreMunicipio = string.Empty;
            NombreMetodo = string.Empty;
            NombreDepartamento = string.Empty;
            Fecha = string.Empty;
        }
    }
}
