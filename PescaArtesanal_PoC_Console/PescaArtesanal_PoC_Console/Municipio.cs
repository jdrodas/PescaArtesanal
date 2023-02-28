using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PescaArtesanal_PoC_Console
{
    public class Municipio
    {
        public int Codigo { get; set; }
        public string? Nombre { get; set; }
        public int Codigo_Departamento { get; set; }
        public string? Nombre_Departamento { get; set; }
        public int Codigo_Cuenca { get; set; }
        public string? Nombre_Cuenca { get; set; }

        public Municipio()
        {
            Codigo = 0;
            Codigo_Cuenca = 0;
            Codigo_Departamento = 0;
            Nombre = string.Empty;
            Nombre_Departamento = string.Empty;
            Nombre_Cuenca = string.Empty;
        }
    }
}