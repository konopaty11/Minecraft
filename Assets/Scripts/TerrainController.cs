using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TerrainController : MonoBehaviour
{
    [SerializeField] Terrain terrain;

    public TerrainData TerrainData { get; private set; }
    public Vector3 TerrainPosition { get; private set; }
    
    void Start()
    {
        Initialize();
    }

    void Initialize()
    {
        TerrainData = terrain.terrainData;
        TerrainPosition = terrain.transform.position;
    }

    public void SetBioms(int[,] map)
    {
        TerrainData = terrain.terrainData;

        int alphaWidth = TerrainData.alphamapWidth;
        int alphaHeight = TerrainData.alphamapHeight;
        int heightmapResolution = TerrainData.heightmapResolution;
        int layers = TerrainData.alphamapLayers;

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

        TerrainData.SetAlphamaps(0, 0, alphaMap);
        TerrainData.SetHeights(0, 0, heightMap);
    }

    public float GetHeight(Vector3 position)
    {
        return terrain.SampleHeight(position);
    }


    public float[,,] GetAlphamaps()
    {
        return TerrainData.GetAlphamaps(0, 0, TerrainData.alphamapWidth, TerrainData.alphamapHeight);
    }
}
