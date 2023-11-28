using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OutOfBoundsCollider : MonoBehaviour
{
    public void OnTriggerEnter(Collider collision)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
