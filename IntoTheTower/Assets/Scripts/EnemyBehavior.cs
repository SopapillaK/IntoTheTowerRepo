using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public Animator enemy;
    private int hp = 5; //Private value for hp
    public int enemyHP { get { return hp; }  //Get Doesn't need any functions, since we only need to check hp when changed
        set 
        { hp = value; //Set hp equal to what it is supposed to be
            enemy.SetTrigger("Hit");
            if (hp <= 0)
            { //if has no HP left, disable the gameobject
                enemy.SetTrigger("Dead");
            }
        } 
    }

    public void Die()
    {
        GameManager.instance.enemiesLeft--;
        this.gameObject.SetActive(false); //Change to Destroy(this.gameObject) when having multiple enemies spawn in and die
    }
    public void Start()
    {
        GameManager.instance.enemiesLeft++;
    }
}
