using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PescaArtesanal_WindowsForms.Modelos
{
    public class Municipio
    {
        public int Codigo { get; set; }
        public string? Nombre { get; set; }
        public int CodigoDepartamento { get; set; }
        public string? NombreDepartamento { get; set; }
        public int CodigoCuenca { get; set; }
        public string? NombreCuenca { get; set; }

        public Municipio()
        {
            Codigo = 0;
            CodigoCuenca = 0;
            CodigoDepartamento = 0;
            Nombre = string.Empty;
            NombreDepartamento = string.Empty;
            NombreCuenca = string.Empty;
        }
    }
}
