using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionScene : MonoBehaviour
{
    
    void Start()
    {
        Invoke("LoadNextScene", 1);
    }

    private void LoadNextScene()
    {
        int id = FindObjectOfType<GameManager>().currentLevel;
        switch (id)
        {
            case 1:
                SceneManager.LoadScene("Level1");
                break;
            case 2:
                SceneManager.LoadScene("Level2");
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
