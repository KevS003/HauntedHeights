using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

public class CubeController : MonoBehaviour
{
    //score reference to send score to leaderboard
    public ScoreTracking deathScore;

    //player skins
    [SerializeField]
    Material[] playerSkins;
    [SerializeField]
    GameObject playerModel;
    SkinnedMeshRenderer playerRend;
    static int currentSkin=0;

    //check if at end
    bool endMaybe;
    string sceneName;


    //UI ref
    public GameObject autohammer;

    gameManager GameManager;
    [SerializeField]
    private Animator playerAnims;
    private int blocksDestroyed;
    private int currentBlock=0;
    public bool stop;
    private GameObject stopBlockRef= null;
    public float health = 3;
    public float speedupDuration = 3;
    //TEMPORARY SOLUTION VAR
    private float animSpeedStart;
    //camera shake
    public CameraShake camShakeRef;
    private float minSpeedPlayer;
    public CurrencyScript coinRef;

    void Start()
    {
        playerRend = playerModel.GetComponent<SkinnedMeshRenderer>();
        playerRend.material = playerSkins[currentSkin];
        GameObject gameController = GameObject.FindGameObjectWithTag("GameController");
        GameManager = gameController.GetComponent<gameManager>();
        animSpeedStart = playerAnims.speed;
        minSpeedPlayer = GameManager.moveSpeed;
        //Scene currentScene = SceneManager.GetActiveScene();
        //sceneName = currentScene.name;
        /* if(sceneName == "End")
        {
            endMaybe = true;
        }
        else
        {
            endMaybe = false;
        } */

    }

    
    void LateUpdate()
    {
        //if there is no block tagged stop in front keep moving
        //When blocked wait until all 4 things are ded and move forward. 
        //Use collision to respawn nails
        //If statement when making contact with box that activates variable
        if(stop == false)//detects collision to stop movement
            transform.Translate(GameManager.moveVector * GameManager.moveSpeed * Time.deltaTime); 
        else if(blocksDestroyed == 4)
        {
            //change color and turn off collider box
            stopBlockRef.GetComponent<BoxCollider>().enabled = false;
            stopBlockRef.transform.GetChild(0).gameObject.SetActive(true);
            //Destroy(stopBlockRef);
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
            deathScore.PlayerEnd();   
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
        {
            //deathScore.PlayerEnd();
            //if statement that swaps between two or three scenes
            SceneManager.LoadScene(0);//change to next roof or restart scene here. 

        }
            

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

    public void SpeedUpPlayer()
    {
        GameManager.moveSpeed *= GameManager.speedUp;
        StartCoroutine(SpeedUpCooldown());
        Debug.Log(GameManager.moveSpeed.ToString());
    }

    public void SpeedDownPlayer()
    {
        autohammer.SetActive(false);
        if(GameManager.moveSpeed > minSpeedPlayer)
            GameManager.moveSpeed /= GameManager.speedUp;
        else
            GameManager.moveSpeed = minSpeedPlayer;
        Debug.Log(GameManager.moveSpeed.ToString());
    }

    IEnumerator SpeedUpCooldown()
    {
        yield return new WaitForSeconds(speedupDuration);
        SpeedDownPlayer();
    }
    public void skinOne()
    {
        playerRend.material = playerSkins[0];
        currentSkin = 0;
    }
    public void skinTwo()
    {
        Debug.Log("No money");
        if(coinRef.SkinPurchase(2))
        {
            Debug.Log("Purchase made");
            playerRend.material = playerSkins[1];
            currentSkin = 1;
        }
        
    }
    public void skinThree()
    {
        if(coinRef.SkinPurchase(3))
        {
            Debug.Log("Purchase made");
            playerRend.material = playerSkins[2];
            currentSkin = 2;
        }
        
    }
}
