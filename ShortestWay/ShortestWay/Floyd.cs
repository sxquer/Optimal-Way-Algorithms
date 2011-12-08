using System;
using System.IO;

namespace ShortestWay
{
    class Floyd
    {
        private const int INF = 999;

        public int[,] GraphMatrix { get; set; }
        public int[,] DistanceMatrix { get; set; }
        
        private int Length { get; set; }
        
        public Floyd(string filename)
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

        public void BuildDistanceMap()
        {
            DistanceMatrix = (int[,])GraphMatrix.Clone();
            for (int i = 0; i < Length; i++)
            {
                for (int j = 0; j < Length; j++)
                {
                    for (int k = 0; k < Length; k++)
                    {
                        //if (DistanceMatrix[j, i] < INF && DistanceMatrix[i, k] < INF)
                        DistanceMatrix[j, k] = Math.Min(DistanceMatrix[j, k], DistanceMatrix[j, i] + DistanceMatrix[i, k]);
                    }
                }
            }
        }

        public void Echo()
        {
            BuildDistanceMap();
            Console.Out.WriteLine("Матрица расстояний: \n");
            for (int i = 0; i < Length; i++)
            {
                for (int j = 0; j < Length; j++)
                {
                    Console.Out.Write("{0:000} ", GraphMatrix[i, j]);
                }
                Console.Out.WriteLine("");
            }

            Console.Out.WriteLine("\nМатрица кратчайших расстояний: \n");
            for (int i = 0; i < Length; i++)
            {
                for (int j = 0; j < Length; j++)
                {
                    Console.Out.Write("{0:00} ", DistanceMatrix[i, j]);
                }
                Console.Out.WriteLine("");
            }

            Console.Out.WriteLine("------------------------------");
        }
    }
}