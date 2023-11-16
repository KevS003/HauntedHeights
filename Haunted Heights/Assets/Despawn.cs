using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despawn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Destruction());
    }

    // Update is called once per frame
    IEnumerator Destruction()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
