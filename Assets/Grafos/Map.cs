
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public List<GameObject> indexes;
    private int[,] graph   // 0  1  2  3  4  5  6  7  8
    = new int[,] {          { 0, 4, 0, 0, 0, 0, 0, 8, 0 },   //0
                        { 4, 0, 8, 0, 0, 0, 0, 11, 0 },  //1
                        { 0, 8, 0, 7, 0, 4, 0, 0, 2 },   //2
                        { 0, 0, 7, 0, 9, 14, 0, 0, 0 },  //3
                        { 0, 0, 0, 9, 0, 10, 0, 0, 0 },  //4
                        { 0, 0, 4, 14, 10, 0, 2, 0, 0 }, //5
                        { 0, 0, 0, 0, 0, 2, 0, 1, 6 },   //6
                        { 8, 11, 0, 0, 0, 0, 1, 0, 7 },  //7
                        { 0, 0, 2,  0, 0, 0, 6, 7, 0 } };//8
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void createMap(int size)
    {
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                createBox(i, j, 0);
            }
        }
    }
    void createBox(int x, int y, int z)
    {
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.position = new Vector3(x, y, z);
    }
}

