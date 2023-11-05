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
    private int boss;

    public int enemiesLeft 
    {
        get { return enemies; }
        set
        {
            enemies = value;
            if (enemies <= 0)
            {
                //UIBehavior.instance.SetScreen(UIBehavior.instance.winScreen);
                //EndGameWin();
                Debug.Log("All smaller enemies defeated");
            }
        }
    }

    public int bossLeft //CHANGE TO IF BOSS IS DEAD
    {
        get { return boss; }
        set
        {
            boss = value;
            if (boss <= 0)
            {
                //UIBehavior.instance.SetScreen(UIBehavior.instance.winScreen);
                //EndGameWin();
                Debug.Log("Boss defeated, next floor available");
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
