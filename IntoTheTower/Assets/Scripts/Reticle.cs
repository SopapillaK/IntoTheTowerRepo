using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Reticle : MonoBehaviour
{
    private RectTransform reticle;

    public float size;


    private void Start()
    {
        reticle = GetComponent<RectTransform>();
    }

    private void Update()
    {
        
    }
}
