using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class NailNumberAssign : MonoBehaviour
{
    public int spawnNumOrder=0;
    public bool lastOne = false;
    // Start is called before the first frame update
    private void Awake() 
    {
        //spawn a spehere cast to detect if something here
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), .5f)==true ||
            Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), .5f)==true)
        {
            Vector3 currentPositions = transform.position;
            transform.position = new Vector3(currentPositions.x+2, currentPositions.y, currentPositions.z);
        }

          
    }
    public void AssignNumber(int num)
    {
        spawnNumOrder = num;
        Debug.Log("NAIL"+ spawnNumOrder.ToString());
    }
    private void FixedUpdate() 
    {
        if(spawnNumOrder == 4)
        {
            lastOne = true;
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "gameObject")
        {

            
        }
        
    }
}
