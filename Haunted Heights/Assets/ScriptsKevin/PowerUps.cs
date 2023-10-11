using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    //script references
    public ScoreTracking scoreMult;
    public EnemyController ghostSpeed;
    public DestroyClick autoDestroyNails;
    public CubeController extraLifeInv;

    //type selector
    [SerializeField]
    private bool multiplier;
    [SerializeField]
    private bool slowGhost;
    [SerializeField]
    private bool buildHammer;
    [SerializeField]
    private bool extraLife;
    [SerializeField]
    private bool invincibility;
    private void Awake() 
    {
        scoreMult.GetComponent<ScoreTracking>();
        ghostSpeed.GetComponent<EnemyController>();
        autoDestroyNails.GetComponent<DestroyClick>();
        extraLifeInv.GetComponent<CubeController>();    
    }
    private void OnTriggerEnter(Collider other) 
    {
        //point multiplier
        if(multiplier)
        {
            //give extra score per tile
            Debug.Log("Multi");
        }
        if(slowGhost)
        {
            //slow down ghost
        }
        if(buildHammer)
        {
            //autobuildtiles
        }
        if(extraLife)
        {
            //give one more try
        }
        if(invincibility)
        {
            //no die 
        }
        //slow ghost
        //Auto Build hammer
        //Extra life
        //invincibility 
    }
}
