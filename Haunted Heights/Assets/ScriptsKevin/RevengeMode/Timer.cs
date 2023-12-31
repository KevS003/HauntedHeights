using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour//Timer for revenge mode
{
    // Start is called before the first frame update
    public float targetTime;
    public float timeAddition;
    public float timeSubtract;
    public ScoreTracking scoreEnd;
   // public GameObject timerObj;
    public TextMeshProUGUI timerText;
    public GameObject plusTime;
    public GameObject minusOne;
    public GameObject losetwenty;
    public GameObject loseMore;//Just incase
    public GameObject clickRef;
    public GameObject loseUI;
    public float timeDownGhostWall;
    public GameObject pauseUI;

    private void Start() {
        plusTime.SetActive(false);
        minusOne.SetActive(false);
        losetwenty.SetActive(false);
        if(loseMore!=null)
        {
            loseMore.SetActive(false);
        }
    }

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
        StartCoroutine(UItimer(plusTime, 2));
        targetTime +=timeAddition;
    }
    public void TimeSub()
    {
        StartCoroutine(UItimer(losetwenty, 1));
        targetTime -=timeSubtract;
    }
    public void TimeSubGhostWall()
    {
        StartCoroutine(UItimer(minusOne, 1));
        targetTime-=timeDownGhostWall;
    }

    void TimerEnded()
    {
    //ACTIVATE LOSE SCREEN AND BIG SCORE
        timerText.text = "Timer: 0";
        scoreEnd.PlayerEndRevenge();
        Time.timeScale = 0;
        clickRef.gameObject.SetActive(false);
        pauseUI.SetActive(false);
        //Activate UI here
        loseUI.SetActive(true);
    }
    IEnumerator UItimer(GameObject settingOff, int screenTime)
    {
        settingOff.SetActive(true);
        yield return new WaitForSeconds(screenTime);
        settingOff.SetActive(false);
    }
    
}
