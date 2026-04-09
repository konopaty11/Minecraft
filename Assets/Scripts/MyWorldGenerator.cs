using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyWorldGenerator : MonoBehaviour
{
    [SerializeField] int countBioms;
    [SerializeField] int countVariantsBioms;
    [SerializeField] TerrainPainter terrainPainter;

    void Start()
    {
        GenerateWorld();
    }

    public void GenerateOrLoadWorld()
    {

    }

    public void LoadWorld()
    {

    }

    public void GenerateWorld()
    {
        int[,] map = MyVoronoi.GenerateMap(new(400, 600), countBioms, countVariantsBioms);
        terrainPainter.Paint(map);
    }
}
