namespace PescaArtesanal_PoC_NoSQL_Console
{
    public class PescaArtesanalDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string DepartamentosCollectionName { get; set; } = null!;

        public string MunicipiosCollectionName { get; set; } = null!;

        public string CuencasCollectionName { get; set; } = null!;

        public string MetodosCollectionName { get; set; } = null!;
    }
}
