using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGrabber : MonoBehaviour
{
    private Collider _collider;
    private GrabbableObject _potentialObject;
    private GrabbableObject _grabbedObject;

    [SerializeField] float throwSpeed;
    [SerializeField] Vector3 throwDirection;

    void Awake()
    {
        _collider = GetComponent<Collider>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            _collider.enabled = false;
        }
        else if (Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1))
        {
            _collider.enabled = true;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (_potentialObject != null)
            {
                _grabbedObject = _potentialObject;
                _grabbedObject.Grab(this);
            }
        }

        else if (Input.GetKeyUp(KeyCode.E))
        {
            if (_grabbedObject != null)
            {
                _grabbedObject.LetGo(throwSpeed, transform);
            }
            Reset();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<GrabbableObject>())
        {
            _potentialObject = other.GetComponent<GrabbableObject>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<GrabbableObject>() == _potentialObject)
        {
            _potentialObject = null;
        }
    }

    public void Reset()
    {
        _potentialObject = null;
        _grabbedObject = null;
    }
}