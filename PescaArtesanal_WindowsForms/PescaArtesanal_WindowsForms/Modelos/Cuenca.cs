namespace PescaArtesanal_WindowsForms.Modelos
{
    public class Cuenca
    {
        public int Codigo { get; set; }
        public string? Nombre { get; set; }

        public Cuenca()
        {
            Codigo = 0;
            Nombre = string.Empty;
        }
    }
}
