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
            float total_recorrido=0;
            
            g.Recorrer(g.GetInicio(),ref total_recorrido);

            Console.WriteLine("Total recorrido: "+total_recorrido);
        }
    }
}