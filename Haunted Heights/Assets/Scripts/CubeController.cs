using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

public class CubeController : MonoBehaviour
{

    gameManager GameManager;
    private int blocksDestroyed;
    public bool stop;
    private GameObject stopBlockRef= null;
    public float health = 3;
//objects destroyed = 4 
//
 
    void Start()
    {
        GameObject gameController = GameObject.FindGameObjectWithTag("GameController");
        GameManager = gameController.GetComponent<gameManager>();

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
            Debug.Log("DESTROYYYYYYYYYYYY PLEASEEEEEEEEEEEE");
            Destroy(stopBlockRef);
            stop = false;
            blocksDestroyed =0;
        }
        if(stopBlockRef == null)
        {
            Debug.Log("No read");
        }
        else
        {
            Debug.Log("Got it");
        }

        if(Input.GetKey("escape"))
            Application.Quit();
            
        if(health <= 0)
        {
            SceneManager.LoadScene("End");
        }

    }

    private void OnCollisionEnter(Collision other)// 
    {
        
        //stopBlockRef = storeRef.gameObject;
        if(other.gameObject.tag == "Stop")
        {
            GameObject storeRef = other.gameObject;
            stop = true;
            stopBlockRef = storeRef.gameObject;
            Debug.Log("I am here");
        }

        if(other.gameObject.tag == "Enemy")
        {
            TakeDamage(1);
            Debug.Log("Lost health");
        }
            
    }

    public void OnNailDestroyed()
    {
        blocksDestroyed++;
    }

    public void TakeDamage(float Damage)
    {
        health -= Damage;
    }
}
