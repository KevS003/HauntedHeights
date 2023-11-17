using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostSpawner : MonoBehaviour
{
    public GameObject[] itemSpawn;
    public float spawnRate = 1.5f;
    public Vector2 spawnBoundaryMin;
    public Vector2 spawnBoundaryMax;
    public GhostMovement.MovementType defaultMovementType = GhostMovement.MovementType.Horizontal; // Default movement type

    float nextSpawnTime;

    void Update()
    {
        if (Time.time > nextSpawnTime)
        {
            //SpawnGhost();
            Spawner();
            nextSpawnTime = Time.time + spawnRate;
        }
    }

    void SpawnGhost()
    {
        Vector2 spawnPosition = new Vector2(
            Random.Range(spawnBoundaryMin.x, spawnBoundaryMax.x),
            Random.Range(spawnBoundaryMin.y, spawnBoundaryMax.y)
        ); 

        GameObject newGhost = Instantiate(itemSpawn[Random.Range(0,itemSpawn.Length)], spawnPosition, Quaternion.identity);
        GhostMovement ghostMovement = newGhost.GetComponent<GhostMovement>();

        if (ghostMovement != null)
        {
            ghostMovement.SetMovementType(defaultMovementType);
        }
    }
    void Spawner()
    {
         GameObject newGhost = Instantiate(itemSpawn[Random.Range(0,itemSpawn.Length)], this.gameObject.transform.position, Quaternion.identity);
    }
}
