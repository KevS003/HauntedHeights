using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNight : MonoBehaviour
{
    public Transform pointA; // The starting point
    public Transform pointB; // The ending point
    public float rotationSpeed = 45.0f; // Speed of rotation in degrees per second

    public float timeElapsed = 0.0f;
    public float dayNightTracker;
    private bool hitZero = true;

    void Update()
    {
        timeElapsed += Time.deltaTime * rotationSpeed;
        
        if(dayNightTracker < 1 && hitZero == true)
        {
            dayNightTracker+= Time.deltaTime * rotationSpeed;
            if(dayNightTracker>=1)
                hitZero = false;
        }   
        else if(dayNightTracker> 0)
        {
            dayNightTracker-= Time.deltaTime * rotationSpeed;
            if(dayNightTracker <=0 )
            {
                hitZero = true;
            }

        }
        //Debug.Log("TimeTrack "+ dayNightTracker);

        if (timeElapsed >= 1.0f)
        {
            Transform temp = pointA;
            pointA = pointB;
            pointB = temp;
            timeElapsed = 0.0f;
        }

         transform.rotation = Quaternion.Lerp(pointA.rotation, pointB.rotation, timeElapsed);
    }
}
