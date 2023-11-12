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
    public AudioPlayer audioStuff;
    public CurrencyScript coinStuff;

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
    [SerializeField]
    private bool coin;


    //Select time of auto destruct
    [SerializeField]
    private float autoDestructTime = 10f;

    //UI
    public GameObject autohammer;
    public GameObject slowghost;
    public GameObject doublepoints;

    //AudioClips
    private AudioSource source;
    public AudioClip ghostSlowAudio;
    public AudioClip speedPlayerAudio;
    public AudioClip doublePointsAudio;
    public AudioClip coinAudio;  


    public void Start()
    {
        source = GetComponent<AudioSource>();
        autohammer.SetActive(false);
        slowghost.SetActive(false);
        doublepoints.SetActive(false);
        
    }
    /* private void Awake() 
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
        if(coin)
            coinStuff.GetComponent<CurrencyScript>();
    } */

    private void OnTriggerEnter(Collider other) //control F UI in said scripts to find where UI input should go
    {
        //point multiplier
        if(multiplier)
        {

            //give extra score per tile
            if(doublepoints !=null)
                audioStuff.PlaySound(doublePointsAudio);
            doublepoints.SetActive(true);
            Debug.Log("Multi");
            scoreMult.PlayerDouble();
            Destroy(gameObject);
        }
        else if(slowGhost)
        {
            //slow down ghost
            //put UI feedback in here for slow ghost
            if(ghostSlowAudio !=null)
                audioStuff.PlaySound(ghostSlowAudio);
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
            if(speedPlayerAudio !=null)
                audioStuff.PlaySound(speedPlayerAudio);
            autohammer.SetActive(true);//NOW FOR SPEEDUP
            playerSpeedUp.SpeedUpPlayer();
            Destroy(gameObject);
        }
        else if(coin)
        {
            audioStuff.PlaySound(coinAudio);
            coinStuff.GotCoin();
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

    private void PlaySound(AudioClip sound)
    {
        source.PlayOneShot(sound);
    }
}
