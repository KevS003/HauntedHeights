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
    //public CubeController playerRef;

    // Start is called before the first frame update
    void Start()
    {
        currencyPass=currency;
    }
    public void GotCoin()
    {
        currency++;
        currencyPass= currency;
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
                    purchased2 = true;
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
                    purchased3=true;
                }
                    
                return true;
            }
        }
        Debug.Log("Brokie");
        return false;
    }
}
