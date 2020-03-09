using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int currentLevel;
    
    void Start()
    {
        currentLevel = 1;
        DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {
        
    }

    public void LevelPass()
    {
        currentLevel++;
        SceneManager.LoadScene("Transition");
    }

    public void GameOver()
    {
        SceneManager.LoadScene("Transition");
    }


}
