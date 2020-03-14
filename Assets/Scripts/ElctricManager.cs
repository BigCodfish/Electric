using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElctricManager : MonoBehaviour
{
    [SerializeField] private float _effectiveRange;
    private ElectricLine _line;
    private LineRenderer _lineRenderer;
    private Transform[] _players;
    private Player[] p;
    [SerializeField] private Retry[] _retrys;
    private List<Vector2> _linkedPoint;
    [SerializeField] private List<int> _igoreList;

    void Start()
    {
        _igoreList = new List<int>();
        _lineRenderer = GetComponent<LineRenderer>();
        _linkedPoint = new List<Vector2>();
        _line = GetComponent<ElectricLine>();
        _players = new Transform[2];
        p = FindObjectsOfType<Player>();
        _retrys = FindObjectsOfType<Retry>();
        _players[0] = p[0].transform;
        _players[1] = p[1].transform;
    }

    
    void Update()
    {
        _igoreList.Clear();
        _linkedPoint.Add(_players[1].position);
        if (Link(_players[0].position,-1))
        {
            _lineRenderer.enabled = true;
            //Debug.Log("LinkedPoint:"+_linkedPoint.Count);
            p[0].Linked = true;
            p[1].Linked = true;
            DrawLine();
        }
        else
        {
            _lineRenderer.enabled = false;
            p[0].Linked = false;
            p[1].Linked = false;
            ClearLine();
        }
        _linkedPoint.Clear();
    }

    private void DrawLine()
    {
        _line.SetPoints(_linkedPoint.ToArray());
    }

    private void ClearLine()
    {
        _line.SetPoints();
    }

    private bool Link(Vector3 target,int retryId)
    {
        //Debug.Log($"RetryId::{retryId},ignore:{_igoreList.Count}");
        if ((target - _players[1].position).magnitude < _effectiveRange)
        {
            _linkedPoint.Add(target);
            return true;
        }
        else
        {
            for (int i = 0; i < _retrys.Length; i++)
            {
                if (_igoreList.Contains(i)) continue;
                //Debug.Log($"RetryId:{retryId},{i}:{(_retrys[i].transform.position - target).magnitude}");
                if ((_retrys[i].transform.position - target).magnitude < _effectiveRange)
                {
                    //Debug.Log($"RetryId::{retryId},i:{i}");
                    _igoreList.Add(i);
                    if (Link(_retrys[i].transform.position,i))
                    {
                        _linkedPoint.Add(target);
                        return true;
                    }
                }
            }
        }
        if (_igoreList.Contains(retryId)) _igoreList.Remove(retryId);
        return false;
    }
    
}
