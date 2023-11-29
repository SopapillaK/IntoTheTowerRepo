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
    public GameObject BossRockBlock;
    public GameObject BossRockCollider;
    public AudioClip BossRockFall;
    public GameObject F1ExitCollider;

    public Animator exitDoorAnimator;
    public AudioClip exitDoorSound;


    public int enemiesLeft 
    {
        get { return enemies; }
        set
        {
            enemies = value;
            if (enemies <= 1)
            {
                BossRockBlock.SetActive(false);
                BossRockCollider.SetActive(false);
                AudioSource ac = GetComponent<AudioSource>();
                ac.PlayOneShot(BossRockFall);
            }
            else
            {
                BossRockBlock.SetActive(true);
                BossRockCollider.SetActive(true);
            }
            if (enemies <= 0)
            {
                //UIBehavior.instance.SetScreen(UIBehavior.instance.winScreen);
                //EndGameWin();
                allEnemiesDead = true;
                F1ExitCollider.SetActive(false);
                Invoke("ExitFloor1", 3.0f);
            }
            else
            {
                F1ExitCollider.SetActive(true);
            }
        }
    }

    public void ExitFloor1()
    {
        exitDoorAnimator.SetTrigger("PlayerExitFloor1");
        AudioSource ac = GetComponent<AudioSource>();
        ac.PlayOneShot(exitDoorSound);
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
