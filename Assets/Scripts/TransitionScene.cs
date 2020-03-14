using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionScene : MonoBehaviour
{
    
    void Start()
    {
        Invoke("LoadNextScene", 2.5f);
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
            case 3:
                SceneManager.LoadScene("Level3");
                break;
            case 4:
                SceneManager.LoadScene("Level4");
                break;
            case 5:
                SceneManager.LoadScene("Level5");
                break;
            case 6:
                SceneManager.LoadScene("Level6");
                break;
            case 7:
                SceneManager.LoadScene("Level7");
                break;
            default:
                SceneManager.LoadScene("Level1");
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
