using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerMove _pm;
    private float _move;
    private bool _jump;
    public float speed = 5.0f;
    void Start()
    {
        _pm = GetComponent<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        _move = Input.GetAxis("Horizontal");
        _move *= speed;
        
        _jump = Input.GetButton("Jump");
    }

    private void FixedUpdate()
    {
        _pm.Move(_move, _jump);
    }
}
