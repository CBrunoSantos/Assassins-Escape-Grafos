
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// C# program for Dijkstra's single
// source shortest path algorithm.
// The program is for adjacency matrix
// representation of the graph

public class GFG : MonoBehaviour
{
    public int origem;
    public int destino;
    public List<GameObject> houses;
    public Material red;
    private int[,] graph       // 1  2  3  4  5  6  7  8  9
        = new int[,] {      { 0, 4, 0, 0, 0, 0, 0, 8, 0 },   //1
                        { 4, 0, 8, 0, 0, 0, 0, 11, 0 },  //2
                        { 0, 8, 0, 7, 0, 4, 0, 0, 2 },   //3
                        { 0, 0, 7, 0, 9, 14, 0, 0, 0 },  //4
                        { 0, 0, 0, 9, 0, 10, 0, 0, 0 },  //5
                        { 0, 0, 4, 14, 10, 0, 2, 0, 0 }, //6
                        { 0, 0, 0, 0, 0, 2, 0, 1, 6 },   //7
                        { 8, 11, 0, 0, 0, 0, 1, 0, 7 },  //8
                        { 0, 0, 2,  0, 0, 0, 6, 7, 0 } };//9

    private static int V = 9;
    public void Start()
    {
        GFG t = new GFG();

        // Function call

        ArrayList pathList = t.dijkstra(this.graph, this.origem, this.destino);
        Debug.Log("Saindo da origem: " + origem + " para chegar no destino: " + destino + " passe pelo percurso abaixo:");
        foreach (int i in pathList)
        {
            Debug.Log("Passe por: " + i);
            houses[i].GetComponent<MeshRenderer>().material = red;
        }
    }
    // A utility function to find the
    // vertex with minimum distance
    // value, from the set of vertices
    // not yet included in shortest
    // path tree
    private int minDistance(int[] dist, bool[] sptSet)
    {
        // Initialize min value
        int min = int.MaxValue, min_index = -1;

        for (int v = 0; v < V; v++)
        {
            if (sptSet[v] == false && dist[v] <= min)
            {
                min = dist[v];
                min_index = v;
            }
        }
        return min_index;
    }

    // A utility function to print
    // the constructed distance array
    private void printSolution(int[] dist)
    {
        Debug.Log("Vertex \t\t Distance "
                        + "from Source\n");
        for (int i = 0; i < V; i++)
            Debug.Log(i + " \t\t " + dist[i] + "\n");
    }

    // Function that implements Dijkstra's
    // single source shortest path algorithm
    // for a graph represented using adjacency
    // matrix representation
    private ArrayList dijkstra(int[,] graph, int origem, int destino)
    {
        int[] dist
            = new int[V]; // The output array. dist[i]
                            // will hold the shortest
                            // distance from src to i

        // sptSet[i] will true if vertex
        // i is included in shortest path
        // tree or shortest distance from
        // src to i is finalized
        bool[] sptSet = new bool[V];

        //NEW
        int[] parents = new int[V];

        // Initialize all distances as
        // INFINITE and stpSet[] as false
        for (int i = 0; i < V; i++)
        {
            dist[i] = int.MaxValue;
            sptSet[i] = false;
        }

        // Distance of source vertex
        // from itself is always 0
        dist[origem] = 0;

        // Find shortest path for all vertices
        for (int count = 0; count < V - 1; count++)
        {
            // Pick the minimum distance vertex
            // from the set of vertices not yet
            // processed. u is always equal to
            // src in first iteration.
            int u = minDistance(dist, sptSet);
            // Mark the picked vertex as processed
            sptSet[u] = true;
            // Update dist value of the adjacent
            // vertices of the picked vertex.W
            for (int v = 0; v < V; v++)

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
        // print the constructed distance array
        printSolution(dist);

        ArrayList path = fullPathDijkstra(parents, origem, destino);

        return path;
    }
    private ArrayList fullPathDijkstra(int[] parents, int origem, int destino)
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
