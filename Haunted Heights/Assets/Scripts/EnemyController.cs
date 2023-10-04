using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
   
    gameManager GameManager;

    

    void Start()
    {
        GameObject gameController = GameObject.FindGameObjectWithTag("GameController");
        GameManager = gameController.GetComponent<gameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(GameManager.moveVector * GameManager.moveSpeed *  Time.deltaTime);

    }

}
