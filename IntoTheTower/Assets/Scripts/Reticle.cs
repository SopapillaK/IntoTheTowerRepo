using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Reticle : MonoBehaviour
{
    private RectTransform reticle;

    public float restingSize;
    public float maxSize;
    public float speed;
    private float currentSize;

    private void Start()
    {
        reticle = GetComponent<RectTransform>();
    }

    private void Update()
    {
        
    }

}

//https://www.youtube.com/watch?v=-7DIdKTNjfQ
