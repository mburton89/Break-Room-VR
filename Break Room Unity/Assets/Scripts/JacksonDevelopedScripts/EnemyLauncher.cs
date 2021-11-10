using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLauncher : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject grenadePrefab;
    private float range = 20f;

    void Start()
    {
        Debug.Log(transform.forward);
    }

    void Update()
    {
        
    }

    public void LaunchGrenade()
    {
        GameObject newGrenade = Instantiate(grenadePrefab, spawnPoint.position, spawnPoint.rotation);
        newGrenade.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * range, ForceMode.Impulse);
    }
}
