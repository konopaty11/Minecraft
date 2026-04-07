using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoronoiNoise : MonoBehaviour
{
    Vector2[] _points;
    int _gridSize;
    float _cellSize;

    public VoronoiNoise(int pointCount, float width, float height)
    {
        _points = new Vector2[pointCount];
        for (int i = 0; i < pointCount; i++)
        {
            _points[i] = new Vector2(
                Random.Range(0, width),
                Random.Range(0, height)
            );
        }
    }

    public float GetValue(float x, float y)
    {
        float minDist = float.MaxValue;

        foreach (Vector2 p in _points)
        {
            float dx = x - p.x;
            float dy = y - p.y;
            float dist = dx * dx + dy * dy;
            if (dist < minDist) minDist = dist;
        }

        return Mathf.Sqrt(minDist);
    }
}

