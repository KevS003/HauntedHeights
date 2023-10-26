using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LeaderBoard : MonoBehaviour
{
    static public int[] leaderBoard = new int[10];
    private int[] sortedLeaderBoard = new int[10];
    TextMeshProUGUI leaderBoardText;
    public GameObject leaderBoardObj;
    private bool boardOpen;
    private void Start() 
    {
        Scene scene = SceneManager.GetActiveScene();
        //if(scene.name == "End")//Potentially change for main menu leaderboard
        leaderBoardText = leaderBoardObj.GetComponent<TextMeshProUGUI>(); 

    }

    public void LeadUpdate(int score)
    {
        //always delete the 10th element 
        //order descending 
        //topScores = topScores.
        //always add new score to 10th and update leaderboard
        Debug.Log("AddingScores");
        leaderBoard[9]=score;
        Array.Sort(leaderBoard);
        Array.Reverse(leaderBoard);
        //WriteBoard();
        //Debug.Log("LeaderBoard: " + leaderBoard[0]);
    }
    public void WriteBoard()
    {
        for(int i=0; i<=9;i++)
        {
            Debug.Log("HERE");
            if(boardOpen ==false && i<=9)
            {
                leaderBoardText.text += "\nScore: " + leaderBoard[i].ToString(); //+ leaderBoard[i].ToString();
                if(i>=9)
                    boardOpen = true;
            }
            
            Debug.Log(leaderBoard[i]);
        }
    }
}
