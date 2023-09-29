using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    //Bullet destroy delay
    public float onscreenDelay = 3f;
    public int damage;
    private void Start()
    {
        Destroy(this.gameObject, onscreenDelay);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player"))
        {
            other.gameObject.GetComponentInParent<PlayerMovement>().playerHP -= damage;
        }
        Destroy(this.gameObject);
    }
}
