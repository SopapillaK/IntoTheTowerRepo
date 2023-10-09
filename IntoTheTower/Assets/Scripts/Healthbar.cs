using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    //private Transform _camTransform;
    //public Transform enemyPosition;
    public void UpdateHealthBar(float currentValue, float maxValue)
    {
        slider.value = currentValue/maxValue;
    }

    /*private void Start()
    {
        _camTransform = Camera.main.transform;
    }
    void Update()
    {
        transform.LookAt(Camera.main.transform.position);
        transform.Rotate(new Vector3(0, 180, 0));
        transform.position = enemyPosition.position;
    }*/
}
