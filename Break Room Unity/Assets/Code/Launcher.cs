using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject grenadePrefab;
    private float range = 20f;
    public KeyCode launchKey;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(launchKey))
        {
            LaunchGrenade();
        }
    }

    void LaunchGrenade()
    {
        GameObject newGrenade = Instantiate(grenadePrefab, spawnPoint.position, spawnPoint.rotation);
        newGrenade.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * range, ForceMode.Impulse);
    }
}
