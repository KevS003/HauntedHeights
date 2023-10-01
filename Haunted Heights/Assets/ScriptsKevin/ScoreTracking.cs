using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreTracking : MonoBehaviour //controls UI and score tracking. Could also be used for leaderboard
{
    public GameObject scoreCount;
    private TextMeshProUGUI scoreCountText;

    public int totalScore=0;
    // Start is called before the first frame update
    void Start()
    {
        scoreCountText = scoreCount.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreCountText.text = totalScore.ToString();
    }

    public void PlayerScored()
    {
        totalScore++;
    }
}
