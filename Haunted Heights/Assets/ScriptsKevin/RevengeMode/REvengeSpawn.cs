using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class REvengeSpawn: MonoBehaviour
{
    public Vector3[] propLocations;
    //Vector3[] propscale= new Vector3[20];
    public GameObject[] typeSpawn = new GameObject[3];
    public GameObject[] powerUp = new GameObject[4];

    void Awake()
    {
        
        
    }
    private void Update() 
    {
        
        GameObject currentRoof = Instantiate(typeSpawn[Random.Range(0,4)], this.transform.position, Quaternion.identity);
    }


}
