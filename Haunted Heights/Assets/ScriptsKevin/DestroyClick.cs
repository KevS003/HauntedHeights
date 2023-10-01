using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DestroyClick : MonoBehaviour
{
    public int objectsDestroyed = 0;
    [SerializeField] private int objectsSpawned = 4;//Holds number of objects spawning 
    public GameObject stopBox;
    public GameObject spawner;
    public GameObject scoreTracker;
    private Spawner functCall;
    private ScoreTracking scoreFunctCall;
    public CubeController giveDestroyNumToControl;

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
                if(bc!= null)
                {
                    if(bc.gameObject.tag == "gameObject")
                    {
                        Destroy(bc.gameObject);
                        objectsDestroyed++;
                        giveDestroyNumToControl.OnNailDestroyed();
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
            //GIVE NUM DESTROYED TO CUBE CONTROLLER
            //That num will destroy object in path and start movement 

        }


    }
    
}
