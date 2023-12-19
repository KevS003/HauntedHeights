using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class gameManager : MonoBehaviour
{
    public float moveSpeed = 1.0f;
    public float enemySpeed = 0.2f;
    public Vector3 moveVector;
    public float speedMultiplier = 1.3f;
    public float speedUp = 1.3f;
    public GameData gameData;
    private void Awake() 
    {
        gameData = SaveSystem.Load();
    }
    public void GameOver()
    {
        //gameData.totalCoins+=
        //Get coins from other scripts 
        //get score from other script 
        //call this function after the player loses and take in coins and score as a parameter.  
    }
}
