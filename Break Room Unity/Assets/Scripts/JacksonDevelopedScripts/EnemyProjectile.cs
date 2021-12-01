using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(liveTime());
    }

    IEnumerator liveTime()
    {
        yield return new WaitForSeconds(3f);
        Destroy(this.gameObject);
    }
}
