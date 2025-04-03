using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeta2
{
    /// <summary>
    /// classe permettant de calculer le plus court chemin dans un graphe en utilisant plusieurs algorithmes
    /// </summary>
    internal class PlusCourtChemin
    {
        private int[,] matadj;
        private int n;
        private int[,] next;

        /// <summary>
        /// initialise la classe avec une matrice d'adjacence
        /// </summary>
        public PlusCourtChemin(int[,] matadj)
        {
            this.matadj = matadj;
            this.n = matadj.GetLength(0);
            this.next = new int[n, n];
        }

        /// <summary>
        /// applique l'algorithme de bellman-ford pour trouver le plus court chemin entre deux sommets
        /// </summary>
        public (List<int>, int) BellmanFord(int src, int dest)
        {
            int[] time = new int[n];
            int[] pred = new int[n];
            for (int i = 0; i < n; i++)
            {
                time[i] = int.MaxValue;
                pred[i] = -1;
            }

            time[src] = 0;

            for (int i = 0; i < n - 1; i++)
            {
                for (int u = 0; u < n; u++)
                {
                    for (int v = 0; v < n; v++)
                    {
                        if (matadj[u, v] != 0 && time[u] != int.MaxValue && time[u] + matadj[u, v] < time[v])
                        {
                            time[v] = time[u] + matadj[u, v];
                            pred[v] = u;
                        }
                    }
                }
            }
            return (ReconstructPath(pred, src, dest), time[dest]);
        }
        /// <summary>
        /// applique l'algorithme de dijkstra pour trouver le plus court chemin entre deux sommets
        /// </summary>
        public (List<int>, int) Dijkstra(int src, int dest)
        {
            int[] time = new int[n];
            int[] pred = new int[n];
            for (int i = 0; i < n; i++)
            {
                time[i] = int.MaxValue;
                pred[i] = -1;
            }

            time[src] = 0;
            var pq = new PriorityQueue<(int, int), int>();
            pq.Enqueue((src, 0), 0);

            while (pq.Count > 0)
            {
                var (u, currentTime) = pq.Dequeue();

                for (int v = 0; v < n; v++)
                {
                    if (matadj[u, v] != 0 && currentTime + matadj[u, v] < time[v])
                    {
                        time[v] = currentTime + matadj[u, v];
                        pred[v] = u;
                        pq.Enqueue((v, time[v]), time[v]);
                    }
                }
            }
            return (ReconstructPath(pred, src, dest), time[dest]);
        }
        /// <summary>
        /// applique l'algorithme de floyd-warshall pour trouver le plus court chemin entre deux sommets
        /// </summary>
        public (List<int>, int) FloydWarshall(int src, int dest)
        {
            int[,] distance = new int[n, n];

            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    if (i != j && matadj[i, j] == 0)
                        distance[i, j] = int.MaxValue;
                    else
                        distance[i, j] = matadj[i, j];

                    next[i, j] = j;
                }

            for (int k = 0; k < n; k++)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (distance[i, k] != int.MaxValue && distance[k, j] != int.MaxValue)
                        {
                            if (distance[i, j] > distance[i, k] + distance[k, j])
                            {
                                distance[i, j] = distance[i, k] + distance[k, j];
                                next[i, j] = next[i, k];
                            }
                        }
                    }
                }
            }
            return (ReconstructPathFloydWarshall(src, dest), distance[src, dest]);
        }

        public List<int> ReconstructPath(int[] pred, int src, int dest)
        {
            List<int> path = new List<int>();
            for (int at = dest; at != -1; at = pred[at])
                path.Add(at+1);
            path.Reverse();
            return path[0] == src+1 ? path : new List<int>();
        }

        public List<int> ReconstructPathFloydWarshall(int src, int dest)
        {
            List<int> path = new List<int>();
            for (int at = src; at != dest; at = next[at, dest])
            {
                if (at == -1) return new List<int>();
                path.Add(at+1);
            }
            path.Add(dest+1);
            return path[0] == src + 1 ? path : new List<int>();
        }
    }
}
        
