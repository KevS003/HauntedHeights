using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

public class CubeController : MonoBehaviour
{

    gameManager GameManager;
    [SerializeField]
    private Animator playerAnims;
    private int blocksDestroyed;
    private int currentBlock=0;
    public bool stop;
    private GameObject stopBlockRef= null;
    public float health = 3;
    //TEMPORARY SOLUTION VAR
    private float animSpeedStart;
    //camera shake
    public CameraShake camShakeRef;

 
    void Start()
    {
        GameObject gameController = GameObject.FindGameObjectWithTag("GameController");
        GameManager = gameController.GetComponent<gameManager>();
        animSpeedStart = playerAnims.speed;

    }

    
    void Update()
    {
        //if there is no block tagged stop in front keep moving
        //When blocked wait until all 4 things are ded and move forward. 
        //Use collision to respawn nails
        //If statement when making contact with box that activates variable
        if(stop == false)//detects collision to stop movement
            transform.Translate(GameManager.moveVector * GameManager.moveSpeed * Time.deltaTime); 
        else if(blocksDestroyed == 4)
        {
            Destroy(stopBlockRef);
            stop = false;
            blocksDestroyed =0;
            playerAnims.speed = animSpeedStart;//TEMPORARY SOLUTION
            //turn off cam shake
            //camShakeRef.StopShake();
        }
        else if(stop == true)
        {
            playerAnims.speed = 0;//TEMPORARY SOLUTION
            //turn on cam shake
            //camShakeRef.StartShake();
            if(blocksDestroyed>currentBlock)
            {
                //play hammer animation
            }
        }
   

        if(Input.GetKey("escape"))
            Application.Quit();
            
        if(health <= 0)
        {
            SceneManager.LoadScene("End");
        }

    }

    public void OnCollisionEnter(Collision other)// 
    {
        
         //stopBlockRef = storeRef.gameObject;
        if(other.gameObject.tag == "Stop")
        {
            GameObject storeRef = other.gameObject;
            stop = true;
            stopBlockRef = storeRef.gameObject;
            //Debug.Log("I am here");
        }
            
    }

    public void OnTriggerEnter(Collider other)
{
        if(other.gameObject.tag == "Enemy")
        {
            TakeDamage(1);
            Debug.Log("Lost health");
        }
        else if(other.gameObject.tag == "Win")
            SceneManager.LoadScene("WinScreen");

}
    public void OnNailDestroyed(bool autoDestroy)
    {
        if(autoDestroy == false)
            blocksDestroyed++;
        else if(autoDestroy == true)
            blocksDestroyed = 4;//hardcoded
    }

    public void TakeDamage(float Damage)
    {
        health -= Damage;
    }
    public void AutoDestroyOn()
    {
        blocksDestroyed = 4;//hardcoded
    }
}
