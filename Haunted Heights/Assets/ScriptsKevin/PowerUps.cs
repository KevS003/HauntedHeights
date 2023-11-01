using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    //script references
    public ScoreTracking scoreMult;
    public EnemyController ghostSpeed;
    public DestroyClick autoDestroyNails;
    public CubeController extraLifeInv;
    public CubeController playerSpeedUp;

    //type selector
    [SerializeField]
    private bool multiplier;
    [SerializeField]
    private bool slowGhost;
    [SerializeField]
    private bool buildHammer;
    [SerializeField]
    private bool speedUpPlayer;
    [SerializeField]
    private bool extraLife;
    [SerializeField]
    private bool invincibility;


    //Select time of auto destruct
    [SerializeField]
    private float autoDestructTime = 10f;

    //UI
    public GameObject autohammer;
    public GameObject slowghost;
    public GameObject doublepoints;


    public void Start()
    {
        autohammer.SetActive(false);
        slowghost.SetActive(false);
        doublepoints.SetActive(false);
        
    }
    private void Awake() 
    {
        
        if(multiplier)
            scoreMult.GetComponent<ScoreTracking>();
        if(slowGhost)
            ghostSpeed.GetComponent<EnemyController>();
        if(buildHammer)
            autoDestroyNails.GetComponent<DestroyClick>();
        if(extraLife)
            extraLifeInv.GetComponent<CubeController>();
        if(speedUpPlayer)
            playerSpeedUp.GetComponent<CubeController>();
    }

    private void OnTriggerEnter(Collider other) //control F UI in said scripts to find where UI input should go
    {
        //point multiplier
        if(multiplier)
        {
            //give extra score per tile
            doublepoints.SetActive(true);
            Debug.Log("Multi");
            scoreMult.PlayerDouble();
            Destroy(gameObject);
        }
        else if(slowGhost)
        {
            //slow down ghost
            //put UI feedback in here for slow ghost
            slowghost.SetActive(true);
            ghostSpeed.speedDownGhost();
            Destroy(gameObject);
        }
        else if(buildHammer)
        {
            //autobuildtiles
            //UI feedback in destroy click
            autoDestroyNails.AutoBuild(autoDestructTime);
            Destroy(gameObject);
        }
        else if(speedUpPlayer)
        {
            autohammer.SetActive(true);//NOW FOR SPEEDUP
            playerSpeedUp.SpeedUpPlayer();
            Destroy(gameObject);
        }
        else if(extraLife)
        {
            //give one more try
        }
        else if(invincibility)
        {
            //no die 
        }
        //Extra life
        //invincibility 
    }
}
