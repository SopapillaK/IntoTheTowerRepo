using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class DoorTrigger : MonoBehaviour
{
    public Animator animator;
    public AudioClip DoorClosed;

    public void OnTriggerEnter(Collider collision)
    {
        animator.SetTrigger("PlayerInTower");
        AudioSource ac = GetComponent<AudioSource>();
        ac.PlayOneShot(DoorClosed);

    }
    //public void CloseDoor()
    //{
    //    //Animator anim = Sword.GetComponent<Animator>();
    //    animator.SetTrigger("PlayerInTower");
    //    //AudioSource ac = GetComponent<AudioSource>();
    //    //ac.PlayOneShot(SwordAttackSound);
    //}
}
