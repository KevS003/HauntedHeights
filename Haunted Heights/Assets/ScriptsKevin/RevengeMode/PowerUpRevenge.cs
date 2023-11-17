using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class PowerUpRevenge : MonoBehaviour//gets referenced by items b4 destruction 
{
    //script references
    public AudioPlayer audioStuff;
    public CurrencyScript coinStuff;
    public RevengeClick rvgRef;
    //UI
    public GameObject slowghost;
    public GameObject doublepoints;

    //AudioClips
    public AudioClip ghostSlowAudio;
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
            coinStuff.GotCoin();
        }
    }

    IEnumerator DoubleTimer()
    {
        rvgRef.scoreDouble = true;
        doublepoints.SetActive(true);
        yield return new WaitForSeconds(doubleTimer);
        Debug.Log("OFF DOUBLE");
        rvgRef.scoreDouble = false;
        doublepoints.SetActive(false);
    }
    IEnumerator SlowTime()
    {
        Time.timeScale = .5f;
        slowghost.SetActive(true);
        yield return new WaitForSeconds(slowTimer/ 2);//accounts for slow time 
        Debug.Log("OFF SLOW");
        slowghost.SetActive(false);
        Time.timeScale = 1;
    }
}
