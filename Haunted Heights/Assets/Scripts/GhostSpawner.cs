using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostSpawner : MonoBehaviour
{
    public GameObject ghostPrefab;
    public float spawnRate = 1.5f;
    public Vector2 spawnBoundaryMin;
    public Vector2 spawnBoundaryMax;
    public GhostMovement.MovementType defaultMovementType = GhostMovement.MovementType.Horizontal; // Default movement type

    float nextSpawnTime;

    void Update()
    {
        if (Time.time > nextSpawnTime)
        {
            SpawnGhost();
            nextSpawnTime = Time.time + spawnRate;
        }
    }

    void SpawnGhost()
    {
        Vector2 spawnPosition = new Vector2(
            Random.Range(spawnBoundaryMin.x, spawnBoundaryMax.x),
            Random.Range(spawnBoundaryMin.y, spawnBoundaryMax.y)
        );

        GameObject newGhost = Instantiate(ghostPrefab, spawnPosition, Quaternion.identity);
        GhostMovement ghostMovement = newGhost.GetComponent<GhostMovement>();

        if (ghostMovement != null)
        {
            ghostMovement.SetMovementType(defaultMovementType);
        }
    }
}
