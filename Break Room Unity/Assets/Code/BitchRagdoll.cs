using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bitchragdoll : MonoBehaviour
{
    // Start is called before the first frame update

    public BoxCollider mainCollider;


    public GameObject ThisGuysRig;
    public Animator ThisGuyAnimator;





    void Start()
    {
        GetRagdollBits();
        RagdollModeOff();
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    void RagdollModeOn()
    {

        foreach (Collider col in RagdollColliders)
        {
            col.enabled = true;

        }
        foreach (Rigidbody rigid in limbsRigidbodies)
        {

            rigid.isKinematic = false;

        }
       
        mainCollider.enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;


    }
    private void OnCollisionEnter(Collision collison)
    {
        if (collison.gameObject.tag == "knock")
        {

            RagdollModeOn();

        }
    }
    Collider[] RagdollColliders;
    Rigidbody[] limbsRigidbodies;


    void GetRagdollBits()
    {
        RagdollColliders = ThisGuysRig.GetComponentsInChildren<Collider>();
        limbsRigidbodies = ThisGuysRig.GetComponentsInChildren<Rigidbody>();



    }



    void RagdollModeOff()
    {

        foreach(Collider col in RagdollColliders)
        {
            col.enabled = false;

        }
        foreach(Rigidbody rigid in limbsRigidbodies)
        {

            rigid.isKinematic = true;

        }
        ThisGuyAnimator.enabled = true;
        mainCollider.enabled = true;
        GetComponent<Rigidbody>().isKinematic = false;

    }


}
