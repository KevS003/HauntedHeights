using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class GameData
{
    public int totalCoins;
    //public int totalScore;
    public int totalScoreRevengeMode;
    public int[] leaderBoard;
    public int[] rLeadBoard;

    public bool[] skinsUnlocked;

    public float volume;

    public GameData()
    {
        totalCoins = 0;//Done
        //totalScore = 0;
        leaderBoard = new int[10];//done
        rLeadBoard = new int[10];//Done
        skinsUnlocked = new bool[3];//Done?
        skinsUnlocked[0]= true;
        skinsUnlocked[1]= false;
        skinsUnlocked[2]=false;
        volume = 1;//done?

    }
}
