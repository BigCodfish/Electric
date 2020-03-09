using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerMove _pm;
    private float _move;
    private bool _jump;
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private int playerId;
    void Start()
    {
        _pm = GetComponent<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerId == 1)
        {
            _move = Input.GetAxis("Horizontal");
            _move *= speed;
            _jump = Input.GetButton("Jump");
        }
        else
        {
            _move = Input.GetAxis("Horizontal2");
            _move *= speed;
            _jump = Input.GetButton("Jump2");
        }
        
    }

    public int ID
    {
        get { return playerId; }
    }

    private void FixedUpdate()
    {
        _pm.Move(_move, _jump);
    }
}
