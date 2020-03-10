using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public Prop targetProp;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Retry")
        {
            targetProp.Function();
        }
    }
}
