using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NailNumberAssign : MonoBehaviour
{
    public int spawnNumOrder=0;
    public bool lastOne = false;
    // Start is called before the first frame update
    public void AssignNumber(int num)
    {
        spawnNumOrder = num;
        Debug.Log("NAIL"+ spawnNumOrder.ToString());
    }
    private void Update() {
        if(spawnNumOrder == 4)
        {
            lastOne = true;
        }
    }
}
