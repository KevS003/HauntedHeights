using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMovement : MonoBehaviour
{
    [System.Serializable]
    public enum MovementType
    {
        Horizontal,
        Vertical,
        Waypoints,
        Random
    }

    public float speed = 3.0f;
    public float moveDistance = 10.0f;
    public Vector3[] waypoints;

    [SerializeField]
    private MovementType currentMovementType = MovementType.Horizontal;


    private int currentWaypoint = 0;
    private Vector3 initialPosition;
    private bool movingRight = true;
    private bool movingUp = true;
    private float distanceMoved = 0.0f;
    private Vector3 randomDirection;

    void Start()
    {
        initialPosition = transform.position;
        randomDirection = Random.insideUnitCircle.normalized;
    }

    void Update()
    {
        switch (currentMovementType)
        {
            case MovementType.Horizontal:
                HorizontalMovement();
                break;
            case MovementType.Vertical:
                VerticalMovement();
                break;
            case MovementType.Waypoints:
                WaypointMovement();
                break;
            case MovementType.Random:
                RandomMovement();
                break;
            default:
                break;
        }

        if (Input.GetMouseButtonDown(0) && IsMouseOverGhost())
        {
            DestroyGhost();
        }
    }

    bool IsMouseOverGhost()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            return hit.collider.gameObject == gameObject;
        }

        return false;
    }

    void DestroyGhost()
    {
    GameObject hammer = GameObject.Find("Hammer"); 

    if (hammer != null)
    {
        hammer.SetActive(true);
        hammer.transform.position = transform.position + new Vector3(0f, 0f, -1f); // Set the initial position of the hammer

        // Define the destination where the hammer should move towards (e.g., ghost's position)
        Vector3 targetPosition = transform.position;
        Vector3 direction = (targetPosition - hammer.transform.position).normalized;
        float distance = Vector3.Distance(hammer.transform.position, targetPosition);
        float speed = 30.0f; // Adjust this value to control the speed of the hammer

        // Move the hammer towards the ghost
        hammer.GetComponent<Rigidbody>().velocity = direction * speed;

        // Destroy the ghost
        Destroy(gameObject);
    }
    else
    {
        Debug.Log("Hammer GameObject not found. Make sure to set the correct name in the script.");
        Destroy(gameObject);
    }
    }

    void HorizontalMovement()
    {
        transform.Translate(movingRight ? Vector3.right : Vector3.left * speed * Time.deltaTime);
        distanceMoved += speed * Time.deltaTime;

        if (distanceMoved >= moveDistance)
        {
            movingRight = !movingRight;
            distanceMoved = 0.0f;
            transform.position = initialPosition;
        }
    }

    void VerticalMovement()
    {
        transform.Translate(movingUp ? Vector3.up : Vector3.down * speed * Time.deltaTime);
        distanceMoved += speed * Time.deltaTime;

        if (distanceMoved >= moveDistance)
        {
            movingUp = !movingUp;
            distanceMoved = 0.0f;
            transform.position = initialPosition;
        }
    }

    void WaypointMovement()
    {
        if (currentWaypoint < waypoints.Length)
        {
            Vector3 targetPosition = waypoints[currentWaypoint];
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

            if (transform.position == targetPosition)
            {
                currentWaypoint++;
            }
        }
    }

    void RandomMovement()
    {
        transform.Translate(randomDirection * speed * Time.deltaTime);
    }

    public void SetMovementType(MovementType type)
    {
        currentMovementType = type;
        currentWaypoint = 0;
        transform.position = initialPosition;
        randomDirection = Random.insideUnitCircle.normalized;
    }
}

