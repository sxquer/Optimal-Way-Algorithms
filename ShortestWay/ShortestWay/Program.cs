using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShortestWay
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Out.WriteLine("Алгоритм Дейкстры \n");
            var graph = new Dijkstra("input1.txt");
          
            Console.Out.WriteLine("Минимальное расстояние: " + graph.GetShortestDistance(1, 4));
            Console.Out.WriteLine("Оптимальный путь: " + graph.Way);
            Console.Out.WriteLine("---------------------------------");

            Console.Out.WriteLine("Минимальное расстояние: " + graph.GetShortestDistance(4, 0));
            Console.Out.WriteLine("Оптимальный путь: " + graph.Way);
            Console.Out.WriteLine("---------------------------------");

            graph = new Dijkstra("input2.txt");
            Console.Out.WriteLine("Минимальное расстояние: " + graph.GetShortestDistance(0, 2));
            Console.Out.WriteLine("Оптимальный путь: " + graph.Way);
            Console.Out.WriteLine("---------------------------------");

            Console.Read();
        }


    }
}
