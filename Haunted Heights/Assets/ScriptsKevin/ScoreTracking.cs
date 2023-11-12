using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreTracking : MonoBehaviour //controls UI and score tracking. Could also be used for leaderboard
{
    public GameObject scoreCount;
    private TextMeshProUGUI scoreCountText;
    public GameObject coinCount;
    private TextMeshProUGUI coinCountText;
    private bool playerDouble= false;
    [SerializeField]
    private float powerUpTime = 10f;
    private float powerTimeOG;

    public GameObject doublepoints;
    //LEADERBOARD update
    public LeaderBoard updateScore;
    public CurrencyScript coinRef;


    static public int totalScore=0;
    private static ScoreTracking _instance;
    public static ScoreTracking Instance{get {return _instance;}}
    // Start is called before the first frame update
    void Start()
    {
        if(_instance == null)
        {
            _instance = this;
        }
        scoreCountText = scoreCount.GetComponent<TextMeshProUGUI>();
        coinCountText = coinCount.GetComponent<TextMeshProUGUI>();
        powerTimeOG = powerUpTime;
    }

    // Update is called once per frame
    void Update()
    {
        scoreCountText.text = totalScore.ToString();
        coinCountText.text = "Coins: "+ coinRef.currencyPass.ToString(); 

        if(playerDouble == true && powerUpTime > 0.0f)
        {
            powerUpTime-= Time.deltaTime;
            Debug.Log(powerUpTime);
        }
        else if(powerUpTime <= 0.0f)
        {
            playerDouble = false;
            powerUpTime = powerTimeOG;
            //UI here
            doublepoints.SetActive(false);
        }
    }

    public void PlayerScored()
    {
        if(playerDouble == false)
            totalScore++;
        else if(playerDouble == true)
        {
            Debug.Log("We score two");
            totalScore+=2;
            //UI for double points, move to update
        }

    }
    public void PlayerDouble()
    {
        Debug.Log("I here");
        if(playerDouble==false)
            playerDouble = true;
    }
    public void PlayerEnd()//sends score to leaderboard
    {
        updateScore.LeadUpdate(totalScore);
        ScoreTracking.totalScore =0;
    }
    
}
