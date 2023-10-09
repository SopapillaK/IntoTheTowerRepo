using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCam : MonoBehaviour
{
    private Transform _camTransform;
    public Transform enemyPosition;

    // Start is called before the first frame update
    private void Start()
    {
        _camTransform = Camera.main.transform;
    }
    void Update()
    {
        transform.LookAt(Camera.main.transform.position);
        transform.Rotate(new Vector3(0, 180, 0));
        transform.position = enemyPosition.position;
    }
}
