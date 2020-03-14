using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAnim : MonoBehaviour
{

    private Transform _cameraTrans;
    void Start()
    {
        _cameraTrans = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = _cameraTrans.position + Vector3.down * 8 + Vector3.forward * 100;
    }
}
