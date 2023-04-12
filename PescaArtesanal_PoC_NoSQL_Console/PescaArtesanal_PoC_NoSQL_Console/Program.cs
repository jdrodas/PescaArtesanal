using Microsoft.Extensions.Configuration;

namespace PescaArtesanal_PoC_NoSQL_Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("PoC para demostrar acciones CRUD en MongoDB\n");
            Console.WriteLine($"La cadena de conexión a utilizar es {AccesoDatos.ObtenerDBSettings().ConnectionString}");
            Console.WriteLine($"La DB a utilizar es :{AccesoDatos.ObtenerDBSettings().DatabaseName}");

            List<Departamento> listaDepartamentos = AccesoDatos.ObtenerListaDepartamentos();

            Console.WriteLine("\nDepartamentos en la DB:");

            foreach (Departamento unDepto in listaDepartamentos)
                Console.WriteLine($"{unDepto.Nombre}");
        }
    }
}