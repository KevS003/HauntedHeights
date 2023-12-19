using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyScript : MonoBehaviour
{
    private static int currency;
    public int currencyPass;
    public int priceSkin2;
    public int priceSkin3;
    static private bool purchased2;
    static private bool purchased3;
    public gameManager data;
    //public CubeController playerRef;

    // Start is called before the first frame update
    void Start()
    {
        currency = data.gameData.totalCoins;
        currencyPass=currency;
        if(data.gameData.skinsUnlocked[1]==true)
        {
            purchased2 = true;
        }
        if(data.gameData.skinsUnlocked[2]==true)
        {
            purchased3 = true;
        }
    }
    public void GotCoin()
    {
        currency++;
        currencyPass= currency;
        data.gameData.totalCoins = currency;
    }
    public bool SkinPurchase(int whichOne)
    {
        Debug.Log("CheckingCoins");
        if(whichOne ==2)
        {
            Debug.Log("Checking account");
            if(currency>=priceSkin2 || purchased2)
            {
                if(!purchased2)
                {
                    currency-=priceSkin2;
                    currencyPass = currency;
                    data.gameData.totalCoins = currency;
                    purchased2 = true;
                    data.gameData.skinsUnlocked[1]=true;
                    SaveSystem.Save(data.gameData);
                }
                    
                return true;
            }
            
        }
        else if(whichOne ==3)
        {
            Debug.Log("Checking Account");
            if(currency>=priceSkin3|| purchased3)
            {
                if(!purchased3)
                {
                    currency-=priceSkin3;
                    currencyPass = currency;
                    data.gameData.totalCoins = currency;
                    purchased3=true;
                    data.gameData.skinsUnlocked[2]=true;
                    SaveSystem.Save(data.gameData);
                }
                    
                return true;
            }
        }
        Debug.Log("Brokie");
        return false;
    }
}
