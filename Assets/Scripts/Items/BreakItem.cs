using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakItem : MonoBehaviour
{

    private void Awake()
    {
        GetComponent<ParticleSystem>().Pause();
    }
    public void Break()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<ParticleSystem>().Play();
        Destroy(this.gameObject, 1);

    }
}
