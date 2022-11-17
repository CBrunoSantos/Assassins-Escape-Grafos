using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Murder : MonoBehaviour
{
    private int[,] graph
            = new int[,] { { 0, 4, 0, 0, 0, 0, 0, 8, 0 },
                            { 4, 0, 8, 0, 0, 0, 0, 11, 0 },
                            { 0, 8, 0, 7, 0, 4, 0, 0, 2 },
                            { 0, 0, 7, 0, 9, 14, 0, 0, 0 },
                            { 0, 0, 0, 9, 0, 10, 0, 0, 0 },
                            { 0, 0, 4, 14, 10, 0, 2, 0, 0 },
                            { 0, 0, 0, 0, 0, 2, 0, 1, 6 },
                            { 8, 11, 0, 0, 0, 0, 1, 0, 7 },
                            { 0, 0, 2, 0, 0, 0, 6, 7, 0 } };
    private Vector3[] unityGraphPosition 
        = { new Vector3(-192.270004f,-637.570862f,-76.25f),
            new Vector3(-190.300003f,-637.570862f,-72.6999969f),
            new Vector3(-187.570007f,-637.570862f,-72.6999969f),
            new Vector3(-185.460007f,-637.570862f,-72.6999969f),
            new Vector3(-183.449997f,-637.570862f,-76.0800018f),
            new Vector3(-185.5f,-637.570862f,-79.9199982f),
            new Vector3(-187.729996f,-637.570862f,-79.9199982f),
            new Vector3(-190.309998f,-637.570862f,-79.9199982f),
            new Vector3(-187.679993f,-637.570862f,-76.4599991f)};

    public int playerLocation;
    public int murderLocation;
    public bool stoped;

    private bool playerCaptured;
    private Vector3 pathToGo;
    public Rigidbody rb;

    [Range(0f,1f)]
    public float t;
    private void Awake()
    {
        this.transform.position = unityGraphPosition[murderLocation];
    }
    private void Start()
    {
        StartCoroutine(FindPlayerCorroutine());
    }
    private void Update()
    {
        rb.position = Vector3.Lerp(this.transform.position, pathToGo, t);
    }
    IEnumerator FindPlayerCorroutine() {
        while (!playerCaptured || murderLocation != playerLocation)
        {
            Debug.Log("Calculando nova trajetoria!");
            ArrayList fullpath = ShortestPath.Dijkstra(graph, murderLocation , playerLocation);
            StartCoroutine(movementMurderOnebyOne(fullpath));
            yield return new WaitForSeconds(30.0f);
        }
    }
    IEnumerator movementMurderOnebyOne(ArrayList fullpath)
    {
        foreach (int path in fullpath) {
            Debug.Log("Estou no vertice: " + path);
            pathToGo = unityGraphPosition[path];
            murderLocation = path;
            yield return new WaitForSeconds(1f);
        }
    }
}
