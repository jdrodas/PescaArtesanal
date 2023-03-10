namespace PescaArtesanal_WindowsForms.Modelos
{
    public class Departamento
    {
        public int Codigo { get; set; }
        public string? Nombre { get; set; }

        public Departamento()
        {
            Codigo = 0;
            Nombre = string.Empty;
        }
    }
}
