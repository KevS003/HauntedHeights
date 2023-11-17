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
        Vector3 spawnerPosition = transform.position;

    Vector3 spawnPosition = new Vector3(
        Random.Range(spawnBoundaryMin.x, spawnBoundaryMax.x),
        Random.Range(spawnBoundaryMin.y, spawnBoundaryMax.y),
        0f // Assuming the spawn is in the 2D space (X, Y) on the ground plane
    );

    // Adding the spawner's position to the spawnPosition
    spawnPosition += spawnerPosition;

    Debug.Log("Spawn Position: " + spawnPosition); // Log the spawn position

    GameObject newGhost = Instantiate(ghostPrefab, spawnPosition, Quaternion.identity);
    GhostMovement ghostMovement = newGhost.GetComponent<GhostMovement>();

    if (ghostMovement != null)
    {
        ghostMovement.SetMovementType(defaultMovementType);
    }
    }
}
