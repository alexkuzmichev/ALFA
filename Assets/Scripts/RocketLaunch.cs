using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLaunch : MonoBehaviour
{
    public float HorizontalSpeed;
    public float VerticalSpeed;
    public float Amplitude;
    Vector3 tempPosition;
    void Start()
    {
        tempPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        tempPosition.x += HorizontalSpeed;
        tempPosition.y = Mathf.Sin(Time.realtimeSinceStartup * VerticalSpeed) * Amplitude;
        transform.position = tempPosition;


    }
}
