using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
   
    gameManager GameManager;
    [SerializeField]
    GameObject powerUpEnemy;
    public ScoreTracking scoreRef;
    private float minSpeedGhost;
    public float uiTimer= 1f;
    private float speed;

    

    void Start()
    {
        GameObject gameController = GameObject.FindGameObjectWithTag("GameController");
        GameManager = gameController.GetComponent<gameManager>();
        if(gameObject.tag == "ghost"||gameObject.tag == "ghostBad"|| gameObject.tag == "powerup")
        {
            speed = (Random.Range(5,70));
            //GameManager.enemySpeed= speed;
        }
        minSpeedGhost = GameManager.enemySpeed;
    }

    // Update is called once per frame
    void Update()
    {
        //if statement if player scores an if player misses order.
        if(gameObject.tag == "ghost"||gameObject.tag == "ghostBad"|| gameObject.tag == "powerup")
        {
            transform.Translate(GameManager.moveVector * speed *  Time.deltaTime);
        }
        else
            transform.Translate(GameManager.moveVector * GameManager.enemySpeed *  Time.deltaTime);

    }

    public void speedUpGhost()
    {
        GameManager.enemySpeed /= GameManager.speedMultiplier;//HUH
        //transform.Translate(GameManager.moveVector * GameManager.enemySpeed * GameManager.speedMultiplier *  Time.deltaTime);
        Debug.Log(GameManager.enemySpeed.ToString());
    }

    public void speedDownGhost()
    {
        if(GameManager.enemySpeed > minSpeedGhost)
            GameManager.enemySpeed *= GameManager.speedMultiplier;//HUH
        else
            GameManager.enemySpeed = minSpeedGhost;
        Debug.Log(GameManager.enemySpeed.ToString());
        StartCoroutine(ghostUI(uiTimer));
    }
    private IEnumerator ghostUI(float uiTimer)
    {
        
        yield return new WaitForSeconds(uiTimer);
        powerUpEnemy.SetActive(false);
    }

}
