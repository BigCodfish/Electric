using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElctricManager : MonoBehaviour
{
    private LineRenderer _line;
    private Transform[] _players;
    [SerializeField] private float effectiveRange;
    
    void Start()
    {
        _line = GetComponent<LineRenderer>();
        _players = new Transform[2];
        Player[] p = FindObjectsOfType<Player>();
        _players[0] = p[0].transform;
        _players[1] = p[1].transform;
    }

    
    void Update()
    {
        if ((_players[0].position - _players[1].position).magnitude < effectiveRange)
        {
            _line.SetPosition(0, _players[0].position);
            _line.SetPosition(1, _players[1].position);
        }
    }
}
