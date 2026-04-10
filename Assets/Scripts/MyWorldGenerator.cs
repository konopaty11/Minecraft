using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyWorldGenerator : MonoBehaviour
{
    [SerializeField] GameObject entityPrefab;
    [SerializeField] Transform entityParent;
    [SerializeField] int countBioms;
    [SerializeField] int countVariantsBioms;
    [SerializeField] TerrainController terrain;

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
        terrain.SetBioms(map);
        SpawnEntities(map);
    }

    void SpawnEntities(int[,] map)
    {
        var data = terrain.TerrainData;
        var alpha = terrain.GetAlphamaps();

        int width = data.alphamapWidth;
        int height = data.alphamapHeight;

        Vector3 size = data.size;
        Vector3 pos = terrain.TerrainPosition;

        int grassLayer = (int)MyBioms.Grass;

        for (int x = 0; x < width; x += 10)
            for (int y = 0; y < height; y += 10)
            {
                if (alpha[x, y, grassLayer] > 0.5f)
                {
                    if (Random.value > 0.9f)
                    {
                        float worldX = pos.x + (float)x / width * size.x;
                        float worldZ = pos.z + (float)y / height * size.z;

                        float worldY = terrain.GetHeight(new Vector3(worldX, 0, worldZ));

                        SpawnEntity(new Vector3(worldX, worldY, worldZ));
                    }
                }
            }
    }

    void SpawnEntity(Vector3 position)
    {
        GameObject entityObject = Instantiate(entityPrefab, entityParent);
        entityObject.transform.position = position;
    }

}
