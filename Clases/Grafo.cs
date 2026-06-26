using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class Grafo
    {
        ListaSimple l_vertices = new ListaSimple();
        int[,] ma;
        string[] nom_ciudades = { "RESTAURANTE CENTRAL", "CLIENTE ZONA NORTE", "RESTAURANTE SUR", "CLIENTE ZONA ESTE", "HUB DESPACHO KFC", "CLIENTE ZONA OESTE", "BURGER KING CENTRO", "CLIENTE CONDOMINIO" };
        string[] climas = { "RESTAURANTE", "CLIENTE", "RESTAURANTE", "CLIENTE", "RESTAURANTE", "CLIENTE", "RESTAURANTE", "CLIENTE" };
        public Grafo(int cant)
        {
            Random r = new Random();
            for (int i = 0; i < cant; i++)
            {
                Ciudad c = new Ciudad();
                c.nombre = nom_ciudades[i];
                c.tipo_pedido = climas[i];
                c.temperatura = r.Next(10, 30);
                l_vertices.Insertar(c);
            }
            ma = new int[cant, cant];
        }
        public Vertice Inicio()
        {
            return l_vertices.primero;
        }
        public void GenerarMatriz()
        {
            Random r = new Random();
            for (int i = 0; i < ma.GetLength(0); i++)
            {
                int conexiones = 0;
                for (int j = 0; j < ma.GetLength(1); j++)
                {
                    if (i == j)
                    {
                        ma[i, j] = 0;
                    }
                    else
                    {
                        ma[i, j] = r.Next(0, 2);
                        if (ma[i, j] == 1) conexiones++;
                    }
                }
                if (conexiones == 0)
                {
                    int forzado = (i + 1) % ma.GetLength(0);
                    ma[i, forzado] = 1;
                }
            }
        }
        public void MostrarMatriz()
        {
            for (int i = 0; i < ma.GetLength(0); i++)
            {
                for (int j = 0; j < ma.GetLength(1); j++)
                {
                    Console.Write(ma[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
        public void CrearGrafo()
        {
            Random r = new Random();
            Vertice temp_i = l_vertices.primero;
            for (int i = 0; i < ma.GetLength(0); i++)
            {
                Vertice temp_j = l_vertices.primero;
                for (int j = 0; j < ma.GetLength(1); j++)
                {
                    if (ma[i, j] == 1)
                    {
                        temp_i.ls.Insertar(temp_j, r.Next(100, 500));
                    }
                    temp_j = temp_j.sig;
                }
                temp_i = temp_i.sig;
            }
        }
        public void Recorrer(Vertice v, ref float total)
        {
            v.visitado = true;
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("--------------------------------");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Punto actual: \n" + v.dato + "\n");
            Console.ResetColor();
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Viajes disponibles: ");
            v.ls.Mostrar();
            Console.WriteLine("--------------------------------");
            Console.Write("Ingrese el numero al que desea viajar (0 para salir): ");
            int total_opciones = 0;
            Arista contar = v.ls.primero;
            while (contar != null)
            {
                total_opciones++;
                contar = contar.sig;
            }
            int op;
            while (!int.TryParse(Console.ReadLine(), out op) || op < 0 || op > total_opciones)
            {
                Console.Write("Invalido. Ingrese un numero correcto: ");
            }
            if (op == 0) return;
            Arista temp = v.ls.primero;
            for (int i = 1; i < op; i++)
            {
                temp = temp.sig;
            }
            total = total + temp.peso;
            Recorrer(temp.destino, ref total);
        }
    }
}