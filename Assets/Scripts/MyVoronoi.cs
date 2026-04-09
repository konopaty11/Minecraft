using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MyVoronoi
{
    static List<Point> _points = new();
    static int[,] _map;

    public static int[,] GenerateMap(Vector2Int mapSize, int countPoints, int countPointVariants)
    {
        GeneratePoints(mapSize, countPoints, countPointVariants);

        _map = new int[mapSize.x, mapSize.y];
        for (int x = 0; x < mapSize.x; x++)
            for (int y = 0; y < mapSize.y; y++)
            {
                _map[x, y] = GetClosestPoint(new(x, y));
            }

        return _map;
    }

    static void GeneratePoints(Vector2Int mapSize, int countPoints, int countPointVariants)
    {
        for (int _ = 0; _ < countPoints; _++)
        {
            int x = Random.Range(0, mapSize.x);
            int y = Random.Range(0, mapSize.y);
            Point point = new(new Vector2Int(x, y), Random.Range(0, countPointVariants));
            _points.Add(point);
        }
    }

    static int GetClosestPoint(Vector2Int mapPoint)
    {
        float minDistance = float.MaxValue;
        int closestIndex = -1;

        for (int i = 0; i < _points.Count; i++)
        {
            float distance = Vector2Int.Distance(mapPoint, _points[i].position);
            if (distance < minDistance)
            {
                minDistance = distance;
                closestIndex = _points[i].index;
            }
        }

        return closestIndex;
    }
}

class Point
{
    public Vector2Int position;
    public int index;

    public Point(Vector2Int position, int index)
    {
        this.position = position;
        this.index = index;
    }
}