using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class PowerUpRevenge : MonoBehaviour//gets referenced by items b4 destruction 
{
    //script references
    public ScoreTracking scoreMult;
    public DestroyClick autoDestroyNails;
    public CubeController playerSpeedUp;
    public AudioPlayer audioStuff;
    public CurrencyScript coinStuff;
    public RevengeClick rvgRef;

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
    public GameObject slowghost;
    public GameObject doublepoints;

    //AudioClips
    public AudioClip ghostSlowAudio;
    public AudioClip speedPlayerAudio;
    public AudioClip doublePointsAudio;
    public AudioClip coinAudio;
    public float doubleTimer;
    public float slowTimer;

    public void Start()
    {
        //source = GetComponent<AudioSource>();
        //autohammer.SetActive(false);
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
    public void PowerUp(int type)
    {
        if(type == 0)//multiplier
        {
            audioStuff.PlaySound(doublePointsAudio);
            StartCoroutine(DoubleTimer());
        }
        else if(type==1)//slowTime 
        {
            audioStuff.PlaySound(ghostSlowAudio);
            StartCoroutine(SlowTime());
        }
        else if(type == 2)//coin
        {
            audioStuff.PlaySound(coinAudio);
        }
    }

    /* private void PlaySound(AudioClip sound)
    {
        source.PlayOneShot(sound);
    } */
    IEnumerator DoubleTimer()
    {
        rvgRef.scoreDouble = true;
        doublepoints.SetActive(true);
        yield return new WaitForSeconds(doubleTimer);
        rvgRef.scoreDouble = false;
        doublepoints.SetActive(false);
    }
    IEnumerator SlowTime()
    {
        Time.timeScale = .05f;
        slowghost.SetActive(true);
        yield return new WaitForSeconds(slowTimer);
        slowghost.SetActive(false);
        Time.timeScale = 1;
    }
}
