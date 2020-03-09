using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPoint : MonoBehaviour
{
    private int _entered;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.layer = LayerMask.NameToLayer("NoCollision");
            _entered++;
        }
        if (_entered == 2) FindObjectOfType<GameManager>().LevelPass();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _entered--;
            collision.gameObject.layer = LayerMask.NameToLayer("Player");
        }
    }
}
