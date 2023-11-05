using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehavior : MonoBehaviour
{
    public void Start()
    {
        GameManager.instance.bossLeft++;
    }

    public void Die()
    {
        GameManager.instance.bossLeft--;
        Destroy(this.gameObject.transform.parent.gameObject); //Change to Destroy(this.gameObject) when having multiple enemies spawn in and die
    }
}
