using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Retry : MonoBehaviour
{
    [SerializeField] private bool _enter1;
    [SerializeField] private bool _enter2;
    [SerializeField] private bool _lifed;
    private Transform _playerTrans;
    [SerializeField] private bool _lockTime;

    [SerializeField] private Vector2 retryPos;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (collision.GetComponent<Player>().ID == 1) _enter1 = true;
            else if (collision.GetComponent<Player>().ID == 2) _enter2 = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (_enter1 && Input.GetKeyDown(KeyCode.S))
        {
            gameObject.layer = LayerMask.NameToLayer("Retry");
            if(collision.transform.position.x-transform.position.x < 0) transform.position = (Vector2)collision.transform.position + retryPos;
            else transform.position = (Vector2)collision.transform.position + new Vector2(-retryPos.x,retryPos.y);
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            transform.parent = collision.transform;
            _lifed = true;
            _enter2 = false;
        }
        if (_enter2 && Input.GetKeyDown(KeyCode.DownArrow))
        {
            gameObject.layer = LayerMask.NameToLayer("Retry");
            if (collision.transform.position.x - transform.position.x < 0) transform.position = (Vector2)collision.transform.position + retryPos;
            else transform.position = (Vector2)collision.transform.position + new Vector2(-retryPos.x, retryPos.y);
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            transform.parent = collision.transform;
            _lifed = true;
            _enter1 = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!_lifed && collision.gameObject.tag == "Player")
        {
            if (collision.GetComponent<Player>().ID == 1) _enter1 = false;
            else if (collision.GetComponent<Player>().ID == 2) _enter2 = false;
        }
    }
    
    void Update()
    {
        if (_lifed)
        {
            if (_lockTime && _enter1 && Input.GetKeyDown(KeyCode.S))
            {
                gameObject.layer = LayerMask.NameToLayer("Default");
                GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                transform.parent = null;
                _enter1 = false;
                _lifed = false;
                _lockTime = false;
            }
            if (_lockTime && _enter2 && Input.GetKeyDown(KeyCode.DownArrow))
            {
                gameObject.layer = LayerMask.NameToLayer("Default");
                GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                transform.parent = null;
                _enter2 = false;
                _lifed = false;
                _lockTime = false;
            }
            //transform.position = (Vector2)_playerTrans.position + retryPos;
            if (!_lockTime && _lifed) _lockTime = true;
        }
    }
}
