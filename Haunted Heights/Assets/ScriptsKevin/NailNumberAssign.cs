using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.VFX;

public class NailNumberAssign : MonoBehaviour
{
    //Camera cameraT;
    public VisualEffect effectRef;
    [SerializeField]
    private VisualEffectAsset[] effects; 
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
            effectRef = this.gameObject.GetComponent<VisualEffect>();
            Debug.Log("MOVEEEEEEEEEEEEEEE");
            StartCoroutine(CheckIfCollide());
            //Vector3 collider.bounds
            //Vector3 currentPositions = transform.position;
            //transform.position = new Vector3(Random.Range(transform.position.x-5, transform.position.x+5),Random.Range(transform.position.y-2,transform.position.y+3 ),transform.position.z-2);
        //}

          
    }
    public void AssignNumber(int num)
    {
        spawnNumOrder = num;
        Debug.Log("NAIL"+ spawnNumOrder.ToString());
    }
    private void FixedUpdate() 
    {
        StartCoroutine(CheckIfCollide());
        if(spawnNumOrder == 4)
        {
            lastOne = true;
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "gameObject")
        {
            //Get index
            //higher index moves up
            NailNumberAssign nailIndRef = other.GetComponent<NailNumberAssign>();
            if(nailIndRef.spawnNumOrder > spawnNumOrder)
            {
                transform.position= new Vector3(transform.position.x+5,transform.position.y,transform.position.z);
            }
            
        }
        
    }
    IEnumerator CheckIfCollide()
    {
        Physics.SyncTransforms();
        yield return new WaitForFixedUpdate();
        Collider[] hitColliders = Physics.OverlapBox(gameObject.transform.position, gameObject.GetComponent<CapsuleCollider>().bounds.extents, Quaternion.identity, LayerMask.GetMask("Default"));
        if(hitColliders.Length >1)
        {
            transform.position = new Vector3(Random.Range(transform.position.x-1,transform.position.x+1),transform.position.y,transform.position.z);
            //Random.Range(transform.position.x-1,transform.position.x+5),
        }
    }
    public void Hit()
    {
        effectRef.visualEffectAsset = effects[0];
        effectRef.Play();
        
    }
    public void Miss()
    {
        effectRef.visualEffectAsset = effects[1];
        effectRef.Play();
    }
}
