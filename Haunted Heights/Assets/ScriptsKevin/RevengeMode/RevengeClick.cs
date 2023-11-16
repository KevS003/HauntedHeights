using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.VFX;

public class RevengeClick : MonoBehaviour
{
    public GameObject spawner;
    public GameObject scoreTracker;
    private ScoreTracking scoreFunctCall;
    public Timer timeRef;
    public AudioPlayer audioStuff;

    //Temp UI clicks
    /* public GameObject slowghost;
    public GameObject doublePoints; */

    //AUDIO STUFF
    public AudioClip ghostPoof;
    public AudioClip poofBad;
    public bool scoreDouble;
    public VisualEffectAsset[] effects;

    //private AudioSource soundSource;

    private void Start() 
    {
        //functCall = spawner.GetComponent<Spawner>();//gets script from spawner to call function later
        scoreFunctCall = scoreTracker.GetComponent<ScoreTracking>();
        //soundSource = gameObject.GetComponent<AudioSource>();
    }
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit))
            {
                Collider bc = hit.collider as Collider;
                //nailRef = bc.GetComponent<GameObject>();
                if(bc!= null)
                {
                    if(bc.gameObject.tag == "ghostBad" || bc.gameObject.tag == "ghost"|| bc.gameObject.tag == "powerup")
                    {
                        if(bc.gameObject.tag == "ghost")
                        {
                            //Sends info to score script that the player scored
                            //Could work with spawner
                            
                            Debug.Log("DIEEEEEEEEEEEE");
                            //VisualEffectAsset _ = Instantiate (effects[0], hit.point, Quaternion.identity);
                            scoreFunctCall.PlayerScoredRevenge(scoreDouble);
                            audioStuff.PlaySound(ghostPoof);
                            Destroy(bc.gameObject);
                               
                        }
                        else if(bc.gameObject.tag == "powerup")
                        {
                            PUItemRevenge quickref=bc.gameObject.GetComponent<PUItemRevenge>();
                            quickref.PowerUp();                           
                            //send to powerup script and run function.
                            //check bool for type.  
                            //slow time should send info to another script to run a coroutine 

                        }
                        else if(bc.gameObject.tag == "ghostBad")
                        {
                            timeRef.TimeSub();
                            audioStuff.PlaySound(poofBad);
                            Destroy(bc.gameObject);
                        } 
                    }
                    
                }
            }
            
        }

    }
    
}
