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
    private bool cleanUp=false;
    //private bool checkForObj = false;
    private bool blockDestroy = false;

    //Temp UI clicks
    public GameObject slowghost;
    public GameObject autohammer;

    private void Start() 
    {
        functCall = spawner.GetComponent<Spawner>();//gets script from spawner to call function later
        scoreFunctCall = scoreTracker.GetComponent<ScoreTracking>();
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
                        //detect if they are destroying in the right order
                        if(nailNumRef.spawnNumOrder == nailOrder || cleanUp == true)//checks the nail picked
                        {

                            Destroy(bc.gameObject);
                            objectsDestroyed++;
                            if(nailOrder<4 && cleanUp == false)
                                nailOrder++;
                            else if(cleanUp == true && nailNumRef.lastOne == true)
                            {
                                nailOrder = 4;
                                blockDestroy = true;
                            }
                            giveDestroyNumToControl.OnNailDestroyed(blockDestroy);
                            if(blockDestroy == true)//massive reset
                            {
                                blockDestroy = false;
                                cleanUp = false;
                                functCall.ResetSpawnCount();
                                nailOrder = 1;
                                objectsDestroyed = 0;
                                autohammer.SetActive(false);
                            }
                                

                                
                        }
                        //else//speed up ghost
                        else
                        {
                            enemySpeedRef.speedUpGhost();
                            //slowghost.SetActive(false);//turns off ghost UI
                        }
                    }
                    
                }
            }
            
        }
        else if(autoBuildTime >0.01f)//AutoBuilds on timer, calls necessary functions on other scripts
        {
            autoBuildTime -= Time.deltaTime;
            //Debug.Log("AutoBuild timer: "+ autoBuildTime);
            //spawn logo for autobuild here UI
            Destroy(GameObject.FindWithTag("gameObject"));
            cleanUp = true;
            //Debug.Log("Current nail num: "+ nailOrder);
            if(functCall.spawnCount == 4)
            {
                giveDestroyNumToControl.AutoDestroyOn();
                scoreFunctCall.PlayerScored();
                functCall.ResetSpawnCount();
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
