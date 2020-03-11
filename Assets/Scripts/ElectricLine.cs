using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricLine : MonoBehaviour
{
    private LineRenderer _line;
    public int randomTime;
    private int _pointCount;
    public float scale;
    private Transform[] _pointTrans;
    public void SetPoints(params Transform[] points)
    {
        _pointCount = points.Length;
        Debug.Log(_pointCount);
        if (_pointTrans == null) _pointTrans = new Transform[_pointCount];
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
            Vector2 temp = _pointTrans[i].position;
            float distance = (_pointTrans[i + 1].position - _pointTrans[i].position).magnitude / randomTime;
            _line.positionCount = totalLen + 2 + ((int) distance + 1) * randomTime; //line的结点数

            _line.SetPosition(totalLen, _pointTrans[i].position);
            _line.SetPosition(_line.positionCount - 1, _pointTrans[i + 1].position);

            float distanceX = GetCos(_pointTrans[i + 1].position, _pointTrans[i].position) * distance;
            float distanceY = GetSin(_pointTrans[i + 1].position, _pointTrans[i].position) * distance;
            for (int j = 0; j < randomTime; j++)
            {
                float ran = Random.Range(0, scale);
                float ran2= Random.Range(0, scale);
                _line.SetPosition(totalLen + 1 + j, new Vector2(temp.x + distanceX * j + ran, temp.y + distanceY * j + ran2));
            }
            totalLen += _line.positionCount;
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
