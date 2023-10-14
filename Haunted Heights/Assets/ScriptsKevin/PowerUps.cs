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

    //Select time of auto destruct
    [SerializeField]
    private float autoDestructTime = 10f;

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
    }
    private void OnTriggerEnter(Collider other) 
    {
        //point multiplier
        if(multiplier)
        {
            //give extra score per tile
            Debug.Log("Multi");
            scoreMult.PlayerDouble();
        }
        else if(slowGhost)
        {
            //slow down ghost
            ghostSpeed.speedDownGhost();
        }
        else if(buildHammer)
        {
            //autobuildtiles
            autoDestroyNails.AutoBuild(autoDestructTime);
        }
        else if(extraLife)
        {
            //give one more try
        }
        else if(invincibility)
        {
            //no die 
        }
        //slow ghost
        //Auto Build hammer
        //Extra life
        //invincibility 
    }
}
