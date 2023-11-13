using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyObject());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
}
