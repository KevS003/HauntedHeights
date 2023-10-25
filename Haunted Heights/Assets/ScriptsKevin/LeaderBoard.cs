using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class LeaderBoard : MonoBehaviour
{
    public List<int> leaderBoard;

    public void leadUpdate(int score)
    {
        //topScores = topScores.
        leaderBoard.Add(score);
        IEnumerable<int> leaderboard = leaderBoard.OrderByDescending(x => x).Take(10).ToList();
        Debug.Log("LeaderBoard: " + leaderBoard[0]);


    }
}
