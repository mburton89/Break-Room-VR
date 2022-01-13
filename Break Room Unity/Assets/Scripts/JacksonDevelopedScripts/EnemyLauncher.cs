using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLauncher : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject grenadePrefab;
    public AIScript parentScript;
    private float range = 45f;
    private GameObject newGrenade;
    private Vector3 playerDirection;

    void Start()
    {
        CreateBall();
    }

    void Update()
    {
        
        playerDirection = (parentScript.target.position - transform.position).normalized;
    }

    public void CreateBall()
    {
        newGrenade = Instantiate(grenadePrefab, spawnPoint.position, spawnPoint.rotation);
        newGrenade.GetComponent<Rigidbody>().detectCollisions = false;
        newGrenade.transform.parent = gameObject.transform;
        newGrenade.GetComponent<Rigidbody>().useGravity = false;
    }

    public void LaunchGrenade()
    {
        Destroy(newGrenade);
        GameObject projectile = Instantiate(grenadePrefab, spawnPoint.position, spawnPoint.rotation);
        projectile.GetComponent<Rigidbody>().AddForce(playerDirection * range, ForceMode.Impulse);

        StartCoroutine(WaitTime());
    }

    private IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(4f);
        CreateBall();
    }
}
