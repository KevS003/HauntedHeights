using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] selectObject;
    //public DestroyClick getDestroyedNum;// grabs variable from other script to use as a conditional here
    public int spawnCount;//amount of items spawned //reset number once all objects are destroyed//UPDATE OBJECTS SPAWNED IF THIS CHANGES
    public bool objectsDestroyed;//checks if objects are destroyed currently not in use //number used to reset


    public float objectSpawn= 3.5f;
    private float objectSpawnDupe;//keeps oroginal time saved
    // Start is called before the first frame update
    void Start()
    {
        objectSpawnDupe = objectSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        if(objectSpawn > 0)
            objectSpawn-= Time.deltaTime;

        if(objectSpawn<0 && spawnCount<4)
        {
            int randomIndex = Random.Range(0,selectObject.Length);
            Vector3 randomSpawnPosition=new Vector3(Random.Range(-5,8),5,0);

            Instantiate(selectObject[randomIndex], randomSpawnPosition, Quaternion.identity);
            spawnCount++;
            objectSpawn = objectSpawnDupe;

        }
        /*
        else if(spawnCount ==4)
        {
            //check score for items clicked
            //reference score here for reset as a conditional
            //wait for objects to be destroyed
            //if(objects in range ==0)
                //objects destroyerd == true;


        }*/

    }


    public void ResetSpawnCount()//call this to reset spawn count and spawn in 4 more objects
    {
        spawnCount = 0;
    }
}
