using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Spawner : MonoBehaviour
{
    public GameObject[] selectObject;
    //public DestroyClick getDestroyedNum;// grabs variable from other script to use as a conditional here
    public GameObject cameraTrack;

    public CubeController checkHitOnBox;
    public ScoreTracking scoreRef;
    private Vector3 cameraTransform;
    private NailNumberAssign spawnIndexTrack;
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
        cameraTransform =cameraTrack.transform.position;
        if(objectSpawn > 0)
            objectSpawn-= Time.deltaTime + (.00025f * scoreRef.totalScore);
    }
    private void FixedUpdate() 
    {
        if(objectSpawn<0 && spawnCount<4 && checkHitOnBox.stop == true)
        {
            int randomIndex = Random.Range(0,selectObject.Length);
            Vector3 randomSpawnPosition=new Vector3(Random.Range(cameraTransform.x-5,cameraTransform.x+8),cameraTransform.y,cameraTransform.z+10);//change range to reference the cameras current position. 

            GameObject currentNail = Instantiate(selectObject[randomIndex], randomSpawnPosition, Quaternion.identity);
            spawnCount++;
            objectSpawn = objectSpawnDupe;
            spawnIndexTrack = currentNail.GetComponent<NailNumberAssign>();
            spawnIndexTrack.AssignNumber(spawnCount);

        }
    }


    public void ResetSpawnCount()//call this to reset spawn count and spawn in 4 more objects
    {
        spawnCount = 0;
    }
}
