using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TerrainPainter : MonoBehaviour
{
    [SerializeField] Terrain terrain;

    TerrainData terrainData;
    
    void Start()
    {
        Initialize();
    }

    void Initialize()
    {
        terrainData = terrain.terrainData;
    }

    public void Paint(int[,] map)
    {
        int alphaWidth = terrainData.alphamapWidth;
        int alphaHeight = terrainData.alphamapHeight;
        int layers = terrainData.alphamapLayers;

        float[,,] alphaMap = new float[alphaWidth, alphaHeight, layers];

        Vector2Int mapSize = new(map.GetLength(0), map.GetLength(1));
        for (int x = 0; x < alphaWidth; x++) 
            for (int y = 0; y < alphaHeight; y++)
            {
                int mapX = x * mapSize.x / alphaWidth;
                int mapY = y * mapSize.y / alphaHeight;

                int biome = map[mapX, mapY];

                for (int i = 0; i < layers; i++)
                    alphaMap[x, y, i] = 0f;

                alphaMap[x, y, biome] = 1f;
            }

        terrainData.SetAlphamaps(0, 0, alphaMap);
    }
}
