using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MyVoronoi
{
    static List<Vector2Int> _points = new();
    static int[,] _map;

    public static int[,] GenerateMap(Vector2Int mapSize, int pointsCount)
    {
        GeneratePoints(mapSize, pointsCount);

        _map = new int[mapSize.x, mapSize.y];
        for (int x = 0; x < mapSize.x; x++)
            for (int y = 0; y < mapSize.y; y++)
            {
                _map[x, y] = GetClosestPoint(new(x, y));
            }

        return _map;
    }

    static void GeneratePoints(Vector2Int mapSize, int pointsCount)
    {
        for (int _ = 0; _ < pointsCount; _++)
        {
            int x = Random.Range(0, mapSize.x);
            int y = Random.Range(0, mapSize.y);
            _points.Add(new Vector2Int(x, y));
        }
    }

    static int GetClosestPoint(Vector2Int mapPoint)
    {
        float minDistance = float.MaxValue;
        int closestIndex = -1;

        for (int i = 0; i < _points.Count; i++)
        {
            float distance = Vector2Int.Distance(mapPoint, _points[i]);
            if (distance < minDistance)
            {
                minDistance = distance;
                closestIndex = i;
            }
        }

        return closestIndex;
    }
}
