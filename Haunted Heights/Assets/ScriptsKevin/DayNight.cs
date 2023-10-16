using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNight : MonoBehaviour
{
    public Transform pointA; // The starting point
    public Transform pointB; // The ending point
    public float rotationSpeed = 45.0f; // Speed of rotation in degrees per second

    private float timeElapsed = 0.0f;

    void Update()
    {
        timeElapsed += Time.deltaTime * rotationSpeed;

        if (timeElapsed >= 1.0f)
        {
            // Swap the points when the light reaches the destination
            Transform temp = pointA;
            pointA = pointB;
            pointB = temp;
            timeElapsed = 0.0f;
        }

        // Calculate the position for the light using PingPong
         transform.rotation = Quaternion.Lerp(pointA.rotation, pointB.rotation, timeElapsed);
    }
}
