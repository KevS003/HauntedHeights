using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreTracking : MonoBehaviour //controls UI and score tracking. Could also be used for leaderboard
{
    public GameObject scoreCount;
    private TextMeshProUGUI scoreCountText;
    private bool playerDouble= false;
    [SerializeField]
    private float powerUpTime = 10f;
    private float powerTimeOG;


    public int totalScore=0;
    // Start is called before the first frame update
    void Start()
    {
        scoreCountText = scoreCount.GetComponent<TextMeshProUGUI>();
        powerTimeOG = powerUpTime;
    }

    // Update is called once per frame
    void Update()
    {
        scoreCountText.text = totalScore.ToString();

        if(playerDouble == true && powerUpTime > 0.0f)
        {
            powerUpTime-= Time.deltaTime;
            Debug.Log(powerUpTime);
        }
        else if(powerUpTime <= 0.0f)
        {
            playerDouble = false;
            powerUpTime = powerTimeOG;
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
        }
    }
    public void PlayerDouble()
    {
        Debug.Log("I here");
        if(playerDouble==false)
            playerDouble = true;
    }
}
