using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDetection : MonoBehaviour
{
    string playerTag;
    public Material searchingMat, spottedMat;
    Transform lens;

    void Start()
    {
        lens = transform.parent.GetComponent<Transform>();
        playerTag = GameObject.FindGameObjectWithTag("Player").tag;
    }

    void OnTriggerStay(Collider col)
    {
        if(col.gameObject.tag == playerTag)
        {
            Vector3 direction = col.transform.position - lens.position;
            RaycastHit hit;

            if(Physics.Raycast(lens.transform.position, direction.normalized, out hit, 1000))
            {
                Debug.Log(hit.collider.name);
                if(hit.collider.gameObject.tag == playerTag)
                {
                    lens.GetComponentInParent<MeshRenderer>().material = spottedMat;
                }
                else
                {
                    lens.GetComponentInParent<MeshRenderer>().material = searchingMat;
                }
            }
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if(col.transform.tag == playerTag)
        {
            lens.GetComponentInParent<MeshRenderer>().material = searchingMat;
        }
    }

}
