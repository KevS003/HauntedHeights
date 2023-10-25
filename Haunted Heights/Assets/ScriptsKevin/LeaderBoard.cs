using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class LeaderBoard : MonoBehaviour
{
    public List<int> leaderBoard;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //update leaderboard with a new score until 10 then start overwritting lowest scores
    }

    public void leadUpdate(int score)
    {
        //topScores = topScores.
        leaderBoard.Add(score);
        IEnumerable<int> leaderboard = leaderBoard.OrderByDescending(x => x).Take(10).ToList();


    }
}
