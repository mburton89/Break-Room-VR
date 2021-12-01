using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCubeBitch : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 10;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
