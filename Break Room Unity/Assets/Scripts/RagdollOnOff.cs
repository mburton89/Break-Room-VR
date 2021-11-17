using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollOnOff : MonoBehaviour
{
    public BoxCollider mainbox;
    public GameObject thisguyrig;
       public Animator thisguyanim;




    private void OnCollisionEnter(Collision collision)
    {
        
    }

    Collider[] ragDollColliders;
    Rigidbody[] rigidbodies;
    void GetRagdool()
    {


        ragDollColliders = thisguyrig.GetComponentsInChildren<Collider>();
        rigidbodies = thisguyrig.GetComponentsInChildren<Rigidbody>();


    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
