using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
public class SpawnerProper : MonoBehaviour
{
    public GameObject[] selectObject;
    //public DestroyClick getDestroyedNum;// grabs variable from other script to use as a conditional here
    public GameObject cameraTrack;
    public DayNight dayNightTrack;

    public CubeController checkHitOnBox;
    public ScoreTracking scoreRef;
    private Vector3 cameraTransform;
    private NailNumberAssign spawnIndexTrack;
    private bool scoot;
    public int spawnCount;//amount of items spawned //reset number once all objects are destroyed//UPDATE OBJECTS SPAWNED IF THIS CHANGES
    public bool objectsDestroyed;//checks if objects are destroyed currently not in use //number used to reset
    private Vector3[] spawnLocations = new Vector3[4];


    public float objectSpawn= 3.5f;
    private float objectSpawnDupe;//keeps oroginal time saved
    //saves spawn positions and doesn't spawn them in the same spot
    //Vector3[] spawnPositions;
    // Start is called before the first frame update
    void Start()
    {
        objectSpawnDupe = objectSpawn;
    }

    private void FixedUpdate() 
    {
        
        cameraTransform =cameraTrack.transform.position;
        if(objectSpawn > 0)
            objectSpawn-= Time.deltaTime + (.25f * dayNightTrack.dayNightTracker);
        
        if(objectSpawn<0 && spawnCount<4 && checkHitOnBox.stop == true)
        {
            //declare list or array of nail spawn(Vector 3 of locations)(start at left) for loop for spawn

            int randomIndex = Random.Range(0,selectObject.Length);
            Vector3 randomSpawnPosition=new Vector3(Random.Range(cameraTransform.x-5,cameraTransform.x+8),cameraTransform.y,cameraTransform.z+10);//change range to reference the cameras current position.
            for(int i =0; i<=selectObject.Length;i++)
            {
                spawnLocations[i] = new Vector3(Random.Range(cameraTransform.x-5,cameraTransform.x+8),cameraTransform.y,cameraTransform.z+10);

                //base distance randomize distance
            }
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
    void DoPositionStuffs()
        {
            Vector3[] positions = new Vector3[/*however many nails to spawn/*/ 4];
            Vector3 startPosition = Vector3.one; // left most position
            Vector3 previousPosition = startPosition;

            Vector3 minMoveDistance = Vector3.right / 2;

            positions[0] = startPosition;
            for(int i = 1; i < positions.Length; i++)
            {
                Vector3 newPos = previousPosition + minMoveDistance;
                newPos += Vector3.right * Random.Range(0, 4);
                positions[i] = newPos;
                previousPosition = newPos;
            }

            List<Vector3> positionsList = positions.ToList();
            for(int i = 0; i < positions.Length; i++)
            {
                int index;
                if(positionsList.Count == 1)
                    index = 0;
                else
                    index = Random.Range(0, positionsList.Count);
                // Instantiate nail at positionsList[index];
                //GameObject currentNail = Instantiate(selectObject[randomIndex], randomSpawnPosition, Quaternion.identity);

                positionsList.RemoveAt(index);
            }

        }

        /*private void IEnumerator()
        {
            return 1;
        }*/
}