using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyClick : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
                    Debug.Log("IT WORKS");
        Destroy(gameObject);
        }
    }
    /*void OnMouseDown()
    {

            
    }*/
}
