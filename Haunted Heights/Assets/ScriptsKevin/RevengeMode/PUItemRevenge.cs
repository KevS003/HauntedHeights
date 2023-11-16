using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class PUItemRevenge : MonoBehaviour//gets placed on items
{//bool that sends info to revenge script 
    //script references
    public PowerUpRevenge purRef;

    //type selector
    [SerializeField]
    private bool multiplier;
    [SerializeField]
    private bool slowTime;
    [SerializeField]
    private bool coin;



    //Select time of slow
    [SerializeField]
    private float slowDownTimer = 10f;

    //UI
    //public GameObject autohammer;
    public GameObject slowTimeOBJ;
    public GameObject doublepoints;

    //AudioClips
    //private AudioSource source;
    //public AudioClip ghostSlowAudio;
    //public AudioClip doublePointsAudio;
    //public AudioClip coinAudio;  


    public void Start()
    {
        //source = GetComponent<AudioSource>();
        //autohammer.SetActive(false);
        slowTimeOBJ.SetActive(false);
        doublepoints.SetActive(false);
    }
    public void PowerUp()
    {
        if(multiplier)
        {
            //0
            //Double score
            purRef.PowerUp(0);
            Destroy(gameObject);
        }
        else if(slowTime)
        {
            //1
            purRef.PowerUp(1);
            Destroy(gameObject);
        }
        else if(coin)
        {
            //2
            purRef.PowerUp(2);
            Destroy(gameObject);

        }
    }
}
