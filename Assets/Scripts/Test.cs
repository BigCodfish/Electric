using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public Transform[] trans;
    void Start()
    {
        FindObjectOfType<ElectricLine>().SetPoints(trans);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
