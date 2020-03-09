using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusPoint : MonoBehaviour
{
    private Transform[] _pos;
    void Start()
    {
        _pos = new Transform[2];
        Player[] players = FindObjectsOfType<Player>();
        _pos[0] = players[0].transform;
        _pos[1] = players[1].transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = (_pos[0].position + _pos[1].position) / 2;
    }
}
