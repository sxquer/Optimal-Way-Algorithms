using System;
using System.Collections.Generic;
using System.IO;

namespace ShortestWay
{
    class Dijkstra
    {
        public int[,] GraphMatrix { get; set; }
        public string Way { get; private set; }

        private bool IsCalculatable { get; set; }
        private int[] Distance { get; set; }
        private bool[] IsBlooked { get; set; }
        private int[] Parents { get; set; }
        private int Length { get; set; }

        public Dijkstra(string filename)
        {
            var sr = new StreamReader(filename);
            Length = int.Parse(sr.ReadLine());

            GraphMatrix = new int[Length, Length];
            
            string[] res = sr.ReadToEnd().Replace("\r\n", " ").Split(new Char[] { ' ' });
            for (int i = 0; i < Length; i++)
            {
                for (int j = 0; j < Length; j++)
                {
                    GraphMatrix[i, j] = Convert.ToInt32(res[i * Length + j]);
                }
            }
        }

        private bool DoNodeExist(int nodeId)
        {
            if (nodeId >= Length || nodeId < 0)
            {
                Console.Out.WriteLine("Узел {0} не найден!", nodeId);
                return false;
            }
            return true;
        }

        private bool NeedStop()
        {
            bool result = true;
            int shortestDistance = int.MaxValue;

            for (int i = 0; i < Length; i++)
            {
                if (!IsBlooked[i])
                {
                    shortestDistance = (Distance[i] < shortestDistance) ? Distance[i] : shortestDistance;
                    result = false;
                }
            }

            if (shortestDistance == int.MaxValue)
            {
                if (result) Console.Out.WriteLine("Готово!");
                else
                {
                    result = true;
                    Console.Out.WriteLine("Граф не связан!");
                    IsCalculatable = false;
                }
                
            }
            return result;
        }

        private int SelectNextNode()
        {
            int curDistance = int.MaxValue;
            int curNode = -1;
            for (int i = 0; i < Length; i++)
            {
                if (!IsBlooked[i] && Distance[i] < curDistance)
                {
                    curDistance = Distance[i];
                    curNode = i;
                }
            }
            return curNode;


        }
        private void BuildWay(int startNode, int finishNode)
        {
            List<int> way = new List<int>();
            Way = "";
            int curNode = finishNode;
            way.Add(finishNode);
            while (curNode != startNode)
            {
                curNode = Parents[curNode];
                way.Add(curNode);
            }

            way.Reverse();
            foreach (var i in way)
            {
                Way += i + " ";
            }
        }

        public int GetShortestDistance(int startNode, int finishNode)
        {
            if (!DoNodeExist(startNode) || !DoNodeExist(finishNode)) return -1;

            int curNode = startNode;

            IsCalculatable = true;
            Distance = new int[Length];
            Parents = new int[Length];
            IsBlooked = new bool[Length];
            for (int i = 0; i < Length; i++)
            {
                Distance[i] = int.MaxValue;
                IsBlooked[i] = false;
                Parents[i] = -1;
            }

            Distance[startNode] = 0;


            while (!NeedStop())
            {
                // Вычисляем новое расстояние
                for (int i = 0; i < Length; i++)
                {
                    if (GraphMatrix[curNode, i] > 0 && Distance[curNode] + GraphMatrix[curNode, i] < Distance[i])
                    {
                        Distance[i] = Distance[curNode] + GraphMatrix[curNode, i];
                        Parents[i] = curNode;
                    }
                }

                IsBlooked[curNode] = true;
                curNode = SelectNextNode();
            }

            if (IsCalculatable)
            {
                BuildWay(startNode, finishNode);
                return Distance[finishNode];
            }

            return -1;
        }


    }
}