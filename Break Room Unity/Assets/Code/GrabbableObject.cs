using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class GrabbableObject : MonoBehaviour
{
    private ObjectGrabber _controller;
    private Rigidbody _rb;

    private Vector3 _previousPosition;
    private Vector3 _currentPosition;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<AIScript>() && gameObject.GetComponent<Rigidbody>().velocity.magnitude > 10f && !collision.gameObject.GetComponent<GrabbableObject>())
        {
            //Destroy(collision.gameObject);
            collision.gameObject.GetComponent<AIScript>().enabled = false;
            collision.gameObject.GetComponent<NavMeshAgent>().enabled = false;
            collision.gameObject.GetComponentInChildren<EnemyLauncher>().enabled = false;
            collision.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            collision.gameObject.GetComponent<Rigidbody>().velocity = collision.relativeVelocity / 4f;
            collision.gameObject.AddComponent<GrabbableObject>();
            collision.gameObject.layer = default;
        }
    }

    private void Update()
    {
        _previousPosition = _currentPosition;
        _currentPosition = transform.position;
    }

    public void Grab(ObjectGrabber controller)
    {
        _controller = controller;
        _rb = GetComponent<Rigidbody>();
        _rb.isKinematic = true;
        transform.SetParent(_controller.transform);
        transform.localPosition = Vector3.zero;
        transform.localEulerAngles = Vector3.zero;
    }

    public void LetGo()
    {
        if (_controller != null)
        {
            _controller.Reset();
        }
        _rb.isKinematic = false;
        _rb.transform.SetParent(null);
    }

    public void LetGo(float speed, Transform launcher)
    {
        if (_controller != null)
        {
            _controller.Reset();
        }
        _rb.isKinematic = false;
        _rb.transform.SetParent(null);
        _rb.AddForce(launcher.forward * speed);
    }

    public void Fling()
    {
        LetGo();
        _rb.AddForce((_currentPosition - _previousPosition) * 2000);
    }
}