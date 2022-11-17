
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// C# program for Dijkstra's single
// source shortest path algorithm.
// The program is for adjacency matrix
// representation of the graph

public abstract class ShortestPath : MonoBehaviour
{


    // A utility function to find the
    // vertex with minimum distance
    // value, from the set of vertices
    // not yet included in shortest
    // path tree
    private static int minDistance(int[,] graph, int[] dist, bool[] sptSet)
    {
        // Initialize min value
        int min = int.MaxValue, min_index = -1;

        for (int v = 0; v < graph.GetLength(0); v++)
        {
            if (sptSet[v] == false && dist[v] <= min)
            {
                min = dist[v];
                min_index = v;
            }
        }
        return min_index;
    }
    // Function that implements Dijkstra's
    // single source shortest path algorithm
    // for a graph represented using adjacency
    // matrix representation
    public static ArrayList Dijkstra(int[,] graph, int origem, int destino)
    {
        int[] dist
            = new int[graph.GetLength(0)]; // The output array. dist[i]
                            // will hold the shortest
                            // distance from src to i

        // sptSet[i] will true if vertex
        // i is included in shortest path
        // tree or shortest distance from
        // src to i is finalized
        bool[] sptSet = new bool[graph.GetLength(0)];

        //NEW
        int[] parents = new int[graph.GetLength(0)];

        // Initialize all distances as
        // INFINITE and stpSet[] as false
        for (int i = 0; i < graph.GetLength(0); i++)
        {
            dist[i] = int.MaxValue;
            sptSet[i] = false;
        }

        // Distance of source vertex
        // from itself is always 0
        dist[origem] = 0;

        // Find shortest path for all vertices
        for (int count = 0; count < graph.GetLength(0) - 1; count++)
        {
            // Pick the minimum distance vertex
            // from the set of vertices not yet
            // processed. u is always equal to
            // src in first iteration.
            int u = minDistance(graph, dist, sptSet);
            // Mark the picked vertex as processed
            sptSet[u] = true;
            // Update dist value of the adjacent
            // vertices of the picked vertex.W
            for (int v = 0; v < graph.GetLength(0); v++)

                // Update dist[v] only if is not in
                // sptSet, there is an edge from u
                // to v, and total weight of path
                // from src to v through u is smaller
                // than current value of dist[v]
                if (!sptSet[v] && graph[u, v] != 0
                    && dist[u] != int.MaxValue
                    && dist[u] + graph[u, v] < dist[v])
                {
                    dist[v] = dist[u] + graph[u, v];
                    parents[v] = u;
                }
        }

        ArrayList path = fullPathDijkstra(parents, origem, destino);

        return path;
    }
    private static ArrayList fullPathDijkstra(int[] parents, int origem, int destino)
    {
        ArrayList fullpath = new ArrayList();
        int aux = destino;
        while (aux != origem)
        {
            fullpath.Insert(0, aux);
            aux = parents[aux];
        }
        fullpath.Insert(0, aux);
        return fullpath;
    }
}

// This code is contributed by ChitraNayal
