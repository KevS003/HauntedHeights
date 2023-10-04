using System.Collections;
using System.Collections.Generic;
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
                        //detect if they are destorying in the right order
                        if(nailNumRef.spawnNumOrder == nailOrder)
                        {
                            Destroy(bc.gameObject);
                            objectsDestroyed++;
                            if(nailOrder<4)
                                nailOrder++;
                            giveDestroyNumToControl.OnNailDestroyed();
                        }
                        //else//respawn nails
                        //else if()
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
    
}
