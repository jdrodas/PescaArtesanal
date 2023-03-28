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
        public int CodigoCuenca { get; set; }
        public string? NombreCuenca { get; set; }
        public string? Fecha { get; set; }
        public double CantidadPescado { get; set; }


        public Actividad()
        {
            Codigo = 0;
            CodigoMunicipio = 0;
            CodigoMetodo = 0;
            CodigoDepartamento = 0;
            CodigoCuenca = 0;
            CantidadPescado = 0;
            NombreMunicipio = string.Empty;
            NombreMetodo = string.Empty;
            NombreCuenca = string.Empty;
            NombreDepartamento = string.Empty;
            Fecha = string.Empty;
        }

        public override string ToString()
        {
            return string.Format(
                $"Código Actividad: {Codigo} " + Environment.NewLine +
                $"Nombre Departamento: {NombreDepartamento} " + Environment.NewLine +
                $"Nombre Municipio: {NombreMunicipio} " + Environment.NewLine +
                $"Nombre Cuenca: {NombreCuenca} " + Environment.NewLine +
                $"Nombre Método: {NombreMetodo} " + Environment.NewLine +
                $"Cantidad Pescado: {CantidadPescado.ToString(".00")} " + Environment.NewLine +
                $"Fecha: {Fecha} " + Environment.NewLine);
        }
    }
}
