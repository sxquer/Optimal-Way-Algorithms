using System;
using System.IO;

namespace ShortestWay
{
    internal class Ford
    {
        internal struct Edge
        {
            public int StartNode { get; set; }
            public int FinishNode { get; set; }
            public int Weight { get; set; }
        }

        private const int INF = 999;

        public Edge[] Edges { get; set; }
        private int[] Distance { get; set; }
        private int EdgeCount { get; set; }
        private int NodeCount { get; set; }

        public Ford(string filename)
        {
            var sr = new StreamReader(filename);
            EdgeCount = int.Parse(sr.ReadLine());
            NodeCount = int.Parse(sr.ReadLine());

            Edges = new Edge[EdgeCount];

            string[] res = sr.ReadToEnd().Replace("\r\n", " ").Split(new Char[] { ' ' });

            for (int i = 0; i < EdgeCount; i++)
            {
                Edges[i].StartNode = Convert.ToInt32(res[i * 3]);
                Edges[i].FinishNode = Convert.ToInt32(res[i * 3 + 1]);
                Edges[i].Weight = Convert.ToInt32(res[i * 3 + 2]);
            }
        }

        public int GetShortestDistance(int startNode, int finishNode)
        {
            Distance = new int[NodeCount];
            for (int i = 0; i < NodeCount; i++)
            {
                Distance[i] = INF;
            }

            Distance[startNode] = 0;

            for (int i = 0; i < NodeCount - 1; i++)
            {
                for (int j = 0; j < EdgeCount; j++)
                {
                    if (Distance[Edges[j].StartNode] < INF)
                        Distance[Edges[j].FinishNode] = Math.Min(Distance[Edges[j].FinishNode], Distance[Edges[j].StartNode] + Edges[j].Weight);
                }
            }
            

            return Distance[finishNode];
        }

        public void Echo(int start, int finish)
        {
            Console.Out.WriteLine("Начало: {0}, Конец: {1}", start, finish);
            Console.Out.WriteLine("Минимальное расстояние: " + GetShortestDistance(start, finish));
            Console.Out.WriteLine("---------------------------------");
        }
    }


}