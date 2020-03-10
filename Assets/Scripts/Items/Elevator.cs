using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Elevator : MonoBehaviour
{
    public Transform[] wayPoints;
    private Vector3 _vol;


    private void Update()
    {
        
        if ((transform.position - wayPoints[0].position).magnitude <= 0.01f)
        {
            _vol = Vector3.down * 0.03f;
        }
        if ((transform.position - wayPoints[1].position).magnitude <= 0.01f)
        {
            _vol = Vector3.up * 0.03f;
        }
        transform.Translate(_vol);
    }
}
