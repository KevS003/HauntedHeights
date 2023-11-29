using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    public Timer timeRef;
    // Update is called once per frame
    
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "ghost"|| other.tag == "powerup"|| other.tag== "ghostBad")
        {
            if(other.tag == "ghost")
                timeRef.TimeSubGhostWall();
            Destroy(other.gameObject);
        }
            
            
    }
}
