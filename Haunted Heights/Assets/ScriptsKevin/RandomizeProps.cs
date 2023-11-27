using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeProps : MonoBehaviour
{
    public Vector3[] propLocations;
    //Vector3[] propscale= new Vector3[20];
    public GameObject[] roofType = new GameObject[3];
    public GameObject[] powerUp = new GameObject[4];


    void Awake()
    {

         for(int i=0;i<propLocations.Length;i++)
            {
            
            if(i==0)
            {
                GameObject startRoof = Instantiate(roofType[1], propLocations[i], Quaternion.Euler(0,90,0));
            }
            else if(i==10)
            {
                GameObject startRoof = Instantiate(roofType[1], propLocations[i], Quaternion.Euler(0,90,0));
            }
            else
            {
                GameObject currentRoof = Instantiate(roofType[Random.Range(0,3)], propLocations[i], Quaternion.Euler(0,90,0));
                GameObject currentPowerUp = Instantiate(powerUp[Random.Range(0,4)], propLocations[i] += new Vector3(8.76f,36.251f,0), Quaternion.Euler(0,90,0));
            }
            }
        }   
        
            
            //Spawn power up, up and right
        }
    



