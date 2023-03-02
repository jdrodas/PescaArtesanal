using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PescaArtesanal_PoC_Console
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
