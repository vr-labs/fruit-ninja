using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flying : MonoBehaviour
{
    public float horizontalSpeed = 10.0f;
    public float verticalSpeed = 20.0f;
    public float height = 2.0f;
    public float g = Physics.gravity.y;

    public Vector3 tempPosition;
    public float startX;
    public float startY;
    public float angle;

    // Start is called before the first frame update
    void Start()
    {
        tempPosition = transform.position;
        startX = tempPosition.x;
        startY = tempPosition.y;
        angle = UnityEngine.Random.Range(Mathf.PI / 6, Mathf.PI / 3);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        tempPosition.x += startX + horizontalSpeed * Mathf.Cos(Mathf.PI / 3) * Time.realtimeSinceStartup;
        tempPosition.y += startY + verticalSpeed * Mathf.Sin(Mathf.PI / 3) * Time.realtimeSinceStartup - g * Time.realtimeSinceStartup * Time.realtimeSinceStartup / 2;
        transform.position = tempPosition;
        transform.position = tempPosition;
    }
}