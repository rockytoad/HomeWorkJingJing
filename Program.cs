using System;

namespace ConsoleApp8
{
    class Program
    {
        public static void Main()
        {
            Console.Write("input townnumber: ");
            int TowNNumBer = int.Parse(Console.ReadLine());


            string[] Descity = new string[TowNNumBer];

            for (int i = 0; i < Descity.Length; i++)
            {
                Console.Write("City :");
                Descity[i] = Console.ReadLine();
            }

            int[,] graph = new int[TowNNumBer, TowNNumBer];
            for (int i = 0; i < graph.GetLength(0); i++)
            {
                for (int j = 0; j < graph.GetLength(1); j++)
                {
                    if (j > i)
                    {
                        graph[i, j] = 0;
                    }
                    else if (j == i)
                    {
                        graph[i, j] = -1;
                    }
                    else
                    {
                        graph[i, j] = int.Parse(Console.ReadLine());
                    }
                }
            }
            for (int i = 0; i < graph.GetLength(0); i++)
            {
                for (int j = 0; j < graph.GetLength(0); j++)
                {
                    graph[i, j] = graph[j, i];

                }
            }
            Console.Write("your Paitang: ");
            string paitang = Console.ReadLine();
            int numberpaitang = 0;
            for (int i = 0; i < Descity.Length; i++)
            {
                if (Descity[i] == paitang)
                {
                    numberpaitang = i;
                }
            }
            Town town = new Town();
            town.dijkstra(graph, numberpaitang, TowNNumBer);
        }









    }
}  
class Town
{

    int minDistance(int[] dist,
                    bool[] sptSet, int V)
    {

        int min = int.MaxValue, min_index = -1;

        for (int v = 0; v < V; v++)
            if (sptSet[v] == false && dist[v] <= min)
            {
                min = dist[v];
                min_index = v;
            }

        return min_index;
    }


    void printSolution(int[] dist)
    {
        Console.WriteLine(dist[0]);
    }


     public void dijkstra(int[,] graph, int src, int V)
    {
        int[] dist = new int[V];


        bool[] sptSet = new bool[V];


        for (int i = 0; i < V; i++)
        {
            dist[i] = int.MaxValue;
            sptSet[i] = false;
        }


        dist[src] = 0;


        for (int count = 0; count < V - 1; count++)
        {

            int u = minDistance(dist, sptSet, V);


            sptSet[u] = true;

            for (int v = 0; v < V; v++)


                if (!sptSet[v] && graph[u, v] != -1 &&
                     dist[u] != int.MaxValue && dist[u] + graph[u, v] < dist[v])
                    dist[v] = dist[u] + graph[u, v];
        }


        printSolution(dist);

    }
}
