using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    private bool gameWon = false;
    private bool gameLose = false;
    public float restartDelay = 1f;
    private int enemies;

    public int enemiesLeft
    {
        get { return enemies; }
        set
        {
            enemies = value;
            if (enemies <= 0)
            {
                UIBehavior.instance.SetScreen(UIBehavior.instance.winScreen);
                EndGameWin();
            }
        }
    }

    private void Awake()
    {
        instance = this; 
    }

    public void EndGameWin()
    {
        if (gameWon == false)
        {
            gameWon = true;
            Debug.Log("Game Won");
            Invoke("Restart", restartDelay);
        }
    }

    public void EndGameLose()
    {
        if (gameLose == false)
        {
            gameLose = true;
            Debug.Log("Game Lost");
            UIBehavior.instance.SetScreen(UIBehavior.instance.loseScreen);
            Invoke("Restart", restartDelay);
        }
    }

    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
