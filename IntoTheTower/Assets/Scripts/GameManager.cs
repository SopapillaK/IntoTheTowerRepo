using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    private bool gameWon = false;
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
                EndGame();
            }
        }
    }

    private void Awake()
    {
        instance = this; 
    }

    public void EndGame()
    {
        if (gameWon == false)
        {
            gameWon = true;
            Debug.Log("Game Over");
            Invoke("Restart", restartDelay);
        }
    }

    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
