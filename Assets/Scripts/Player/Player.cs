using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerMove _pm;
    private float _move;
    private bool _jump;
    private float _lifeTime = 5;
    private float _timer = 0;
    [SerializeField] private bool _linked;
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private int playerId;
    public float DustVel;
    public Animator dustAnimator;
    private Rigidbody2D rg;
    public bool _dustPlay;
    void Start()
    {
        _pm = GetComponent<PlayerMove>();
        rg = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerId == 1)
        {
            _move = Input.GetAxis("Horizontal");
            _move *= speed;
            _jump = Input.GetButton("Jump");
        }
        else
        {
            _move = Input.GetAxis("Horizontal2");
            _move *= speed;
            _jump = Input.GetButton("Jump2");
        }

        if (_timer > _lifeTime) FindObjectOfType<GameManager>().GameOver();
    }


    public int ID
    {
        get { return playerId; }
    }

    public bool Linked
    {
        set { _linked = value; }
    }

    public void DustPlay()
    {
        if (_dustPlay)
        {
            dustAnimator.SetTrigger("Play");
            _dustPlay = false;
        }
    }


    private void FixedUpdate()
    {
        if(rg.velocity.y<-DustVel) _dustPlay = true;
        //Debug.Log(rg.velocity.y < -DustVel);
        if (!_linked) _timer += Time.deltaTime; 
        else _timer = 0;
        _pm.Move(_move, _jump);
    }
}
