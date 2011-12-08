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
            var graph = new Dijkstra("Dijkstra1.txt");
            graph.Echo(1, 4);
            graph.Echo(4, 0);
            
            graph = new Dijkstra("Dijkstra2.txt");
            graph.Echo(0, 2);

            Console.Out.WriteLine("Алгоритм Флойда \n");
            var graph2 = new Floyd("Floyd1.txt");
            graph2.Echo();

            Console.Out.WriteLine("Алгоритм Форда \n");
            var graph3 = new Ford("Ford1.txt");
            graph3.Echo(0, 5);
            graph3.Echo(4, 0);

            Console.Read();
        }


    }
}
