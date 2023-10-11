using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
   
    gameManager GameManager;
    public ScoreTracking scoreRef;

    

    void Start()
    {
        GameObject gameController = GameObject.FindGameObjectWithTag("GameController");
        GameManager = gameController.GetComponent<gameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //if statement if player scores an if player misses order.

        transform.Translate(GameManager.moveVector * GameManager.enemySpeed *  Time.deltaTime);

    }

    public void speedUpGhost()
    {
        GameManager.enemySpeed /= GameManager.speedMultiplier;//HUH
        //transform.Translate(GameManager.moveVector * GameManager.enemySpeed * GameManager.speedMultiplier *  Time.deltaTime);
        Debug.Log(GameManager.enemySpeed.ToString());
    }

}
