using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIBehavior : MonoBehaviour
{
    public GameObject winScreen;

    public static UIBehavior instance; // sets instance, allows me to call upon function and variables inside this script from other scripts

    public void Start() 
    {
        instance = this; 
    }
    public void SetScreen(GameObject screen) //sets screen for all future screens
    {
        winScreen.SetActive(false);

        screen.SetActive(true);
    }
}
