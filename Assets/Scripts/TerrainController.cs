using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TerrainController : MonoBehaviour
{
    [SerializeField] Terrain terrain;

    TerrainData terrainData;
    
    void Start()
    {
        Initialize();
    }

    void Initialize()
    {
    }

    public void SetBioms(int[,] map)
    {
        terrainData = terrain.terrainData;

        int alphaWidth = terrainData.alphamapWidth;
        int alphaHeight = terrainData.alphamapHeight;
        int heightmapResolution = terrainData.heightmapResolution;
        int layers = terrainData.alphamapLayers;

        float[,,] alphaMap = new float[alphaWidth, alphaHeight, layers];
        float[,] heightMap = new float[heightmapResolution, heightmapResolution];

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

                float deltaHeightFactor;
                switch ((MyBioms)biome)
                {
                    case MyBioms.Grass:
                    case MyBioms.Sand:
                        deltaHeightFactor = 0.02f;
                        break;

                    case MyBioms.Dirt:
                        deltaHeightFactor = 0.01f;
                        break;

                    case MyBioms.Wood:
                        deltaHeightFactor = 0.004f;
                        break;

                    case MyBioms.Rock:
                        deltaHeightFactor = 0.04f;
                        break;

                    default:
                        deltaHeightFactor = 0f;
                        break;
                }

                float height = Mathf.PerlinNoise(x * deltaHeightFactor, y * deltaHeightFactor) * 0.01f;


                heightMap[x, y] = height;
            }

        terrainData.SetAlphamaps(0, 0, alphaMap);
        terrainData.SetHeights(0, 0, heightMap);
    }

    public void SetHeight(int[,] map)
    {

    }
}
