using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (FindObjectOfType<GameManager>() == null)
        {
            GameObject temp = new GameObject("GameManager");
            temp.AddComponent<GameManager>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
