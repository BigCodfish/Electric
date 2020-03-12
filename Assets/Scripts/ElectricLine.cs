using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricLine : MonoBehaviour
{
    private LineRenderer _line;
    public int randomTime;
    private int _pointCount;
    public float scale;
    private Vector2[] _pointTrans;
    public void SetPoints(params Vector2[] points)
    {
        _pointCount = points.Length;
         _pointTrans = new Vector2[_pointCount];
        for (int i = 0; i < _pointCount; i++)
        {
            _pointTrans[i] = points[i];
        }
    }

    private void Start()
    {
        _line = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        int totalLen = 0;
        for (int i = 0; i < _pointCount - 1; i++)
        {
            //Debug.Log($"TotalCount:{totalLen},PointCount:{_pointCount},i:{i}");
            Vector2 temp = _pointTrans[i];
            float distance = (_pointTrans[i + 1] - _pointTrans[i]).magnitude / randomTime;
            _line.positionCount = totalLen + 2 +  randomTime; //line的结点数

            _line.SetPosition(totalLen, _pointTrans[i]);
            _line.SetPosition(_line.positionCount - 1, _pointTrans[i + 1]);

            float distanceX = GetCos(_pointTrans[i + 1], _pointTrans[i]) * distance;
            float distanceY = GetSin(_pointTrans[i + 1], _pointTrans[i]) * distance;
            for (int j = 0; j < randomTime; j++)
            {
                float ran = Random.Range(0, scale);
                float ran2= Random.Range(0, scale);
                _line.SetPosition(totalLen + 1 + j, new Vector2(temp.x + distanceX * j + ran, temp.y + distanceY * j + ran2));
            }
            totalLen += (2 + randomTime);
        }
    }

    private float GetSin(Vector2 p1, Vector2 p2)
    {
        float length = (p1 - p2).magnitude;
        if (length == 0) return 0;
        else return (p1.y - p2.y) / length;
    }

    private float GetCos(Vector2 p1, Vector2 p2)
    {
        float length = (p1 - p2).magnitude;
        if (length == 0) return 0;
        else return (p1.x - p2.x) / length;
    }
}
