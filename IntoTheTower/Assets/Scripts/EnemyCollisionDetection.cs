using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisionDetection : MonoBehaviour
{
    public EnemyWeaponController ewc;
    //public GameObject HitParticle;

    public int weaponDamage; // damage weapn inflicts

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && ewc.IsAttacking)
        {
            Debug.Log(other.name);
            other.transform.GetComponentInParent<PlayerMovement>().playerHP -= weaponDamage; //Get the hit target's HP script and inflicts damage on it
            //Instantiate(HitParticle, new Vector3(other.transform.position.x,
            //transform.position.y, other.transform.position.z), 
            //other.transform.rotation); 
        }
    }
}
