using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour//Timer for revenge mode
{
    // Start is called before the first frame update
    public float targetTime;
    public float timeAddition;
    public ScoreTracking scoreEnd;
   // public GameObject timerObj;
    public TextMeshProUGUI timerText;
    public GameObject loseUI;
    void Update()//STOPS GAME AND SENDS SCORES
    {
        targetTime -= Time.deltaTime;
        timerText.text = "Timer: " + targetTime.ToString("0");

        if (targetTime <= 0.0f)
        {
            TimerEnded();
        }
        

    }
    public void TimeAdded()
    {
        targetTime +=timeAddition;
    }

    void TimerEnded()
    {
    //ACTIVATE LOSE SCREEN AND BIG SCORE
        scoreEnd.PlayerEndRevenge();
        Time.timeScale = 0;
        //Activate UI here
        loseUI.SetActive(true);
    }
    
}
