using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponController : MonoBehaviour
{
    public GameObject EnemySword;
    public bool CanAttack = true;
    public float AttackCooldown = 1.0f;
    //public AudioClip EnemySwordAttackSound;
    public bool IsAttacking = false;


    public void SwordAttack()
    {
        IsAttacking = true;
        CanAttack = false;
        Debug.Log("Enemy should grab enemysword animator");
        Animator anim = EnemySword.GetComponent<Animator>();
        Debug.Log("Enemy should set trigger for EnemySwordAttack");
        anim.SetTrigger("EnemySwordAttack");
        //AudioSource ac = GetComponent<AudioSource>();
        //ac.PlayOneShot(EnemySwordAttackSound);
        StartCoroutine(ResetAttackCooldown());
    }

    IEnumerator ResetAttackCooldown()
    {
        StartCoroutine(ResetAttackBool());
        yield return new WaitForSeconds(AttackCooldown);
        CanAttack = true;
    }

    IEnumerator ResetAttackBool()
    {
        yield return new WaitForSeconds(2.0f);
        IsAttacking = false;

    }
}
