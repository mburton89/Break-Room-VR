using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CeilingFanBreak : MonoBehaviour
{
   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    public void OnTriggerEnter(Collider other)
    {
        other.transform.parent = gameObject.transform;
    }

    public void OnTriggerExit(Collider other)
    {
        other.transform.parent = null;
    }
}
