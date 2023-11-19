using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerThoughts : MonoBehaviour
{
    public GameObject Text;

    public void OnTriggerEnter(Collider collision)
    {
        Text.SetActive(true);
        Invoke("TurnTextOff", 4.5f);
    }

    public void TurnTextOff()
    {
        Text.SetActive(false);
    }
}
