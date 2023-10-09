using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    public WeaponController wc;
    //public GameObject HitParticle;

    public int weaponDamage; // damage weapn inflicts

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy" && wc.IsAttacking)
        {
            Debug.Log(other.name); 
            other.GetComponent<EnemyBehavior>().enemyHP -= weaponDamage; //Get the hit target's HP script and inflicts damage on it
            //Instantiate(HitParticle, new Vector3(other.transform.position.x,
            //transform.position.y, other.transform.position.z), 
            //other.transform.rotation); 
        }
    }
}
