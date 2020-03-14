using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Elevator : MonoBehaviour
{
    public Transform[] wayPoints;
    private Vector3 _vol;
    public float speed;
    private Rigidbody2D _rigid;
    private void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if ((transform.position - wayPoints[0].position).magnitude <= 0.01f)
        {
            _rigid.velocity = Vector2.down * speed;
        }
        if ((transform.position - wayPoints[1].position).magnitude <= 0.01f)
        {
            _rigid.velocity = Vector2.up * speed;
        }
        transform.Translate(_vol);
    }
}
