using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElctricManager : MonoBehaviour
{
    private LineRenderer _line;
    private Transform[] _players;
    private Player[] p;
    private Retry[] _retrys;
    [SerializeField] private float _effectiveRange;
    
    void Start()
    {
        _line = GetComponent<LineRenderer>();
        _players = new Transform[2];
        p = FindObjectsOfType<Player>();
        _retrys = FindObjectsOfType<Retry>();
        _players[0] = p[0].transform;
        _players[1] = p[1].transform;
    }

    
    void Update()
    {
        if ((_players[0].position - _players[1].position).magnitude < _effectiveRange)
        {
            _line.enabled = true;
            _line.SetPosition(0, _players[0].position);
            _line.SetPosition(1, _players[1].position);
            _line.SetPosition(2, _players[1].position);
            p[0].Linked = true;
            p[1].Linked = true;
            return;
        }
        else
        {
            for (int i = 0; i < _retrys.Length; i++)
            {
                float distance1 = (_retrys[i].transform.position - _players[0].position).magnitude;
                float distance2 = (_retrys[i].transform.position - _players[1].position).magnitude;
                if (distance1 < _effectiveRange && distance2 < _effectiveRange)
                {
                    _line.enabled = true;
                    _line.SetPosition(0, _players[0].position);
                    _line.SetPosition(2, _players[1].position);
                    _line.SetPosition(1, _retrys[i].transform.position);
                    p[0].Linked = true;
                    p[1].Linked = true;
                    return;
                }
            }
        }
        p[0].Linked = false;
        p[1].Linked = false;
        _line.enabled = false;
    }
}
