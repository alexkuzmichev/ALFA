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
    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
        tempPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        tempPosition.x += HorizontalSpeed;
        tempPosition.y = tempPosition.x * tempPosition.x;// Mathf.Sin(Time.realtimeSinceStartup * VerticalSpeed) * Amplitude;
        transform.position = tempPosition - startPos;
        Debug.Log(tempPosition);

    }
}
