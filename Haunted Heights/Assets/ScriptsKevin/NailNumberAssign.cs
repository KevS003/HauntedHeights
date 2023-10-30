using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class NailNumberAssign : MonoBehaviour
{
    //Camera cameraT;
    public int spawnNumOrder=0;
    public bool lastOne = false;
    // Start is called before the first frame update
    private void Awake() 
    {
        //cameraT= FindObjectOfType<Camera>();
        //new Vector3 cameraTransform = cameraT.transform.position;
        //spawn a sphere cast to detect if something here
       /* if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), 2f)==true ||
            Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), 2f)==true)
        {*/
            Debug.Log("MOVEEEEEEEEEEEEEEE");
            //Vector3 collider.bounds
            //Vector3 currentPositions = transform.position;
            transform.position = new Vector3(Random.Range(transform.position.x-5, transform.position.x+5),Random.Range(transform.position.y-2,transform.position.y+3 ),transform.position.z-2);
        //}

          
    }
    public void AssignNumber(int num)
    {
        spawnNumOrder = num;
        Debug.Log("NAIL"+ spawnNumOrder.ToString());
    }
    private void FixedUpdate() 
    {
        if(spawnNumOrder == 4)
        {
            lastOne = true;
        }
    }

    private void OnTriggerStay(Collider other) 
    {
        if(other.gameObject.tag == "gameObject")
        {
            //Get index
            //higher index moves up
            NailNumberAssign nailIndRef = other.GetComponent<NailNumberAssign>();
            if(nailIndRef.spawnNumOrder > spawnNumOrder)
            {
                transform.position= new Vector3(transform.position.x,transform.position.y+10,transform.position.z);
            }
            
        }
        
    }
}
