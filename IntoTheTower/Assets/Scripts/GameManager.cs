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
    public bool allEnemiesDead;

    public Animator exitDoorAnimator;


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
                allEnemiesDead = true;
                Debug.Log("All enemies defeated Exit door now unlocked!");
                Invoke("ExitFloor1", 3.0f);
            }
        }
    }

    public void ExitFloor1()
    {
        exitDoorAnimator.SetTrigger("PlayerExitFloor1");
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
