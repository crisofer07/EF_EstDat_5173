using Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Ejecucion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Ingrese cantidad de puntos de entrega: ");
            int cant = int.Parse(Console.ReadLine());
            Grafo g = new Grafo(cant);
            g.GenerarMatriz();
            g.MostrarMatriz();
            g.CrearGrafo();
            float total_recorrido = 0;

            g.Recorrer(g.Inicio(), ref total_recorrido);

            Console.WriteLine("Total recorrido: " + total_recorrido);
        }
    }
}