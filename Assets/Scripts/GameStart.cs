using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    public Player[] players;
    public GameObject[] breakItems;
    public Animator animator;
    public GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
        if (FindObjectOfType<GameManager>() == null)
        {
            GameObject temp = new GameObject("GameManager");
            temp.AddComponent<GameManager>();
            temp.AddComponent<AudioSource>().clip = (AudioClip)Resources.Load("Sound/BGM");
            temp.GetComponent<AudioSource>().loop = true;
            temp.GetComponent<AudioSource>().Play();
            animator.SetBool("Start", true);
            panel.SetActive(false);
            Invoke("BreakStone", 0.4f);
        }
        else
        {
            players[0].transform.position = new Vector2(-7.49f, -1.6f);
            players[1].transform.position = new Vector2(-6.52f, -1.6f);
            breakItems[0].SetActive(false);
            breakItems[1].SetActive(false);
        }
    }

    private void BreakStone()
    {
        breakItems[0].GetComponent<BreakItem>().Break();
        breakItems[1].GetComponent<BreakItem>().Break();
    }
}
