using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using TMPro;
using UnityEngine.UI;

public class DoorTrigger : MonoBehaviour
{
    public Animator animator;
    public AudioClip DoorClosed;
    public GameObject BoxTrigger;
    public bool BoxTriggerOn = true;
    public GameObject firstText;
    public GameObject secondText;
    public GameObject thirdText;

    public void OnTriggerEnter(Collider collision)
    {
        if (BoxTriggerOn)
        {
            animator.SetTrigger("PlayerInTower");
            AudioSource ac = GetComponent<AudioSource>();
            ac.PlayOneShot(DoorClosed);
            firstText.SetActive(false);
            secondText.SetActive(true);
            Invoke("MainObjectiveTextOn", 6.0f);
            Invoke("TurnTriggerBoolOff", 7.0f);
            if (!BoxTriggerOn)
            {
                BoxTriggerOff();
            }
        }
    }
    
    public void MainObjectiveTextOn()
    {
        secondText.SetActive(false);
        thirdText.SetActive(true);
    }

    public void BoxTriggerOff()
    {
        BoxTrigger.SetActive(false);
    }

    public void TurnTriggerBoolOff()
    {
        BoxTriggerOn = false;
    }
}
