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
        string[] nom_ciudades = { "RESTAURANTE CENTRAL", "CLIENTE NORTE", "RESTAURANTE SUR", "CLIENTE ESTE", "HUB DESPACHO", "CLIENTE OESTE", "RESTAURANTE CENTRO", "CLIENTE CONDOCENTRO" };
        string[] climas = { "URGENTE", "NORMAL", "EXPRESS", "PROGRAMADO", "URGENTE", "NORMAL", "EXPRESS", "URGENTE" };
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
                for (int j = 0; j < ma.GetLength(1); j++)
                {
                    ma[i, j] = r.Next(0, 2);
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
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("================================================");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("REPARTIDOR UBICADO EN:\n" + v.dato + "\n");
            Console.ResetColor();
            Console.WriteLine("================================================");
            Console.WriteLine("Rutas de envío directo disponibles desde aquí: ");
            v.ls.Mostrar();
            Console.WriteLine("================================================");
            Console.Write("Seleccione el número de la siguiente entrega (0 para finalizar): ");
            int op = int.Parse(Console.ReadLine());
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