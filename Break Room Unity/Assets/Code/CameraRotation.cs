using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    Transform cameraBody;
    bool startNextRotation = true;
    public bool rotaRight;
    public float yaw;
    public float pitch;
    public float secondsToRota;
    public float rotaSwitchTime; 

    void Start()
    {
        //StartCoroutine(Rotate(secondsToRota));

        cameraBody = transform.GetChild(0);
        cameraBody.localRotation = Quaternion.AngleAxis(pitch, Vector3.right);

        SetUpStartRotation();
    }

    private void Update()
    {
        if(startNextRotation && rotaRight)
        {
            StartCoroutine(Rotate(yaw, secondsToRota));
        }
        else if (startNextRotation && !rotaRight)
        {
            StartCoroutine(Rotate(-yaw, secondsToRota));
        }
    }

    IEnumerator Rotate(float yaw, float duration)
    {
        startNextRotation = false; 

        Quaternion initialRotation = transform.rotation;

        float timer = 0f;

        while (timer < duration)
        {
            timer += Time.deltaTime;
            transform.rotation = initialRotation * Quaternion.AngleAxis(timer / duration * yaw, Vector3.up);
            yield return null;
        }

        yield return new WaitForSeconds(rotaSwitchTime);

        startNextRotation = true;
        rotaRight = !rotaRight;
    }

    void SetUpStartRotation()
    {
        if (rotaRight)
        {
            transform.localRotation = Quaternion.AngleAxis(-yaw / 2, Vector3.up);
        }
        else
        {
            transform.localRotation = Quaternion.AngleAxis(yaw / 2, Vector3.up);
        }
    }
}
