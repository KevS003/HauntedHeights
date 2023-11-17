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
    public GameObject clickRef;
    public GameObject loseUI;
    private void Start() {
        plusTime.SetActive(false);
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
        StartCoroutine(UItimer());
        targetTime +=timeAddition;
    }
    public void TimeSub()
    {
        targetTime -=timeSubtract;
    }

    void TimerEnded()
    {
    //ACTIVATE LOSE SCREEN AND BIG SCORE
        timerText.text = "Timer: 0";
        scoreEnd.PlayerEndRevenge();
        Time.timeScale = 0;
        clickRef.gameObject.SetActive(false);
        //Activate UI here
        loseUI.SetActive(true);
    }
    IEnumerator UItimer()
    {
        plusTime.SetActive(true);
        yield return new WaitForSeconds(2);
        plusTime.SetActive(false);
    }
    
}
