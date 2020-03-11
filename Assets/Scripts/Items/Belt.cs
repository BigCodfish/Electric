using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Belt : MonoBehaviour
{
    public float force;
    private RigidbodyConstraints2D _cons;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerMove>().SetOffsetX(force);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer != LayerMask.NameToLayer("Player"))
        {
            //Debug.Log("OtherEnter");
            //_cons = collision.GetComponent<Rigidbody2D>().constraints;
            //collision.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
            //collision.GetComponent<Rigidbody2D>().AddForce(Vector2.right * force);
            collision.GetComponent<Transform>().position =
                (Vector2) collision.GetComponent<Transform>().position + Vector2.right * force*0.01f;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerMove>().SetOffsetX(0);
        }
    }
}
