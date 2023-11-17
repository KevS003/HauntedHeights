using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class DestroyClick : MonoBehaviour
{
    public int objectsDestroyed = 0;
    [SerializeField] private int objectsSpawned = 4;//Holds number of objects spawning 
    //public GameObject stopBox;
    public GameObject spawner;
    public GameObject scoreTracker;
    private Spawner functCall;
    private ScoreTracking scoreFunctCall;
    public CubeController giveDestroyNumToControl;
    public AudioPlayer audioStuff;
    //nail stuff below
    private GameObject nailRef;
    private NailNumberAssign nailNumRef;
    private int nailOrder=1;

    //script reference
    public EnemyController enemySpeedRef;

    //powerupstuff
    //private bool autoBuild = false;
    private float autoBuildTime;
    //clean up left overs
    //private bool cleanUp=false;
    //private bool checkForObj = false;
    private bool blockDestroy = false;

    //Temp UI clicks
    public GameObject slowghost;
    public GameObject autohammer;

    //AUDIO STUFF
    public AudioClip correctNail;
    public AudioClip notRight;
    public GameObject[] effects;
    //private AudioSource soundSource;

    private void Start() 
    {
        functCall = spawner.GetComponent<Spawner>();//gets script from spawner to call function later
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
                nailNumRef = bc.GetComponent<NailNumberAssign>();


                if(bc!= null)
                {
                    if(bc.gameObject.tag == "gameObject")
                    {
                        NailNumberAssign tempRef=bc.gameObject.GetComponent<NailNumberAssign>();
                        //detect if they are destroying in the right order
                        if(nailNumRef.spawnNumOrder == nailOrder)//checks the nail picked//play sound here
                        {
                            audioStuff.PlaySound(correctNail);
                             _ = Instantiate (effects[0], hit.point, Quaternion.identity);
                            //tempRef.Hit();
                            Destroy(bc.gameObject);
                            objectsDestroyed++;
                            if(nailOrder<4 )
                                nailOrder++;
                            giveDestroyNumToControl.OnNailDestroyed(blockDestroy);                               
                        }
                        //else//speed up ghost
                        else
                        {
                            audioStuff.PlaySound(notRight);
                             _ = Instantiate (effects[1], hit.point, Quaternion.identity);
                            //tempRef.Miss();
                            enemySpeedRef.speedUpGhost();
                            //slowghost.SetActive(false);//turns off ghost UI
                        }
                    }
                    
                }
            }
            
        }
            

        
        if(objectsDestroyed == objectsSpawned)
        {
            scoreFunctCall.PlayerScored();
            functCall.ResetSpawnCount();
            //call function to destroy object 
            objectsDestroyed=0;
            nailOrder =1;
            //GIVE NUM DESTROYED TO CUBE CONTROLLER
            //That num will destroy object in path and start movement 

        }

    }

    public void AutoBuild(float time)
    {
        autoBuildTime = time;
    }
    
}
