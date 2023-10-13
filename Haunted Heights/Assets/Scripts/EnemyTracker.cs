using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyTracker : MonoBehaviour
{
    public GameObject enemy;
    public GameObject player;
    public GameObject enemyTracker;
    private TextMeshProUGUI enemyTrackerText;

    

    private float distance;

    void Start()
    { 
        enemyTrackerText = enemyTracker.GetComponent<TextMeshProUGUI>();
    }
    
    void FixedUpdate()
    {
    /*float y2 = player.transform.position.y;
    float y1 = enemy.transform.position.y;

    float x2 = player.transform.position.x;
    float x1 = player.transform.position.x;

    float newY = y2 - y1;
    float newX = x2 - x1;

    
    float Y = newY * newY;
    float X = newX * newX;

    float Answer = Y + X;

    Distance = Mathf.Pow (Answer,Answer);

    Debug.Log(Distance); */

       distance = Vector3.Distance (player.transform.position, enemy.transform.position);
    }

    void Update()
    {
        enemyTrackerText.text = distance.ToString();
    }

}
