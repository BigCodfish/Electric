using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElctricManager : MonoBehaviour
{
    private LineRenderer _line;
    private Transform[] _players;
    private Player[] p;
    private Retry[] _retrys;
    private float[] _distance1;
    private float[] _distance2;
    [SerializeField] private float _effectiveRange;
    
    void Start()
    {
        _line = GetComponent<LineRenderer>();
        _players = new Transform[2];
        p = FindObjectsOfType<Player>();
        _retrys = FindObjectsOfType<Retry>();
        _players[0] = p[0].transform;
        _players[1] = p[1].transform;
        _distance1 = new float[_retrys.Length];
        _distance2 = new float[_retrys.Length];
    }

    
    void Update()
    {
        if ((_players[0].position - _players[1].position).magnitude < _effectiveRange)
        {
            SetPoints(2);
            return;
        }
        else
        {
            for (int i = 0; i < _retrys.Length; i++)
            {
                _distance1[i] = (_retrys[i].transform.position - _players[0].position).magnitude;
                _distance2[i] = (_retrys[i].transform.position - _players[1].position).magnitude;
            }

            for (int i = 0; i < _retrys.Length; i++)
            {
                
            }
        }
        p[0].Linked = false;
        p[1].Linked = false;
        _line.enabled = false;
    }

    private void SetPoints(int count,params int[] retryId)
    {
        _line.enabled = true;
        _line.positionCount = count;
        _line.SetPosition(0, _players[0].position);
        _line.SetPosition(count-1, _players[1].position);
        for (int i = 1; i <= count-2; i++)
        {
            _line.SetPosition(i, _retrys[retryId[i-1]].transform.position);
        }
        p[0].Linked = true;
        p[1].Linked = true;
    }
}
