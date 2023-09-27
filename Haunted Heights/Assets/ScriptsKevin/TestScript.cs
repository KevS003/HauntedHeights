using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    public GameObject[] selectObject;
    public int spawnCount;
    public bool objectsDestroyed;


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
            Vector3 randomSpawnPosition=new Vector3(Random.Range(-10,11),5,Random.Range(-10,11));

            Instantiate(selectObject[randomIndex], randomSpawnPosition, Quaternion.identity);
            spawnCount++;
            objectSpawn = objectSpawnDupe;

        }
        else if(spawnCount ==4)
        {
            //wait for objects to be destroyed
            //if(objects in range ==0)
                //objects destroyerd == true;

        }

    }
}
