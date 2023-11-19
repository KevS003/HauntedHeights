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
    public RevengeLeadBoard rvgScore;//
    public CurrencyScript coinRef;


    static public int totalScore=0;
    static public int totalScoreRevenge=0;
    private static ScoreTracking _instance;
    public Timer timeRef;
    private int currentTen=10;
    public TextMeshProUGUI finalScore;
    private bool finalShow;

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
        if(updateScore!= null)
        {
            //Debug.Log("regularscore");
            scoreCountText.text = totalScore.ToString();
        }    
        else
        {
            //Debug.Log("REvengeScoer");
            scoreCountText.text = totalScoreRevenge.ToString();
        }
            

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
    #region Regular game mode scoring 
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
    #endregion
    
    #region Revenge game mode scoring 
    public void PlayerScoredRevenge(bool isDouble)
    {
        if(isDouble == false)
            totalScoreRevenge++;
        else if(isDouble == true)
        {
            Debug.Log("We score two");
            totalScoreRevenge+=2;
            //UI for double points, move to update
        }
        if(totalScoreRevenge>=currentTen)//every th is a timer update
        {
            timeRef.TimeAdded();
            //Spawnicon to signify +10
            currentTen+=10;
        }  

    }
    /* public void PlayerDoubleRevenge()
    {
        Debug.Log("I here");
        if(playerDouble==false)
            playerDouble = true;
    } */ 
    public void PlayerEndRevenge()//sends score to leaderboard
    {
        Debug.Log("Final Score UI: " + totalScoreRevenge);
        if(finalShow == false)
        {
            finalScore.text = "Final Score: " + totalScoreRevenge.ToString("0");
            finalShow = true;
        }
        
        rvgScore.LeadUpdate(totalScoreRevenge);//make a function for revenge lead
        totalScoreRevenge =0;
    }
    #endregion
}
