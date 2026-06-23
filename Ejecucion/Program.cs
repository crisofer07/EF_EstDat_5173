using Clases;

namespace Ejecucion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Ingrese cantidad de ciudades: ");
            int cant = int.Parse(Console.ReadLine());
            Grafo g = new Grafo(cant);
            g.GenerarMatriz();
            g.MostrarMatriz();
            g.CrearGrafo();
            g.Recorrer(g.GetInicio());
        }
    }
}