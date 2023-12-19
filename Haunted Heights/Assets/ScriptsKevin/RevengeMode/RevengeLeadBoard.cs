using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine;

public class RevengeLeadBoard : MonoBehaviour
{
    static public int[] rleaderBoard = new int[10];
    //private int[] sortedLeaderBoard = new int[10];
    TextMeshProUGUI leaderBoardText;
    public GameObject leaderBoardObj;
    private bool boardOpen;
    public gameManager data;
    private void Start() 
    {
        //Scene scene = SceneManager.GetActiveScene();
        //if(scene.name == "End")//Potentially change for main menu leaderboard
        leaderBoardText = leaderBoardObj.GetComponent<TextMeshProUGUI>();
        for(int i =0; i<=9;i++)
        {
            rleaderBoard[i]= data.gameData.rLeadBoard[i];
        }
        
    }

    public void LeadUpdate(int score)
    {
        //always delete the 10th element 
        //order descending 
        //topScores = topScores.
        //always add new score to 10th and update leaderboard
        Debug.Log("AddingScores");
        rleaderBoard[9]=score;
        Array.Sort(rleaderBoard);
        Array.Reverse(rleaderBoard);
        for(int i =0; i<=9;i++)
        {
            data.gameData.rLeadBoard[i]= rleaderBoard[i];
        }
        SaveSystem.Save(data.gameData);
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
                leaderBoardText.text += "\nScore: " + rleaderBoard[i].ToString(); //+ leaderBoard[i].ToString();
                if(i>=9)
                    boardOpen = true;
            }
            
            Debug.Log(rleaderBoard[i]);
        }
    }
}
