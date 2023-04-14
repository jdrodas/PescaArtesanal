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

            Console.WriteLine("\nDepartamentos en la DB:");
            List<Departamento> listaDepartamentos = AccesoDatos.ObtenerListaDepartamentos();

            foreach (Departamento unDepto in listaDepartamentos)
                Console.WriteLine($" - {unDepto.Nombre}");

            Console.WriteLine("\nMunicipios en el departamento de Antioquia");
            List<Municipio> listaMunicipios = AccesoDatos.ObtenerListaMunicipios("Antioquia");

            foreach (Municipio unMpio in listaMunicipios)
                Console.WriteLine($" - {unMpio.Nombre} en la cuenca {unMpio.NombreCuenca}");

            Console.WriteLine("\nCuencas en la DB:");
            List<Cuenca> listaCuencas = AccesoDatos.ObtenerListaCuencas();

            foreach (Cuenca laCuenca in listaCuencas)
                Console.WriteLine($" - {laCuenca.Nombre}");

            //Aqui insertamos una nueva cuenca
            Cuenca unaCuenca = new Cuenca
            {
                Codigo = 10,
                Nombre = "Orinoco"
            };

            bool resultadoInsercion = AccesoDatos.InsertarCuenca(unaCuenca);

            if (resultadoInsercion)
                Console.WriteLine($"Cuenca insertada correctamente.");
            else
                Console.WriteLine($"Error al insertar cuenca");


            //Aqui verificamos que esté insertada
            listaCuencas = AccesoDatos.ObtenerListaCuencas();

            Console.WriteLine("\nCuencas en la DB luego de la inserción:");
            foreach (Cuenca laCuenca in listaCuencas)
                Console.WriteLine($" - {laCuenca.Nombre}");

            //Aqui actualizamos la cuenca
            unaCuenca.Nombre = "Gran Orinoco";

            bool resultadoActualizacion = AccesoDatos.ActualizarCuenca(unaCuenca);

            if (resultadoActualizacion)
                Console.WriteLine($"Cuenca actualizada correctamente. Ahora se llama {unaCuenca.Nombre}");
            else
                Console.WriteLine($"Error al actualizar cuenca");

            //Aqui verificamos que esté actualizada
            listaCuencas = AccesoDatos.ObtenerListaCuencas();

            Console.WriteLine("\nCuencas en la DB luego de la actualización:");
            foreach (Cuenca laCuenca in listaCuencas)
                Console.WriteLine($" - {laCuenca.Nombre}");

            //Aqui borramos la cuenca
            bool resultadoEliminacion = AccesoDatos.EliminarCuenca(unaCuenca);

            if (resultadoEliminacion)
                Console.WriteLine($"Cuenca eliminada correctamente.");
            else
                Console.WriteLine($"Error al eliminar cuenca");

            //Aqui verificamos que esté actualizada
            listaCuencas = AccesoDatos.ObtenerListaCuencas();
            Console.WriteLine("\nCuencas en la DB luego de la eliminación:");
            
            foreach (Cuenca laCuenca in listaCuencas)
                Console.WriteLine($" - {laCuenca.Nombre}");

            // Operaciones CRUD con los Métodos de Pesca

            Console.WriteLine("\nMétodos en la DB:");
            List<Metodo> listaMetodos = AccesoDatos.ObtenerListaMetodos();

            foreach (Metodo elMetodo in listaMetodos)
                Console.WriteLine($" - {elMetodo.Nombre}");

            //Aqui insertamos una nuevo Metodo
            Metodo unMetodo = new Metodo
            {
                Codigo = 15,
                Nombre = "Cauchera"
            };

            resultadoInsercion = AccesoDatos.InsertarMetodo(unMetodo);

            if (resultadoInsercion)
                Console.WriteLine($"Método insertado correctamente.");
            else
                Console.WriteLine($"Error al insertar Método");


            //Aqui verificamos que esté insertado
            listaMetodos = AccesoDatos.ObtenerListaMetodos();

            Console.WriteLine("\nMétodos en la DB luego de la inserción:");
            foreach (Metodo elMetodo in listaMetodos)
                Console.WriteLine($" - {elMetodo.Nombre}");

            //Aqui actualizamos el nombre del método de pesca
            unMetodo.Nombre = "Cauchera con Poliuretano";

            resultadoActualizacion = AccesoDatos.ActualizarMetodo(unMetodo);

            if (resultadoActualizacion)
                Console.WriteLine($"Método actualizado correctamente. Ahora se llama {unMetodo.Nombre}");
            else
                Console.WriteLine($"Error al actualizar cuenca");

            //Aqui verificamos que esté actualizado
            listaMetodos = AccesoDatos.ObtenerListaMetodos();

            Console.WriteLine("\nMétodos en la DB luego de la actualización:");
            foreach (Metodo elMetodo in listaMetodos)
                Console.WriteLine($" - {elMetodo.Nombre}");

            //Aqui borramos el método de pesca
            resultadoEliminacion = AccesoDatos.EliminarMetodo(unMetodo);

            if (resultadoEliminacion)
                Console.WriteLine($"Método eliminado correctamente.");
            else
                Console.WriteLine($"Error al eliminar método");

            //Aqui verificamos que esté eliminado
            listaMetodos = AccesoDatos.ObtenerListaMetodos();

            Console.WriteLine("\nMétodo en la DB luego de la eliminación:");

            foreach (Metodo elMetodo in listaMetodos)
                Console.WriteLine($" - {elMetodo.Nombre}");

        }
    }
}