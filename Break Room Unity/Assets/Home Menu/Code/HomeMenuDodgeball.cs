using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeMenuDodgeball : MonoBehaviour
{
    [SerializeField] Vector3 direction;
    [SerializeField] float speed;

    void Start()
    {
        GetComponent<Rigidbody>().AddForce(direction * speed);
    }
}
