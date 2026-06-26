using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases;

namespace Ejecucion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Cantidad de puntos de entrega / locales: ");
            int cant = int.Parse(Console.ReadLine());
            Grafo g = new Grafo(cant);
            g.GenerarMatriz();
            Console.WriteLine("\n--- MAPA DE LOGÍSTICA (MATRIZ DE CONEXIONES) ---");
            g.MostrarMatriz();
            g.CrearGrafo();
            float total_recorrido = 0;

            g.Recorrer(g.Inicio(), ref total_recorrido);

            Console.WriteLine("\n================================================");
            Console.WriteLine("Jornada terminada. Distancia total: " + total_recorrido + " metros");
            Console.WriteLine("================================================");
        }
    }
}